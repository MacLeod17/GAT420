using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : DecisionNode
{
    public override void Execute()
    {
        State = eState.Active;
    }
}
