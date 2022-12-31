//string[] text = File.ReadAllLines("input.txt");
//List<(int, int)> toadd = new();
//int cycle = 0;
//int x = 1;
//int result = 0;
//char[,] image = new char[40, 6];

//for(int i = 0; i < text.Length; i++)
//{
//	if(i < text.Length)
//	{
//		if(text[i] == "noop")
//		{
//			cycle++;
//			Tick(cycle);
//			continue;
//		}
//		var s = text[i].Split(' ');
//		toadd.Add((int.Parse(s[1]), 1));
//		cycle++;
//		Tick(cycle);
//		cycle++;
//		Tick(cycle);
//	}
//	while(toadd.Count>0)
//	{
//		cycle++;
//		Tick(cycle);
//	}
//}

//void Tick(int i)
//{
//	if(i == 20 || i == 60 || i == 100 || i == 140 || i == 180 || i == 220)
//	{
//		result += x * i;
//	}
//	if(toadd.Count > 0)
//	{
//		for(int j = 0; j < toadd.Count; j++)
//		{
//			toadd[j] = (toadd[j].Item1, toadd[j].Item2 - 1);
//		}
//		if(toadd[0].Item2 <= -1)
//		{
//			x += toadd[0].Item1;
//			toadd.RemoveAt(0);
//		}
//	}

//	if(i < 240)
//	{
//		var pos = (i % 40, i / 40);
//		var mid = (x % 40, i / 40);
//		var left = x - 1 > -1 ? ((x - 1) % 40, i / 40) : mid;
//		var right =x + 1 < 40 ?  ((x + 1) % 40, i / 40) : mid;
//		if(pos == left || pos == mid || pos == right)
//		{
//			image[pos.Item1, pos.Item2] = '#';
//		}
//		else
//		{
//			image[pos.Item1, pos.Item2] = '.';
//		}
//	}
//	int asd = 0;
//}

//for(int i = 0; i < 6; i++)
//{
//	for(int j = 0; j < 40; j++)
//	{
//		Console.Write(image[j, i]);
//	}
//	Console.Write('\n');
//}
//Console.
//(result);