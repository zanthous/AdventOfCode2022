\////this one sucked because I didn't realize in part2 a row going right from 5 4 4 2 3 5
////would have a score of 5 and not 3 or 2, the examples only were sufficient to know it wasn't 2

//var text = File.ReadAllLines("input.txt");

//int height = text.Length;
//int width = text[0].Length;

//bool[,] visible = new bool[width, height];
//int[,] heights = new int[width, height];
//int[,] scores = new int[width, height];

//for(int y = 0; y < text.Length; y++)
//{
//	for(int x = 0; x < text[0].Length; x++)
//	{
//		heights[x, y] = int.Parse(text[y][x].ToString());
//	}
//}

//for(int y = 0; y < text.Length; y++)
//{
//	for(int x = 0; x < text[0].Length; x++)
//	{
//		scores[x,y] = Score(x, y, 0) * Score(x, y, 1) * Score(x, y, 2) * Score(x, y, 3);
//		if(x == 0 || y == 0 || x == text[0].Length - 1 || y == text.Length - 1)
//		{ 
//			visible[x,y] = true;
//			continue;
//		}
//		else
//		{
//			visible[x,y] =
//			Check(x, y, 0)||
//			Check(x, y, 1)||
//			Check(x, y, 2)||
//			Check(x, y, 3);
//		}
//	}
//}
//int total = 0;
//int highestScore = 0;

//for(int y = 0; y < text.Length; y++)
//{
//	for(int x = 0; x < text[0].Length; x++)
//	{
//		if(visible[x,y]) total++;
//		if(highestScore < scores[x,y])
//		{
//			highestScore = Math.Max(highestScore, scores[x,y]);
//		}
		
//	}
//}


//Console.WriteLine(total);
//Console.WriteLine(highestScore);

//bool Check(int x_in, int y_in, int dir)
//{
//	bool v = true;
//	if(dir == 0)//l
//	{
//		for(int x = 0; x < x_in; x++)
//		{
//			if(!(heights[x,y_in] < heights[x_in,y_in]))
//			{
//				v = false;
//				break;
//			}
//		}
//		return v;
//	}
//	else if(dir == 1)//r
//	{
//		for(int x = width-1; x > x_in; x--)
//		{
//			if(!(heights[x,y_in] < heights[x_in,y_in]))
//			{
//				v = false;
//				break;
//			}
//		}
//		return v;
//	}
//	else if(dir == 2)//u
//	{
//		for(int y = 0; y < y_in; y++)
//		{
//			if(!(heights[x_in,y] < heights[x_in,y_in]))
//			{
//				v = false;
//				break;
//			}
//		}
//		return v;
//	}
//	else if(dir == 3)//d
//	{
//		for(int y = height - 1; y > y_in; y--)
//		{
//			if(!(heights[x_in,y] < heights[x_in,y_in]))
//			{
//				v = false;
//				break;
//			}
//		}
//		return v;
//	}
//	return true;
//}


////if equal or higher 

//////track highest seen, if equal or greater to current return result
////int Score(int x_in, int y_in, int dir)
////{
////	int soFar = 0;
////	int highestSeen = -1;

////	if(dir == 0)//r
////	{
////		int start = heights[x_in,y_in];
////		if(x_in + 1 == width) return 0;
////		for(int x = x_in+1; x < width; x++)
////		{
////			int cur = heights[x,y_in];
////			if(cur < start)
////			{
////				if(cur >= highestSeen) 
////				{
////					highestSeen = cur;
////					soFar++;
////				}
////				else
////				{
////					soFar++;
////					continue;
////				}
////			}
////			else if(heights[x,y_in] >= start)
////			{
////				soFar++;
////				return soFar;
////			}
////		}

