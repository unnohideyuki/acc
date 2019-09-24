class RollingHash
{
    ulong[] h;
    ulong[] power;
    
    public RollingHash(string s, ulong b)
    {
	int sz = s.Length;
	h = new ulong[sz + 1];
	power = new ulong[sz + 1];
	power[0] = 1;
	for (int i = 0; i < sz; i++)
	{
	    power[i + 1] = power[i] * b;
	    h[i + 1] = h[i] * b + s[i];
	}
    }

    public ulong get(int l, int r)
    {
	return h[r] - power[r - l] * h[l];
    }
}
