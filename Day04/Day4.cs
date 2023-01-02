using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

var lines = File.ReadAllLines("input.txt");
int total = 0;
for(int i = 0; i < lines.Length; i++)
{
	var a = lines[i].Split(",");
	var b = a[0].Split('-');
	var c = a[1].Split('-');
	var n1 = int.Parse(b[0]);
	var n2 = int.Parse(b[1]);
	var n3 = int.Parse(c[0]);
	var n4 = int.Parse(c[1]);
	//if((n1 >= n3 && n2 <= n4) || (n3 >= n1 && n4 <= n2)) 
	//	total++;
	//p2
	if((n1 >= n3 && n1 <= n4) || (n2 >= n3 && n2 <= n4) || (n3 >= n1 && n3 <= n2) || (n4 >= n1 && n4 <= n2))
		total++;
}
Console.WriteLine($"P2 {total}");