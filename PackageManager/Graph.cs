using System;
using System.Collections.Generic;
using System.Text;

namespace PackageManager
{
	// This class represents a directed graph
	// using adjacency list representation
	class Graph
	{
		//A list of nodes's values
		public List<string> _list;
		/*Constructor*/
		public Graph()
        {
			_list = new List<string>();
        }
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
			_list.Add(u.val);
		}

		/*Description here: https://medium.com/@kumarrocky436/dfs-time-stamp-on-nodes-da76a51a50cb */
		public static int getUnixTimeStamp()
		{
			return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

	}
}
