#include <bits/stdc++.h>
#include <algorithm>
using namespace std;

int main()
{
  int a[] = {1, 2, 3, 5, 8, 13, 21};
  do
    cout << a[0] << a[1] << a[2] << a[3] << a[4] << a[5] << a[6] << endl;
  while (next_permutation(a, a+7));
}
