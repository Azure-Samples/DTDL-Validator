using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTDLValidator
{
    public static class ListExtensions
    {
        public static async IAsyncEnumerable<T> AsAsyncEnumerable<T>(this IEnumerable<T> input)
        {
            foreach (var value in input)
            {
                yield return value;
            }
            await Task.Yield();
        }
    }
}
