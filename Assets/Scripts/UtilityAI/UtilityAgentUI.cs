using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentUI : MonoBehaviour
{
    public GameObject goalUI;
    public Transform goalUIParent;

    void Start()
    {
        var goals = GetComponentsInChildren<UtilityAgentGoal>();

        foreach (var goal in goals)
        {
            GameObject gameObject = Instantiate(goalUI, goalUIParent);
            gameObject.GetComponent<UtilityAgentGoalUI>().utilityAgentGoal = goal;
        }
    }
}
