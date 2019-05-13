all:	TestBisect

TEMPORARY = Bisect.cs

TESTS = TestBisect

Bisect.cs:	Bisect.cspp
	cpp -P $< > $@

TestBisect:	TestBisect.cs Bisect.cs
	./compile -out $@ TestBisect.cs Bisect.cs

clean:
	rm -f $(TEMPORARY) $(TESTS)

check:	$(TESTS)
	./run-test.sh $(TESTS)

