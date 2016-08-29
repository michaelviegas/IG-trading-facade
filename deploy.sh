#!/bin/bash
set -ev
if [ "${TRAVIS_BRANCH}" = "master" ]; then
	nuget pack ./IgTradingFacade/IgTradingFacade.csproj -Version 1.0.$TRAVIS_BUILD_NUMBER -IncludeReferencedProjects -Prop Configuration=Release
	nuget push ./*.nupkg $NUGET_API_KEY -Source https://www.nuget.org/api/v2/package
fi