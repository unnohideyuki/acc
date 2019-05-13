#!/bin/bash
i=0;
for t in $*
do
    echo -n "$t ... "
    ./$t
    if [ $? -eq 0 ]; then
	echo done.
	i=`expr $i \+ 1`
    else
	echo failed!
	exit 1
    fi
done

echo ================
echo $i tests passed.
echo ================
