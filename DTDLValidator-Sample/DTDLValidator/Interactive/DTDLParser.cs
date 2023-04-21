using DTDLParser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DTDLValidator.Interactive
{
    internal class DTDLParser
    {
        private readonly IDictionary<Dtmi, DTInterfaceInfo> modelStore;
        public DTDLParser(IDictionary<Dtmi, DTInterfaceInfo> modelStore)
        {
            this.modelStore = modelStore;
        }

        public async Task<(IReadOnlyDictionary<Dtmi, DTEntityInfo>, IEnumerable<DTInterfaceInfo>)> ParseAsync(IAsyncEnumerable<string> jsonTexts)
        {
            // Create resolver state per call to ParseAsync so that multiple calls to ParseAsync can run concurrently.
            DTDLResolver dtdlResolver = new DTDLResolver(modelStore);
            ModelParser parser = new ModelParser(new ParsingOptions { DtmiResolverAsync = dtdlResolver.Resolver}); 
            IReadOnlyDictionary<Dtmi, DTEntityInfo> entities = await parser.ParseAsync(jsonTexts);
            return (entities, dtdlResolver.ResolvedInterfaces);
        }


        private class DTDLResolver
        {
            private readonly IDictionary<Dtmi, DTInterfaceInfo> modelStore;
            public DTDLResolver(IDictionary<Dtmi, DTInterfaceInfo> modelStore)
            {
                this.modelStore = modelStore;
            }


#pragma warning disable CS8425 // Async-iterator member has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed
            public async IAsyncEnumerable<string> Resolver(IReadOnlyCollection<Dtmi> dtmis, CancellationToken cancellationToken)
#pragma warning restore CS8425 // Async-iterator member has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed
            {
                List<string> texts = new List<string>();
                foreach (Dtmi dtmi in dtmis)
                {
                    if (modelStore.TryGetValue(dtmi, out DTInterfaceInfo @interface))
                    {
                        ResolvedInterfaces.Add(@interface);
                        texts.Add(@interface.GetJsonLdText());
                        yield return @interface.GetJsonLdText();
                    }
                }
                await Task.Yield();
                //return texts;
            }

            public IList<DTInterfaceInfo> ResolvedInterfaces { get; private set; } = new List<DTInterfaceInfo>();

        }
        
    }
}
