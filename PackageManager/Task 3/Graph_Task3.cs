using System;
using System.Collections.Generic;
using System.Text;

namespace PackageManager
{
	// This class represents a directed graph
	// using adjacency list representation
	public class Graph
	{
		/*Graph node*/
		public class Node
		{
			public string val;
			public int start;
			public int end;
			public bool visited = false;
			public List<Node> neighbors;
			public Node(string val)
			{
				this.val = val;
				neighbors = new List<Node>();
			}
		}

		public List<List<string>> TraverseGraf(List<Graph.Node> sortedList)
		{
			List<List<string>> list = new List<List<string>>();
			foreach (var node in sortedList)
			{
				List<string> NeighborList = new List<string>();
				GetNeighbors(node, NeighborList);
				NeighborList.Sort();
				list.Add(NeighborList);
			}
			return list;
		}
		public void GetNeighbors(Graph.Node node, List<string> NeighborList)
		{
			foreach (var neighbor in node.neighbors)
			{
				if (!NeighborList.Exists(n => n == neighbor.val))
					NeighborList.Add(neighbor.val);
				foreach (var _neighbor in neighbor.neighbors)
				{
					if (!NeighborList.Exists(n => n == _neighbor.val))
						NeighborList.Add(_neighbor.val);
					GetNeighbors(_neighbor, NeighborList);
				}
			}
		}

		/*simple depth first search*/
		public void Dfs(List<Node> nodes)
		{
			foreach (var node in nodes)
			{
				if (!node.visited)
				{
					DfsVisit(node);
				}
			}
		}
		/*mark visited nodes*/
		public void DfsVisit(Node u)
		{
			u.start = getUnixTimeStamp();
			u.visited = true;
			foreach (var neighbor in u.neighbors)
			{
				if (!neighbor.visited)
				{
					DfsVisit(neighbor);
				}
			}
			u.end = getUnixTimeStamp();
		}

		/*Description here: https://medium.com/@kumarrocky436/dfs-time-stamp-on-nodes-da76a51a50cb */
		public static int getUnixTimeStamp()
		{
			return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

	}
}
