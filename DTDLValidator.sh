# This program can be used to build and run the DTDLValidator without requiring manual steps.

#!/bin/bash

echo "Enter Directory Path of DTDLValidator-Sample"
read args1

echo "Enter Directory Path of JSON Files to Validate"
read args2

if [ -z "$args1" ] || [ -z "$args2" ]
  then
    echo "Directory path not provided"
fi

cd $args1

# Build Progam 
dotnet build

# Execute DTDLValidator
cd $args2
pathToDll='/DTDLValidator/bin/Debug/netcoreapp3.1/DTDLValidator.dll'
pathToRun="${args1}${pathToDll}"
echo $pathToRun
dotnet $pathToRun
