using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Day4 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		var text = (Resources.Load("input4") as TextAsset).text;
		var lines = text.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
		int total = 0;
		for(int i = 0; i < lines.Count; i++)
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
		Debug.Log("Day 4: " + total);
	}
}
