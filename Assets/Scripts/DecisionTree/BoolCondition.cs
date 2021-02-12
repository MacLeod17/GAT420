using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolCondition : Condition
{
    public bool value { get; set; }
    public bool parameter { get; set; }

    public override bool IsTrue()
    {
        return (parameter == value);
    }
}
