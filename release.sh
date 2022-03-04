#!/bin/bash

rm release.zip
cd Pingprovements
dotnet build
cd ..
mkdir -p release/Pingprovements
cp Pingprovements/bin/Debug/netstandard2.0/Pingprovements.dll release/Pingprovements
cp manifest.json release/
cp icon.png release/
cp README.md release/
cd release
7z a ../release.zip *
cd ..
rm -rf release

echo "done"