////	}
////	else if(dir == 1)//l
////	{
////		int start = heights[x_in,y_in];
////		if(x_in - 1 == -1) return 0;
////		for(int x = x_in - 1; x > -1; x--)
////		{
////			int cur = heights[x,y_in];
////			if(cur < start)
////			{
////				if(cur >= highestSeen)
////				{
////					highestSeen = cur;
////					soFar++;
////				}
////				else
////				{
////					soFar++;
////					continue;
////				}
////			}
////			else if(heights[x,y_in] >= start)
////			{
////				soFar++;
////				return soFar;
////			}
////		}
////	}
////	else if(dir == 2)//
////	{
////		int start = heights[x_in,y_in];
////		if(y_in - 1 == -1) return 0;
////		for(int y = y_in - 1; y > -1; y--)
////		{
////			int cur = heights[x_in,y];
////			if(cur < start)
////			{
////				if(cur >= highestSeen)
////				{
////					highestSeen = cur;
////					soFar++;
////				}
////				else
////				{
////					soFar++;
////					continue;
////				}
////			}
////			else if(heights[x_in,y] >= start)
////			{
////				soFar++;
////				return soFar;
////			}
////		}
////	}
////	else if(dir == 3)//d
////	{
////		int start = heights[x_in,y_in];
////		if(x_in + 1 == height) return 0;
////		for(int y = y_in + 1; y < height; y++)
////		{
////			int cur = heights[x_in,y];
////			if(cur < start)
////			{
////				if(cur >= highestSeen)
////				{
////					highestSeen = cur;
////					soFar++;
////				}
////				else
////				{
////					soFar++;
////					continue;
////				}
////			}
////			else if(heights[x_in,y] >= start)
////			{
////				soFar++;
////				return soFar;
////			}
////		}
////	}
////	return soFar;
////}

//int Score(int x_in, int y_in, int dir)
//{
//	if((dir == 0 && x_in + 1 == width) ||
//		(dir == 1 && x_in - 1 == -1) ||
//		(dir == 2 && y_in - 1 == -1) ||
//		(dir == 3 && y_in + 1 == height))
//	{
//		return 0;
//	}

//	int highestSeen = -1;
//	int soFar = 0;
//	int start = heights[x_in, y_in];

//	if(dir == 0)//r
//	{
//		for(int x = x_in + 1; x < width; x++)
//		{
//			int cur = heights[x, y_in];
//			if(cur < start)
//			{
//				if(cur >= highestSeen)
//				{
//					highestSeen = cur;
//					soFar++;
//				}
//				else
//				{
//					soFar++;
//					continue;
//				}
//			}
//			else if(heights[x, y_in] >= start)
//			{
//				soFar++;
//				return soFar;
//			}
//		}

//	}
//	else if(dir == 1)//l
//	{
//		for(int x = x_in - 1; x > -1; x--)
//		{
//			int cur = heights[x, y_in];
//			if(cur < start)
//			{
//				if(cur >= highestSeen)
//				{
//					highestSeen = cur;
//					soFar++;
//				}
//				else
//				{
//					soFar++;
//					continue;
//				}
//			}
//			else if(heights[x, y_in] >= start)
//			{
//				soFar++;
//				return soFar;
//			}
//		}
//	}
//	else if(dir == 2)//
//	{
//		for(int y = y_in - 1; y > -1; y--)
//		{
//			int cur = heights[x_in, y];
//			if(cur < start)
//			{
//				if(cur >= highestSeen)
//				{
//					highestSeen = cur;
//					soFar++;
//				}
//				else
//				{
//					soFar++;
//					continue;
//				}
//			}
//			else if(heights[x_in, y] >= start)
//			{
//				soFar++;
//				return soFar;
//			}
//		}
//	}
//	else if(dir == 3)//d
//	{
//		for(int y = y_in + 1; y < height; y++)
//		{
//			int cur = heights[x_in, y];
//			if(cur < start)
//			{
//				if(cur >= highestSeen)
//				{
//					highestSeen = cur;
//					soFar++;
//				}
//				else
//				{
//					soFar++;
//					continue;
//				}
//			}
//			else if(heights[x_in, y] >= start)
//			{
//				soFar++;
//				return soFar;
//			}
//		}
//	}

//	return soFar;
//}