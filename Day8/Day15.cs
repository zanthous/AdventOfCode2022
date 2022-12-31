
//using System;
//using System.Xml.Linq;
//using Clipper2Lib;


//string[] text = File.ReadAllLines("input.txt");
//List<(int, int)> sensors = new();
//List<(int, int)> closestBeacons = new();
//List<int> distances = new();

//HashSet<(int, int)> beacons = new();

//for(int i = 0; i < text.Length; i++)
//{
//	var r =text[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
//	sensors.Add((int.Parse(r[0]), int.Parse(r[1])));
//	var b = (int.Parse(r[2]), int.Parse(r[3]));
//	closestBeacons.Add(b);
//	beacons.Add(b);
//}

//for(int i = 0; i < sensors.Count; i++)
//{
//	distances.Add(Dist(sensors[i], closestBeacons[i]));
//}

//static int Dist((int,int) sensor, (int,int) beacon)
//{
//	// calculate the Manhattan distance to the goal
//	return Math.Abs(sensor.Item1 - beacon.Item1) + Math.Abs(sensor.Item2 - beacon.Item2);
//}
//int xMin = int.MaxValue;
//int xMax = int.MinValue;

//for(int i = 0; i < sensors.Count; i++)
//{
//	xMax = Math.Max(Math.Max(xMax, closestBeacons[i].Item1), sensors[i].Item1);
//	xMin = Math.Min(Math.Min(xMin, closestBeacons[i].Item1), sensors[i].Item1);
//}

//List<List<(int, int)>> rhombi = new();
//for(int i = 0; i < distances.Count; i++)
//{
//	rhombi.Add(new List<(int, int)>());

//	rhombi[rhombi.Count - 1].Add(new(sensors[i].Item1 + distances[i], sensors[i].Item2));
//	rhombi[rhombi.Count - 1].Add(new(sensors[i].Item1 - distances[i], sensors[i].Item2));
//	rhombi[rhombi.Count - 1].Add(new(sensors[i].Item1,				  sensors[i].Item2 + distances[i]));
//	rhombi[rhombi.Count - 1].Add(new(sensors[i].Item1,				  sensors[i].Item2 - distances[i]));
//}

//int max = 4000000;

//for(int i = 0; i < rhombi.Count; i++)
//{
//	for(int j = 0; j < rhombi[i].Count -1; j++)
//	{
//		if(rhombi[i][j].Item1 > (max-1) || rhombi[i][j].Item1 < 1 ||
//			rhombi[i][j].Item2 > (max-1) || rhombi[i][j].Item2 < 1) continue;
//		var curPos = rhombi[i][j];
//		(int, int) dir = GetDir(rhombi[i][j], rhombi[i][j+1]);
//		while(curPos != rhombi[i][j+1])
//		{ 
//			var r = Check8(curPos);
//			if(r!=(-1,-1) && r.Item2 > -1 && r.Item2 <= max && r.Item1 > -1 && r.Item1 <= max)
//			{
//				Console.WriteLine($"{r.Item1} {r.Item2}");
//			}
//			curPos = (curPos.Item1 + dir.Item1, curPos.Item2 + dir.Item2);
//		}
//	}
//}

//(int,int) GetDir((int,int) one, (int,int) two)
//{
//	return (Math.Clamp(two.Item1 - one.Item1, -1, 1), Math.Clamp(two.Item2 - one.Item2, -1, 1));
//}

//(int, int) Check8((int,int) point)
//{
//	int[] xOff = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 };
//	int[] yOff = new int[8] { 1, 1, 1, 0, 0, -1, -1, -1 };

//	for(int i = 0; i < 8; i++)
//	{
//		var p = (point.Item1 + xOff[i], point.Item2 + yOff[i]);
//		bool result = true;
//		for(int j = 0; j < sensors.Count; j++)
//		{
//			if(Dist(sensors[j], p) <= distances[j])
//			{
//				result = false;
//				break;
//			}
//		}
//		if(result)
//		{
//			return p;
//		}
//	}
//	return (-1, -1);
//}