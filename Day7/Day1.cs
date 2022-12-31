using System.Collections.Generic;
using UnityEngine;

public class Day1 : MonoBehaviour
{
    List<int> totals = new();
    string[] strings;
    // Start is called before the first frame update
    void Start()
    {
		var text = (Resources.Load("input") as TextAsset).text;

		strings = text.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
        for(int i = 0; i < strings.Length; i++)
        {
            var nums = strings[i].Split("\n");
            int currentTotal = 0;
            foreach( var n in nums)
            {
                int.TryParse(n, out var result);
                currentTotal += result;
            }
            totals.Add(currentTotal);
        }
        var max = float.MinValue;
        for(int i = 0; i < totals.Count; i++)
        {
            if(totals[i] > max)
            {
                max = totals[i];
            }
        }
        totals.Sort();
        var end = totals.Count - 1;
        Debug.Log(totals[end] + totals[end-1] + totals[end-2]);
    }

}
