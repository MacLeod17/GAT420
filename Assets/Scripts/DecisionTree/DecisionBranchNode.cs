using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionBranchNode : DecisionNode
{
    public Condition condition;
    public DecisionNode trueNode;
    public DecisionNode falseNode;

    public override void Execute()
    {
        State = (condition.IsTrue()) ? eState.ConditionTrue : eState.ConditionFalse;

        DecisionNode node = (State == eState.ConditionTrue) ? trueNode : falseNode;
        node?.Execute();
    }
}
