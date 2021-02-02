using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SearchBFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		// <create queue>
		Queue<GraphNode> nodes = new Queue<GraphNode>();

		source.Visited = true;
		nodes.Enqueue(source);

		// set found bool flag and the current number of steps
		bool found = false;
		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			GraphNode node = nodes.Dequeue();
		
			// go through edges of node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				// if nodeB is not visited
				if (edge.nodeB.Visited == false)
				{
					edge.nodeB.Visited = true;
					edge.nodeB.Parent = node;
					nodes.Enqueue(edge.nodeB);
				}
				if (edge.nodeB == destination)
				{
					found = true;
					break;
				}
			}
		}

		// create a list of graph nodes (path)
		path = new List<GraphNode>();
		// if found is true
		if (found)
		{
			GraphNode node = destination;
		    // while node not null
			while (node != null)
			{
				path.Add(node);
				node = node.Parent;
			}
			path.Reverse();
		}
		else
		{
			path = nodes.ToList();
		}

		return found;
	}
}
