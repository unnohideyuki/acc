#!/bin/sh
# -*- mode:Shell -*-

which scs > /dev/null
if [ $? -eq 0 ]; then
  compiler="scs"
fi

which mcs > /dev/null
if [ $? -eq 0 ]; then
    compiler="mcs"
else
    echo "compiler, scs or mcs, not found."
    exit 1;
fi

cmd="$compiler $1"
echo $cmd
$cmd
