IFS='.' read -r -a PARSED <<< "$LATEST_TAG"

latestMajor=${PARSED[0]}
latestMinor=${PARSED[1]}
latestRevision=${PARSED[2]}
newRevision=0

if [ $MAJOR == $latestMajor ] && [ $MINOR == $latestMinor ]; then
    newRevision=$(($latestRevision+1))
fi

newVersion=$MAJOR"."$MINOR"."$newRevision

env -i git config --global user.email "builds@travis-ci.com"
env -i git config --global user.name "Travis CI"
env -i git tag $newVersion
env -i git push origin --tags
env -i nuget pack ./Alldigit.IG.TradingFacade.nuspec -Version $newVersion -IncludeReferencedProjects -Prop Configuration=Release
env -i nuget push ./*.nupkg $NUGET_API_KEY -Source https://www.nuget.org/api/v2/package

