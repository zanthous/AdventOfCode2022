// Start is called before the first frame update
Dictionary<string, int> scores = new Dictionary<string, int>()
	{
		{"A X",  3+1},
		{"A Y",  6+2},
		{"A Z",  0+3},

		{"B X",  0+1},
		{"B Y",  3+2},
		{"B Z",  6+3},

		{"C X",  6+1},
		{"C Y",  0+2},
		{"C Z",  3+3},
		{"\n", 0 },
		{"", 0 }
	};

Dictionary<string, int> scores2 = new Dictionary<string, int>()
	{
		{"A X",  0+3},
		{"A Y",  3+1},
		{"A Z",  6+2},

		{"B X",  0+1},
		{"B Y",  3+2},
		{"B Z",  6+3},

		{"C X",  0+2},
		{"C Y",  3+3},
		{"C Z",  6+1},
		{"\n", 0 },
		{"", 0 }
	};

var text = File.ReadAllText("input.txt");
var lines = text.Split("\r\n");
int total = 0;

for(int i = 0; i < lines.Length; i++)
{
	total += scores2[lines[i]];
}

Console.WriteLine("Part 2 solution");
Console.WriteLine(total);
