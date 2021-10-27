---
page_type: sample
languages:
- csharp
products:
- azure-digital-twins
- azure-iot-pnp
name: DTDL Validator
description: A code sample for validating DTDL model code
urlFragment: dtdl-validator
---

# Introduction

This project demonstrates use of the Azure Digital Twins DTDL parser, available [here](https://nuget.org/packages/Microsoft.Azure.DigitalTwins.Parser/) on NuGet. It  is language-agnostic, and can be used as a command line utility to validate a directory tree of DTDL files. It also provides an interactive mode.

The source code shows examples for how to use the parser library, and can validate model documents to make sure the DTDL is valid.

## Getting started

The program is a command line application that can be used in normal or interactive mode.

In normal mode, specify:

* a file extension (-e, default json)
* a directory to search (-d, default '.')
* a recursive option that determines if the file search descends into subdirectories (-r, default true)

Interactive mode is entered with the -i option. Type help for information on interactive commands

## What the code demonstrates

* Basic use of the DTDL parser for validation of DTDL
* Basic use of the object model to access information about DTDL content (see the interactive module, in particular the list and show/showinfo commands)

## Build and test

Build the project and run the application from the command line.

You can also create a self-contained single-file .exe (no other files or installations required):

Run

```bash
dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true
```

in the root folder of the repo.

### Running in macOS

1. Build the app: `dotnet build` (from the DTDLValidator-Sample folder)
2. This will build the application and produce a file, `DTDLValidator.dll`, in the `DTDLValidator/bin/Debug/netcoreapp3.1` folder
3. Using the DTDL Validator DLL that was created from the previous step, run: `dotnet $pathofdll` (Run this command where your DTDL files live or the files that you are trying to validate).

## Running within VSCode

1. Open the folder `DTDLValidator-Sample` with VSCode
2. Within the `.vscode` folder, a launch file which has the configuration to build and run the application.
3. Press `F5` to build and run the application to validate the files.

*Note: within the `launch.json`, the working directory can be changed to the directory where the json files are stored for validation.
