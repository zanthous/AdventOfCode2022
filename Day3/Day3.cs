var lines = File.ReadAllLines("input.txt");
int total1 = 0;

for(int i = 0; i < lines.Length; i++)
{
    if(lines[i].Length < 2)
        continue;
    var s1 = lines[i].Substring(0, lines[i].Length / 2);
    var s2 = lines[i].Substring(lines[i].Length / 2);

    var dupe = s1.Intersect(s2);
    total1 += GetPriority(dupe.First());
}
Console.WriteLine($"P1 {total1}");


//p2
int total2 = 0;
for(int i = 0; i < lines.Length; i += 3)
{
	if(lines[i] == "") continue;
	var result = lines[i].Intersect(lines[i + 1]).Intersect(lines[i + 2]);
	total2 += GetPriority(result.First());
}

int GetPriority(char c)
{
	return c > 96 ? c - 96 : c - 38;
}

Console.WriteLine($"P2 {total2}");