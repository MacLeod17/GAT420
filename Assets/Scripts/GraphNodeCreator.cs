using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNodeCreator : MonoBehaviour
{
    public GraphNode graphNode;
    public LayerMask layerMask;
    [Range(0, 20)] public float range = 1;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100, layerMask))
            {
                GraphNode node = Instantiate(graphNode, hitInfo.point, Quaternion.identity);
                LinkNode(node);
            }
        }
    }

    public void LinkNode(GraphNode node)
    {
        Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);

        foreach(Collider collider in colliders)
        {
            GraphNode otherNode = collider.GetComponent<GraphNode>();

            if (otherNode != null && otherNode != node)
            {
                GraphNode.Edge edge;
                edge.nodeA = node;
                edge.nodeB = otherNode;

                node.Edges.Add(edge);
            }
        }
    }

    public void LinkNodes()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Node");

        foreach(GameObject gameObject in gameObjects)
        {
            GraphNode node = gameObject.GetComponent<GraphNode>();
            if (node != null)
            {
                LinkNode(node);
            }
        }
    }
}
