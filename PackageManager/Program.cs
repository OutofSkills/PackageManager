using System;
namespace PackageManager
{
	using System;
	using System.Collections.Generic;

	public class Program
	{
		public static void Main()
		{
			/*graph data structure*/
			Graph graph = new Graph();
			/*File manager object*/
			IOFile file = new IOFile();
			/*List of nodes to be added*/
			List<Graph.Node> nodes = new List<Graph.Node>();

			/*list of pairs A B parsed from the input file*/
			List<string[]> list = file.Read();

			foreach(var item in list)
            {
				var tempNode = new Graph.Node(item[0]);
				/*if the node doesn't exist create it and add his neighbors*/
				if (!nodes.Exists(n => n.val == tempNode.val))
				{
					nodes.Add(tempNode);
					tempNode.neighbors = new List<Graph.Node> { };

					if(!nodes.Exists(n => n.val == item[1]))
                    {
						var neighbor = new Graph.Node(item[1]);
						nodes.Add(neighbor);
						tempNode.neighbors.Add(neighbor);
					}
					else
                    {
						var index = nodes.FindIndex(n=>n.val == item[1]);
						tempNode.neighbors.Add(nodes[index]);
                    }
				}
				else/*if the node already exists, just add the neighbors*/
                {
					var index = nodes.FindIndex(n => n.val == item[0]);

					if (!nodes.Exists(n => n.val == item[1]))
					{
						var neighbor = new Graph.Node(item[1]);
						nodes.Add(neighbor);
						nodes[index].neighbors.Add(neighbor);
					}
					else
					{
						var i = nodes.FindIndex(n => n.val == item[1]);
						nodes[index].neighbors.Add(nodes[i]);
					}
				}
			}

			/*Traverse the graph and store the node's values to a list*/
			graph.Dfs(nodes);
			/*sort the list*/
			graph._list.Sort();

			/*write the data to the output file*/
			file.Write(graph._list);

		}
	}
}
