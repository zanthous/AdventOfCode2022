using System.Numerics;
using System.Security.Cryptography;

string[] text = File.ReadAllLines("input.txt");

char[,] level;

List<List<(int, int)>> allLines = new();


int xMin, xMax, yMin, yMax;
xMax = int.MinValue;
xMin = int.MaxValue;
yMin = int.MaxValue;
yMax = int.MinValue;

//Vector2 a = new Vector2()
//todo find yMin and yMax, xMin xMax

for(int i = 0; i < text.Length; i++)
{
	var coords = text[i].Split(" -> ");
	allLines.Add(new List<(int, int)>());
	for(int j = 0; j < coords.Length; j++)
	{
		var v1 = coords[j].Split(",");
		//var v2 = coords[j+1].Split(",");
		var p1 = (int.Parse(v1[0]), int.Parse(v1[1]));
		//var p2 = (int.Parse(v2[0]) - 458, int.Parse(v2[1]) - 13);
		allLines[i].Add(p1);
	}
}
for(int i = 0; i < allLines.Count; i++)
{
	for(int j = 0; j < allLines[i].Count; j++)
	{
		xMin = Math.Min(xMin, allLines[i][j].Item1);
		xMax = Math.Max(xMax, allLines[i][j].Item1);
		yMax = Math.Max(yMax, allLines[i][j].Item2);
		yMin = Math.Min(yMin, allLines[i][j].Item2);
	}
}

//Console.WriteLine(xMin);
//Console.WriteLine(xMax);
//Console.WriteLine(yMin);
//Console.WriteLine(yMax);
yMax += 2;

int size = 1000;
level = new char[size, size];

for(int i = 0; i < size * size; i++)
{
	level[(i % size), (i / size)] = '.';
}

for(int i = 0; i < allLines.Count; i++)
{
	for(int j = 0; j < allLines[i].Count - 1; j++)
	{
		var p1 = allLines[i][j];
		var p2 = allLines[i][j + 1];
		level[p1.Item1, p1.Item2] = '#';
		level[p2.Item1, p2.Item2] = '#';
		(int, int) dir;
		dir = Dir(p1, p2);
		while(dir != (0, 0))
		{
			p1 = (p1.Item1 + dir.Item1, p1.Item2 + dir.Item2);
			level[p1.Item1, p1.Item2] = '#';
			dir = Dir(p1, p2);
		}
	}
}
level[500, 0] = '+';
for(int i = 0; i < size; i++)
{
	level[i, yMax] = '#';
}
yMax++;

bool exit = false;
(int, int) sandPos = (500, 0);
int resting = 0;
while(!exit)
{
	level[500, 0] = 'O';
	sandPos = (500, 0);
	while(!TickSand())
	{

	}
}

OutputLevel();
Console.WriteLine(resting);

bool TickSand()
{
	//if(sandPos.Item2 > yMax)
	//{
	//	exit = true;
	//	return true;
	//}
	if(TestAndChange((sandPos.Item1, sandPos.Item2 + 1)) ||
		TestAndChange((sandPos.Item1 - 1, sandPos.Item2 + 1)) ||
		TestAndChange((sandPos.Item1 + 1, sandPos.Item2 + 1)))
	{
		return false;
	}
	else
	{
		if(sandPos.Item1 == 500 && sandPos.Item2 == 0) exit = true;
		level[sandPos.Item1, sandPos.Item2] = 'R';
		resting++;
		return true;
	}
}

bool TestAndChange((int, int) newPos)
{
	if(level[newPos.Item1, newPos.Item2] == '.')
	{
		level[sandPos.Item1, sandPos.Item2] = '.';
		level[newPos.Item1, newPos.Item2] = 'O';
		sandPos = newPos;
		return true;
	}
	return false;
}

static (int, int) Dir((int, int) left, (int, int) right)
{
	if(right.Item1 > left.Item1)
		return (1, 0);
	if(right.Item1 < left.Item1)
		return (-1, 0);
	if(right.Item2 > left.Item2)
		return (0, 1);
	if(right.Item2 < left.Item2)
		return (0, -1);

	return (0, 0);
}

void OutputLevel()
{
	byte[] result = new byte[size * size + size];
	for(int i = 0; i < (size + 1) * size; i++)
	{
		if(i % (size + 1) == size)
		{
			result[i] = (byte) '\n';
		}
		else
		{
			result[i] = (byte) level[i % (size + 1), i / (size + 1)];
		}
	}
	File.WriteAllBytes("output.txt", result);
}