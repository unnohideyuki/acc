class FordFulkerson
{
    class Edge {
	public int to, cap, rev;
	public Edge(int _to, int _cap, int _rev)
	{
	    to = _to; cap = _cap; rev = _rev;
	}
    }

    List<Edge>[] G;
    bool[] used;
    int MAX_V;

    public void AddEdge(int from, int to, int cap)
    {
	G[from].Add(new Edge(to, cap, G[to].Count));
	G[to].Add(new Edge(from, 0, G[from].Count - 1));
    }
    
    int dfs (int v, int t, int f)
    {
	if (v == t) return f;
	used[v] = true;
	for (int i = 0; i < G[v].Count; i++)
	{
	    Edge e = G[v][i];
	    if (!used[e.to] && e.cap > 0)
	    {
		int d = dfs(e.to, t, Math.Min(f, e.cap));
		if (d > 0)
		{
		    e.cap -= d;
		    G[e.to][e.rev].cap += d;
		    return d;
		}
	    }
	}
	return 0;
    }

    public int MaxFlow(int s, int t)
    {
	int flow = 0;
	
	while (true)
	{
	    for (int i = 0; i < MAX_V; i++)
		used[i] = false;
	    
	    int f = dfs(s, t, 1000000000);
	    if (f == 0) return flow;
	    flow += f;
	}
    }

    public FordFulkerson(int maxv)
    {
	MAX_V = maxv;
	G = new List<Edge>[MAX_V];
	for (int i = 0; i < MAX_V; i++)
	    G[i] = new List<Edge>();

	used = new bool[MAX_V];
    }
}
