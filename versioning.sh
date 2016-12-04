LATEST_TAG=$(git describe --tags `git rev-list --tags --max-count=1`)
IFS='.' read -r -a PARSED <<< "$LATEST_TAG"

latestMajor=${PARSED[0]}
latestMinor=${PARSED[1]}
latestRevision=${PARSED[2]}

newMajor=$1
newMinor=$2 
newRevision=0

if [ $newMajor == $latestMajor ] && [ $newMinor == $latestMinor ]; then
    newRevision=$(($latestRevision+1))
fi

echo $newMajor"."$newMinor"."$newRevision