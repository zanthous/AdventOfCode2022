using System.Collections.Concurrent;
namespace Helper
{
	public class FixedQueue<T>
	{
		public Queue<T> q = new Queue<T>();
		public int Limit { get; set; }
		public void Enqueue(T obj)
		{
			q.Enqueue(obj);
			if(q.Count > Limit)
				q.Dequeue();
		}
	}
}