all:	TestBisect TestWF

TEMPORARY = Bisect.cs

TESTS = TestBisect TestWF

Bisect.cs:	Bisect.cspp
	cpp -P $< > $@

TestBisect:	TestBisect.cs Bisect.cs
	./compile TestBisect.cs Bisect.cs

TestWF:	TestWF.cs MyUtil.cs
	./compile $^

clean:
	rm -f $(TEMPORARY) $(TESTS)

check:	$(TESTS)
	./run-test.sh $(TESTS)

