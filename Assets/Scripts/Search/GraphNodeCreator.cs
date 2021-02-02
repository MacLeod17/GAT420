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
                GraphNode.UnlinkNodes();
                GraphNode.LinkNodes(range);
            }
        }
    }
}
