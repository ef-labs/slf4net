#!/usr/bin/env bash

cd "${0%/*}"/nuget/

for f in *.nupkg; do
  nuget push "${f}" -Source https://nuget.org/
done

