bool debug = false;
var text = File.ReadAllText("input.txt").Split("\r\n");

//presimulate n rounds, so I can just store where the path exists and treat blizzard squares as nonexistant

//x, y, char
List<(int, int, char)> wind = new();
const int preSimulate = 1000;
//minute y x
char[][,] level = new char[preSimulate][,];
int width = text[0].Length;
int height = text.Length;

for(int y = 0; y < height; y++)
{
	for(int x = 0; x < width; x++)
	{
		if(text[y][x] != '.' && text[y][x] != 'S' && text[y][x] != 'G' && text[y][x] != '#')
		{
			wind.Add((x, y, text[y][x]));
		}
	}
}

for(int i = 0; i < preSimulate; i++)
{
	level[i] = new char[width, height];

	for(int w = 0; w < wind.Count; w++)
	{
		if(wind[w].Item3 == '>')
		{
			if(wind[w].Item1 == width - 2)
			{
				wind[w] = (1, wind[w].Item2, wind[w].Item3);
			}
			else
			{
				wind[w] = (wind[w].Item1 + 1, wind[w].Item2, wind[w].Item3);
			}
		}
		else if(wind[w].Item3 == '<')
		{
			if(wind[w].Item1 == 1)
			{
				wind[w] = (width - 2, wind[w].Item2, wind[w].Item3);
			}
			else
			{
				wind[w] = (wind[w].Item1 - 1, wind[w].Item2, wind[w].Item3);
			}
		}
		else if(wind[w].Item3 == '^')
		{
			if(wind[w].Item2 == 1)
			{
				wind[w] = (wind[w].Item1, height - 2, wind[w].Item3);
			}
			else
			{
				wind[w] = (wind[w].Item1, wind[w].Item2 - 1, wind[w].Item3);
			}
		}
		else if(wind[w].Item3 == 'v')
		{
			if(wind[w].Item2 == height - 2)
			{
				wind[w] = (wind[w].Item1, 1, wind[w].Item3);
			}
			else
			{
				wind[w] = (wind[w].Item1, wind[w].Item2 + 1, wind[w].Item3);
			}
		}
	}
	for(int y = 0; y < height; y++)
	{
		for(int x = 0; x < width; x++)
		{
			if(x == 0 || x == width - 1 || y == 0 || y == height - 1)
			{
				level[i][x, y] = '#';
			}
			else
			{
				level[i][x, y] = '.';
			}
		}
	}
	level[i][1, 0] = '.';
	level[i][width - 2, height - 1] = '.';
	foreach(var ww in wind)
	{
		level[i][ww.Item1, ww.Item2] = '#';
	}
}


var result = BreadthFirstSearch((1, 0, 0), (width - 2, height - 1));
var result2 = BreadthFirstSearch((width - 2, height - 1, result.Count), (1, 0));
var result3 = BreadthFirstSearch((1, 0, result.Count + result2.Count), (width - 2, height - 1));

Console.WriteLine(result.Count + result2.Count + result3.Count);

if(debug)
{
	for(int i = 0; i < 19; i++)
	{
		Print(i);
		Console.WriteLine();
		Console.WriteLine();
		Console.WriteLine();
	}
}
List<(int, int, int)> BreadthFirstSearch((int, int, int) start, (int, int) goal)
{
	Queue<(int, int, int)> queue = new();
	queue.Enqueue(start);

	//x, y, time
	Dictionary<(int, int, int), (int, int, int)> cameFrom = new();
	cameFrom[(start.Item1, start.Item2, start.Item3)] = start;

	while(queue.Count > 0)
	{
		var current = queue.Dequeue();
		if((current.Item1, current.Item2) == goal)
		{
			return GetPath(cameFrom, (goal.Item1, goal.Item2, current.Item3));
		}
		else
		{
			foreach(var neighbor in GetNeighbors(current))
			{
				if(!cameFrom.ContainsKey(neighbor))
				{
					cameFrom[neighbor] = current;
					queue.Enqueue(neighbor);
				}
			}
		}
	}

	return null; // Goal not found
}

List<(int, int, int)> GetPath(Dictionary<(int, int, int), (int, int, int)> cameFrom, (int, int, int) goal)
{
	List<(int, int, int)> path = new();
	var current = goal;
	while(current != cameFrom[current])
	{
		path.Add(current);
		current = cameFrom[current];
	}
	path.Add(current); // Add the starting (int, int)
	path.Reverse(); // Reverse the list to get the path in the correct order
	return path;
}

List<(int, int, int)> GetNeighbors((int, int, int) position)
{
	// Return a list of the neighboring (int, int)s for the given (int, int)
	//check in + shape
	List<(int, int, int)> neighbors = new();
	if(level[position.Item3 + 1][position.Item1, position.Item2] == '.')
	{
		neighbors.Add((position.Item1, position.Item2, position.Item3 + 1));
	}
	if(position.Item1 + 1 < width && level[position.Item3 + 1][position.Item1 + 1, position.Item2] == '.')
	{
		neighbors.Add((position.Item1 + 1, position.Item2, position.Item3 + 1));
	}
	if(position.Item1 - 1 > -1 && level[position.Item3 + 1][position.Item1 - 1, position.Item2] == '.')
	{
		neighbors.Add((position.Item1 - 1, position.Item2, position.Item3 + 1));
	}
	if(position.Item2 + 1 < height && level[position.Item3 + 1][position.Item1, position.Item2 + 1] == '.')
	{
		neighbors.Add((position.Item1, position.Item2 + 1, position.Item3 + 1));
	}
	if(position.Item2 - 1 > -1 && level[position.Item3 + 1][position.Item1, position.Item2 - 1] == '.')
	{
		neighbors.Add((position.Item1, position.Item2 - 1, position.Item3 + 1));
	}
	return neighbors;
}

void Print(int time)
{
	if(!debug) return;

	for(int y = 0; y < height; y++)
	{
		for(int x = 0; x < width; x++)
		{
			Console.Write(level[time][x, y]);
		}
		Console.WriteLine();
	}
}