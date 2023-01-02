using System.Collections.Generic;

List<int> totals = new();

var text = File.ReadAllText("input.txt");

var strings = text.Split(new string[] { "\r\n\r\n" }, System.StringSplitOptions.None);

for(int i = 0; i < strings.Length; i++)
{
	var nums = strings[i].Split("\n");
	int currentTotal = 0;
	foreach(var n in nums)
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
Console.WriteLine("Part 2 solution");
Console.WriteLine(totals[end] + totals[end - 1] + totals[end - 2]);
