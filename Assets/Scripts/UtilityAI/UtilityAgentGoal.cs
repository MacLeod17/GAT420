using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentGoal : MonoBehaviour
{
    public string id;
    public AnimationCurve curve;
    public float input = 1;
    public float decay = 0;

    public float Utility { get { return curve.Evaluate(input); } }

    void Update()
    {
        input -= decay * Time.deltaTime;
        input = Mathf.Clamp(input, -1, 1);
    }
}
