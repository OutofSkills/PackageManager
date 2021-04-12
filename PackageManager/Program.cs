using System;
namespace PackageManager
{
	using System;
	using System.Collections.Generic;
    using System.Linq;

    public class Program
	{
		/*Task 1*/
		//public static void Main()
		//{
		//	/*graph data structure*/
		//	Graph graph = new Graph();
		//	/*File manager object*/
		//	IOFile file = new IOFile();
		//	/*List of nodes to be added*/
		//	List<Graph.Node> nodes = new List<Graph.Node>();

		//	/*list of pairs A B parsed from the input file*/
		//	List<string[]> list = file.Read();

		//	foreach(var item in list)
		//          {
		//		var tempNode = new Graph.Node(item[0]);
		//		/*if the node doesn't exist create it and add his neighbors*/
		//		if (!nodes.Exists(n => n.val == tempNode.val))
		//		{
		//			nodes.Add(tempNode);
		//			tempNode.neighbors = new List<Graph.Node> { };

		//			if(!nodes.Exists(n => n.val == item[1]))
		//                  {
		//				var neighbor = new Graph.Node(item[1]);
		//				nodes.Add(neighbor);
		//				tempNode.neighbors.Add(neighbor);
		//			}
		//			else
		//                  {
		//				var index = nodes.FindIndex(n=>n.val == item[1]);
		//				tempNode.neighbors.Add(nodes[index]);
		//                  }
		//		}
		//		else/*if the node already exists, just add the neighbors*/
		//              {
		//			var index = nodes.FindIndex(n => n.val == item[0]);

		//			if (!nodes.Exists(n => n.val == item[1]))
		//			{
		//				var neighbor = new Graph.Node(item[1]);
		//				nodes.Add(neighbor);
		//				nodes[index].neighbors.Add(neighbor);
		//			}
		//			else
		//			{
		//				var i = nodes.FindIndex(n => n.val == item[1]);
		//				nodes[index].neighbors.Add(nodes[i]);
		//			}
		//		}
		//	}

		//	/*Traverse the graph and store the node's values to a list*/
		//	graph.Dfs(nodes);
		//	/*sort the list*/
		//	graph._list.Sort();

		//	/*write the data to the output file*/
		//	file.Write(graph._list);

		//}

		/*Task 2*/
		//public static void Main()
		//{
		//	/*graph data structure*/
		//	Graph graph = new Graph();
		//	/*File manager object*/
		//	IOFile file = new IOFile();
		//	/*List of nodes to be added*/
		//	List<Graph.Node> nodes = new List<Graph.Node>();

		//	/*list of pairs A B parsed from the input file*/
		//	List<string[]> list = file.Read();

		//	foreach (var item in list)
		//	{
		//		var tempNode = new Graph.Node(item[0]);
		//		/*if the node doesn't exist create it and add his neighbors*/
		//		if (!nodes.Exists(n => n.val == tempNode.val))
		//		{
		//			nodes.Add(tempNode);
		//			tempNode.neighbors = new List<Graph.Node> { };

		//			if (!nodes.Exists(n => n.val == item[1]))
		//			{
		//				var neighbor = new Graph.Node(item[1]);
		//				nodes.Add(neighbor);
		//				tempNode.neighbors.Add(neighbor);
		//			}
		//			else
		//			{
		//				var index = nodes.FindIndex(n => n.val == item[1]);
		//				tempNode.neighbors.Add(nodes[index]);
		//			}
		//		}
		//		else/*if the node already exists, just add the neighbors*/
		//		{
		//			var index = nodes.FindIndex(n => n.val == item[0]);

		//			if (!nodes.Exists(n => n.val == item[1]))
		//			{
		//				var neighbor = new Graph.Node(item[1]);
		//				nodes.Add(neighbor);
		//				nodes[index].neighbors.Add(neighbor);
		//			}
		//			else
		//			{
		//				var i = nodes.FindIndex(n => n.val == item[1]);
		//				nodes[index].neighbors.Add(nodes[i]);
		//			}
		//		}
		//	}

		//	/*sort the nodes*/
		//	var SortedList = nodes.OrderBy(n => n.val).ToList();
		//	/*write the data to the output file*/
		//	file.Write(graph.TraverseGraf(SortedList), SortedList);

		//}

		/*Task 3*/
		public static void Main()
		{
			/*graph data structure*/
			Graph graph = new Graph();
			/*File manager object*/
			IOFile file = new IOFile();
			/*List of nodes to be added*/
			List<Graph.Node> nodes = new List<Graph.Node>();

			/*list of pairs A B parsed from the input file*/
			List<string[]> list = file.Read("C:\\Users\\kojoc\\source\\repos\\PackageManager\\PackageManager\\Task 3\\Data\\deps.in");

			foreach (var item in list)
			{
				var tempNode = new Graph.Node(item[0]);
				/*if the node doesn't exist create it and add his neighbors*/
				if (!nodes.Exists(n => n.val == tempNode.val))
				{
					nodes.Add(tempNode);
					tempNode.neighbors = new List<Graph.Node> { };

					if (!nodes.Exists(n => n.val == item[1]))
					{
						var neighbor = new Graph.Node(item[1]);
						nodes.Add(neighbor);
						tempNode.neighbors.Add(neighbor);
					}
					else
					{
						var index = nodes.FindIndex(n => n.val == item[1]);
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

			/*sort the nodes*/
			var SortedList = nodes.OrderBy(n => n.val).ToList();
			var listNodesNeighbors = graph.TraverseGraf(SortedList);

			/*list of pairs A B parsed from the input file*/
			List<string[]> listPcIn = file.Read("C:\\Users\\kojoc\\source\\repos\\PackageManager\\PackageManager\\Task 3\\Data\\computers.in");
			List<List<string>> PcPackages = new List<List<string>>(); ;
			List<List<string>> missingPackages = new List<List<string>>();

			/*for each package add his dependencies*/
			for (int i = 0; i < listNodesNeighbors.Count; i++)
			{
				listNodesNeighbors[i].Insert(0, SortedList[i].val);
			}
			/*get missing packages*/
			for (int i = 0; i < listPcIn.Count; i++)
            {
				PcPackages.Add(listPcIn[i].ToList());
				int j;
				for(j = 0; j<listNodesNeighbors.Count; j++)
                {
					if (listNodesNeighbors[j][0] == PcPackages[i][0]) 
						break;
                }
				List<string> missingPackage = listNodesNeighbors[j].Except(PcPackages[i]).ToList();
				missingPackages.Add(missingPackage);
            }
			/*write the missing packages to the task3.out*/
			file.Write(missingPackages);
		}
	}
}

