using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DecisionNode : MonoBehaviour
{
    public enum eState
    {
        Inactive,
        Active,
        ConditionTrue,
        ConditionFalse
    }

    public eState State { get; set; }

    public abstract void Execute();
}
