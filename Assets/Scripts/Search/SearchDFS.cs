using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchDFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
		bool found = false;

		Stack<GraphNode> nodes = new Stack<GraphNode>();
		nodes.Push(source);

		int steps = 0;
		while (!found && nodes.Count > 0 && steps++ < maxSteps)
		{
			// get top node of stack node (peek)
			GraphNode node = nodes.Peek(); // Top of Stack
			node.Visited = true;

			bool forward = false;
			// search node edges for unvisited node
			foreach (GraphNode.Edge edge in node.Edges)
			{
				// if node is unvisited then push on stack
				if (edge.nodeB.Visited == false)
				{
					nodes.Push(edge.nodeB);
					forward = true;

					if (edge.nodeB == destination)
					{
						found = true;
					}
					break;
				}
			}

			// if not moving forward, pop current node off stack
			if (forward == false)
			{
				nodes.Pop();
			}
		}

		// convert stack path nodes to list
		path = new List<GraphNode>(nodes);
		path.Reverse();

		return found;
	}
}
