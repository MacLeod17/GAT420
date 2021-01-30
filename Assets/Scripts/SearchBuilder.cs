using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchBuilder : MonoBehaviour
{
	public TMP_Text infoText;

    delegate bool SearchAlgorithm(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps);
	SearchAlgorithm Search;

	List<GraphNode> path;
	int maxSteps = int.MaxValue;

	private void Start()
	{
		Search = SearchDFS.Search;
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

		if (found)
        {
			float distance = 0;
			for (int i = 0; i < path.Count - 1; i++)
            {
				distance += Vector3.Distance(path[i].transform.position, path[i + 1].transform.position);
            }

			infoText.text = "Nodes: " + path.Count + "\nDistance: " + distance;
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

	public void OnSearchSelect(int index)
    {
		switch(index)
        {
			case 0:
				Search = SearchDFS.Search;
				break;
			case 1:
				Search = SearchBFS.Search;
				break;
			case 2:
				Search = SearchDijkstra.Search;
				break;
			case 3:
				Search = SearchAStar.Search;
				break;
			default:
				Search = SearchDFS.Search;
				break;
        }
    }
}
