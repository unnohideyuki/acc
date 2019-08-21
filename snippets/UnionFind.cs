class UnionFind
{
    private int[] d;

    public UnionFind(int n)
    {
	d = new int[n];
	for (int i = 0; i < n; i++){ d[i] = -1; }
    }

    public int Find(int x)
    {
	if (d[x] < 0){ return x; }
	return d[x] = Find(d[x]);
    }

    public void Unite(int x, int y)
    {
	x = Find(x); y = Find(y);
	if (x == y){ return; }
	if (d[x] > d[y]){ Swap(ref x, ref y); }
	d[x] += d[y];
	d[y] = x;
    }

    public bool Same(int x, int y){ return Find(x) == Find(y); }
    public int Size(int x){ return -d[Find(x)]; }
}

