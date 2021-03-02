using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UtilityAgentUI : MonoBehaviour
{
    public UtilityAgent agent;

    public GameObject goalUI;
    public Transform goalUIParent;

    public Slider happinessSlider;

    void Start()
    {
        var goals = GetComponentsInChildren<UtilityAgentGoal>();

        foreach (var goal in goals)
        {
            GameObject gameObject = Instantiate(goalUI, goalUIParent);
            gameObject.GetComponent<UtilityAgentGoalUI>().utilityAgentGoal = goal;
        }
    }

    private void Update()
    {
        happinessSlider.value = agent.Happiness;
    }
}
