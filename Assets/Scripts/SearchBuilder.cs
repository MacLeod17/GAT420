using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBuilder : MonoBehaviour
{
    delegate bool SearchAlgorithm(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps);
	SearchAlgorithm Search;

	List<GraphNode> path;
	int maxSteps = int.MaxValue;

	private void Start()
	{
		Search = SearchDFS.Search;
		//Search = SearchBFS.Search;
	}

	public void SearchNodes()
	{
        GraphNode source = GraphNode.GetGraphNode( GraphNode.eType.Source);
        GraphNode destination = GraphNode.GetGraphNode(GraphNode.eType.Destination);

        if (source == null || destination == null) return;

		// reset nodes
		GraphNode.Reset();

		// search for path from source to destination nodes		
		bool found = Search(source, destination, ref path, maxSteps);

		// set all path nodes to path type amd draw lines
        foreach (GraphNode graphNode in path)
		{
            if (graphNode.Type == GraphNode.eType.Default)
			{
                graphNode.Type = (found) ? GraphNode.eType.Path : GraphNode.eType.Visited;
			}
		}
    }

	public void OnSearch()
	{
		maxSteps = int.MaxValue;
		SearchNodes();
	}

	public void OnSteps(float steps)
	{
		maxSteps = (int)steps;
		SearchNodes();
	}

	public void OnReset()
	{
		GraphNode.Reset();
    }
}
