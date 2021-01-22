using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{
    public struct Edge
    {
        public GraphNode nodeA;
        public GraphNode nodeB;
    }

    public List<Edge> Edges { get; set; } = new List<Edge>();

    void Update()
    {
        foreach(Edge edge in Edges)
        {
            Debug.DrawLine(edge.nodeA.transform.position, edge.nodeB.transform.position);
        }
    }
}
