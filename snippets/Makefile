TEMPORARY = Bisect.cs
TESTS = TestBisect TestWF TestNextPermutation TestPriorityQueue

all:	$(TESTS)

Bisect.cs:	Bisect.cspp
	cpp -P $< > $@

TestBisect:	TestBisect.cs Bisect.cs
	./compile TestBisect.cs Bisect.cs

TestWF:	TestWF.cs MyUtil.cs
	./compile $^

TestNextPermutation: TestNextPermutation.cs MyUtil.cs genperm.cpp
	g++ -o genperm genperm.cpp
	./genperm > testperm.txt
	./compile TestNextPermutation.cs MyUtil.cs

TestPriorityQueue: TestPriorityQueue.cs MyUtil.cs PriorityQueue.cs
	./compile TestPriorityQueue.cs MyUtil.cs PriorityQueue.cs

clean:
	rm -f $(TEMPORARY) $(TESTS)

check:	$(TESTS)
	./run-test.sh $(TESTS)

