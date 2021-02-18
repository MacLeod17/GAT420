using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : MonoBehaviour
{
    public DecisionNode root;
    public static int frame = 0;

    private void Update()
    {
        DecisionNode[] nodes = FindObjectsOfType<DecisionNode>();
        foreach (var node in nodes) node.State = DecisionNode.eState.Inactive;

        frame++;
        root.Execute();
    }
}
