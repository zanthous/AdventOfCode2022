using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Day3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var text = (Resources.Load("input3") as TextAsset).text;
		var lines = text.Split("\n");
        int total = 0;
        //p1
        //     for(int i = 0; i < lines.Length; i++)
        //     {
        //         if(lines[i].Length < 2)
        //             continue;
        //         var s1 = lines[i].Substring(0, lines[i].Length / 2);
        //var s2 = lines[i].Substring(lines[i].Length / 2);

        //         var dupe = s1.Intersect(s2);
        //         total += GetPriority(dupe.First());
        //     }

        //p2

        //this must be stupidly slow lol
        for(int i = 0; i < lines.Length; i+=3)
        {
            if(lines[i] == "") continue;
			var result = lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]);
            total += GetPriority(result.First());
        }
        Debug.Log("day 3: " + total);
	}

    int GetPriority(char c)
    {
        return c > 96 ? c - 96 : c - 38;
    }

}
