using System.Text.RegularExpressions;

var text = File.ReadAllLines("input.txt");

//parse manually
//List<char>[] boxes = new List<char>[9];
//for(int i = 0; i < boxes.Length; i++)
//{
//	boxes[i] = new List<char>();
//}

//for(int i = 0; i < 8; i++)
//{
//	for(int j = 1; j < text[i].Length; j += 4)
//	{
//		if(text[i][j] != ' ')
//			boxes[j / 4].Insert(0, text[i][j]);
//	}
//}


//write input data
var boxes = new List<char>[]
{
	new List<char>("HBVWNMLP"),
	new List<char>("MQH"),
	new List<char>("NDBGFQML"),
	new List<char>("ZTFQMWG"),
	new List<char>("MTHP"),
	new List<char>("CBMJDHGT"),
	new List<char>("MNBFVR"),
	new List<char>("PLHMRGS"),
	new List<char>("PDBCN")
};


for(int i = 10; i < text.Length; i++)
{
	MatchCollection matches = Regex.Matches(text[i], @"\d+");

	var toMove = int.Parse(matches[0].Value);
	var from = int.Parse(matches[1].Value) - 1;
	var to = int.Parse(matches[2].Value) - 1;

	boxes[to].AddRange(boxes[from].Skip(boxes[from].Count - toMove));
	boxes[from].RemoveRange(boxes[from].Count - toMove, toMove);
}

string s = "";
for(int i = 0; i < boxes.Length; i++)
{
	s += boxes[i].Last();
}
Console.WriteLine("p2");
Console.WriteLine(s);
