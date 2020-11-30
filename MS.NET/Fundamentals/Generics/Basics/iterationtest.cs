using System;
using System.Collections.Generic;

class SimpleStack<V>
{
	class Node
	{
		internal V value;
		internal Node below;

		internal Node(V v, Node n) => (value, below) = (v, n);
	}

	private Node top;
	private int count;

	public void Push(V val)
	{
		top = new Node(val, top);
		++count;
	}

	public V Pop()
	{
		V val = top.value;
		top = top.below;
		count--;
		return val;
	}

	public bool Empty()
	{
		return top == null;
	}

	public int Length => count;

	//indexer property
	public V this[int index]
	{
		get
		{
			if(index < 0 || index >= count)
				throw new IndexOutOfRangeException();
			Node n = top;
			while(index-- > 0)
				n = n.below;
			return n.value;
		}
	}

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.below)
			yield return n.value;
	}
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> s = new SimpleStack<string>();
		s.Push("Monday");
		s.Push("Tuesday");
		s.Push("Wednesday");
		s.Push("Thursday");
		s.Push("Friday");

		Console.WriteLine("Iterating using indexer");
		for(int i = 0; i < s.Length; ++i)
			Console.WriteLine($"{s[i]}");

		Console.WriteLine("Iterating using enumerator");
		foreach(string i in s)
			Console.WriteLine(i);

	}
}

