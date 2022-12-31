using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Helper;
internal class AOC
{
	static void Main(string[] args)
	{
		var text = File.ReadAllText("input.txt");
		int size = 14;
		FixedQueue<char> chars = new () { Limit = size };
		for(int i = 0; i < text.Length; i++)
		{
			chars.Enqueue(text[i]);
			if(chars.q.Count == size && chars.q.Distinct().Count() == size)
			{
				Console.WriteLine("P2");
				Console.WriteLine(i + 1);
				break;
			}
		}
	}
}