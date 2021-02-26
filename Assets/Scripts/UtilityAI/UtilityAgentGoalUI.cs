using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UtilityAgentGoalUI : MonoBehaviour
{
    public TMP_Text id;
    public Slider input;
    public Slider utility;

    public UtilityAgentGoal utilityAgentGoal { get; set; }

    void Update()
    {
        id.text = utilityAgentGoal.id;
        input.value = utilityAgentGoal.input;
        utility.value = utilityAgentGoal.Utility;
    }
}
