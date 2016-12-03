#!/bin/sh
set -ev

latestTag=$(git describe --tags `git rev-list --tags --max-count=1`)
parsed=(${latestTag//./ })
latestMajor=${parsed[0]}
latestMinor=${parsed[1]}
latestRevision=${parsed[2]}
newMajor=$1
newMinor=$2
newRevision=0

if [ $newMajor == $latestMajor ] && [ $newMinor == $latestMinor ]; then
    newRevision=$(($latestRevision+1))
fi

newVersion=$newMajor"."$newMinor"."$newRevision

env -i git config --global user.email "builds@travis-ci.com"
env -i git config --global user.name "Travis CI"
env -i git tag $newVersion
env -i git push origin --tags
env -i nuget pack ./Alldigit.IG.TradingFacade.nuspec -Version $newVersion -IncludeReferencedProjects -Prop Configuration=Release
env -i nuget push ./*.nupkg $NUGET_API_KEY -Source https://www.nuget.org/api/v2/package