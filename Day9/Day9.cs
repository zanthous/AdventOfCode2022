//List<(int, int)> knots = new List<(int, int)>();

//knots.AddRange(new (int, int)[10]);

//Dictionary<(int, int), bool> dict = new Dictionary<(int, int), bool>();

//var text = File.ReadAllLines("input.txt");

//dict.Add(knots[^1], true);

//for(int i = 0; i < text.Length; i++)
//{
//	var split = text[i].Split(' ');
//	var move = int.Parse(split[1]);

//	if(text[i][0] == 'U')
//	{
//		for(int j = 0; j < move; j++)
//		{
//			knots[0] = (knots[0].Item1, knots[0].Item2 + 1);
//			for(int k = 1; k < knots.Count; k++)
//			{
//				knots[k] = MoveKnot(knots[k - 1], knots[k]);
//			}

//			if(!dict.ContainsKey(knots[^1]))
//			{
//				dict.Add(knots[^1], true);
//			}
//		}

//	}
//	else if(text[i][0] == 'D')
//	{
//		for(int j = 0; j < move; j++)
//		{
//			knots[0] = (knots[0].Item1, knots[0].Item2 - 1);
//			for(int k = 1; k < knots.Count; k++)
//			{
//				knots[k] = MoveKnot(knots[k - 1], knots[k]);
//			}

//			if(!dict.ContainsKey(knots[^1]))
//			{
//				dict.Add(knots[^1], true);
//			}
//		}
//	}
//	else if(text[i][0] == 'L')
//	{
//		for(int j = 0; j < move; j++)
//		{
//			knots[0] = (knots[0].Item1 - 1, knots[0].Item2);
//			for(int k = 1; k < knots.Count; k++)
//			{
//				knots[k] = MoveKnot(knots[k - 1], knots[k]);
//			}

//			if(!dict.ContainsKey(knots[^1]))
//			{
//				dict.Add(knots[^1], true);
//			}
//		}
//	}
//	else if(text[i][0] == 'R')
//	{
//		for(int j = 0; j < move; j++)
//		{
//			knots[0] = (knots[0].Item1 + 1, knots[0].Item2);
//			for(int k = 1; k < knots.Count; k++)
//			{
//				knots[k] = MoveKnot(knots[k - 1], knots[k]);
//			}

//			if(!dict.ContainsKey(knots[^1]))
//			{
//				dict.Add(knots[^1], true);
//			}
//		}
//	}
//}

//Console.WriteLine(dict.Count);

//(int, int) MoveKnot((int, int) head, (int, int) tail)
//{
//	if(Touching(head, tail))
//	{
//		if(head.Item1 - tail.Item1 > 1) tail = (tail.Item1 + 1, tail.Item2);
//		if(head.Item1 - tail.Item1 < -1) tail = (tail.Item1 - 1, tail.Item2);

//		if(head.Item2 - tail.Item2 > 1) tail = (tail.Item1, tail.Item2 + 1);
//		if(head.Item2 - tail.Item2 < -1) tail = (tail.Item1, tail.Item2 - 1);
//	}
//	else
//	{
//		var offset = (Math.Sign(head.Item1 - tail.Item1), Math.Sign(head.Item2 - tail.Item2));
//		tail = (tail.Item1 + offset.Item1, tail.Item2 + offset.Item2);
//	}
//	return tail;
//}

//bool Touching((int, int) head, (int, int) tail)
//{
//	if(Math.Abs(head.Item1 - tail.Item1) < 2 && Math.Abs(head.Item2 - tail.Item2) < 2) return true;
//	return false;
//}
