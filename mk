#!/bin/sh
# -*- mode:Shell -*-

which csc > /dev/null
if [ $? -eq 0 ]; then
  compiler="csc"
else
    which mcs > /dev/null
    if [ $? -eq 0 ]; then
	compiler="mcs"
    else
	echo "compiler, scs or mcs, not found."
	exit 1;
    fi
fi

cmd="$compiler $1"
echo $cmd
$cmd
