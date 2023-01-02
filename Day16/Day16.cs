//Input formatted to remove useless text
//Very slow solution unfortunately but I did run it to completion to get the correct answer. Better solutions 
//had the elephant go after the player sequentially, resetting the time and going back to AA. Might run in under an hour on a
//good computer but I don't remember
using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		const int INF = 99999;
		string[] text = File.ReadAllLines("input.txt");

		Dictionary<string, int> valveIndices = new();
		Dictionary<int, int> pressures = new();
		Dictionary<int, List<int>> connections = new();

		List<int> goodValves = new();

		int highestPressure = 0;

		int[,] vertices;

		for(int i = 0; i < text.Length; i++)
		{
			var s = text[i].Split(' ');
			valveIndices[s[0]] = i;
			//valveNames[i] = BitConverter.ToInt32();
			pressures.Add(i, int.Parse(s[1]));
			if(int.Parse(s[1]) > 0)
			{
				goodValves.Add(i);
			}
		}
		for(int i = 0; i < text.Length; i++)
		{
			var s = text[i].Split(' ');

			connections.Add(i, new List<int>());
			for(int j = 2; j < s.Length; j++)
			{
				connections[i].Add(valveIndices[s[j]]);
			}
		}

		vertices = new int[pressures.Count, pressures.Count];
		//setup algo array, 0 dist to self, else inf distance
		for(int i = 0; i < vertices.GetLength(0); i++)
		{
			for(int j = 0; j < vertices.GetLength(1); j++)
			{
				if(i == j)
				{
					vertices[i, j] = 0;
				}
				else
				{
					vertices[i, j] = INF;
				}
			}
		}
		//fill in distance of 1 for connections
		for(int i = 0; i < connections.Count; i++)
		{
			for(int j = 0; j < connections[i].Count; j++)
			{
				vertices[i, connections[i][j]] = 1;
			}
		}

		FloydWarshall(pressures.Count, vertices);

		int maxTime = 26;
		//Stack<int> path = new();


		int[] newPath = new int[100];
		newPath[0] = valveIndices["AA"];
		int newPathLengthM1 = 0;

		//Stack<int> elephantPath = new();

		int[] newElephantPath = new int[100];
		newElephantPath[0] = valveIndices["AA"];
		int newElephantPathLengthM1 = 0;

		Stack<int> minutes = new();
		Stack<int> elephantMinutes = new();
		Stack<int> currentPressures = new();

		Stack<bool> playerOrElephant = new();

		HashSet<(int, int, int)> memoPlayer = new();
		HashSet<(int, int, int)> memoElephant = new();
		//path.Push(valveIndices["AA"]);
		//elephantPath.Push(valveIndices["AA"]);
		minutes.Push(0);
		elephantMinutes.Push(0);
		currentPressures.Push(0);

		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Solve();
		stopwatch.Stop();
		Console.WriteLine(stopwatch.ElapsedMilliseconds);
		Console.WriteLine(highestPressure);
		Console.ReadLine();
		File.WriteAllText("result.txt", highestPressure.ToString());


		//Array.LastIndexOf(_array, item, _size - 1) != -1

		void Solve()
		{

			for(int i = 0; i < goodValves.Count; i++)
			{
				for(int j = 0; j < 2; j++)
				{
					if(j == 0) //idk what to do if they are equal
					{
						if(Array.LastIndexOf(newPath, goodValves[i], newPathLengthM1) == -1 &&
								Array.LastIndexOf(newElephantPath, goodValves[i], newElephantPathLengthM1) == -1)
						{
							var dist = vertices[newPath[newPathLengthM1], goodValves[i]];
							if(minutes.Peek() + dist + 1 < maxTime)
							{
								playerOrElephant.Push(true);
								minutes.Push(minutes.Peek() + dist + 1);
								currentPressures.Push(currentPressures.Peek() + pressures[goodValves[i]] * (maxTime - minutes.Peek()));

								newPathLengthM1++;
								newPath[newPathLengthM1] = goodValves[i];

								if(currentPressures.Peek() > highestPressure)
								{
									highestPressure = currentPressures.Peek();
								}
								Solve();
							}
						}
					}
					else
					{
						if(Array.LastIndexOf(newPath, goodValves[i], newPathLengthM1) == -1 &&
								Array.LastIndexOf(newElephantPath, goodValves[i], newElephantPathLengthM1) == -1)
						{
							var dist = vertices[newElephantPath[newElephantPathLengthM1], goodValves[i]];
							if(elephantMinutes.Peek() + dist + 1 < maxTime)
							{
								playerOrElephant.Push(false);
								elephantMinutes.Push(elephantMinutes.Peek() + dist + 1);
								currentPressures.Push(currentPressures.Peek() + pressures[goodValves[i]] * (maxTime - elephantMinutes.Peek()));

								newElephantPathLengthM1++;
								newElephantPath[newElephantPathLengthM1] = goodValves[i];

								if(currentPressures.Peek() > highestPressure)
								{
									highestPressure = currentPressures.Peek();
								}
								Solve();
							}
						}
					}

				}
			}

			if(playerOrElephant.Count > 0)
			{
				var which = playerOrElephant.Pop();
				if(which)
				{
					newPathLengthM1--;
					if(minutes.Count > 0)
						minutes.Pop();
				}
				else
				{

					newElephantPathLengthM1--;
					if(elephantMinutes.Count > 0)
						elephantMinutes.Pop();
				}
				currentPressures.Pop();
			}

		}

		static void FloydWarshall(int numVertices, int[,] distances)
		{
			for(int k = 0; k < numVertices; k++)
			{
				for(int i = 0; i < numVertices; i++)
				{
					for(int j = 0; j < numVertices; j++)
					{
						// Check if going through vertex k is shorter
						if(distances[i, j] > distances[i, k] + distances[k, j])
						{
							// Update the distance between i and j
							distances[i, j] = distances[i, k] + distances[k, j];
						}
					}
				}
			}
		}
	}
}