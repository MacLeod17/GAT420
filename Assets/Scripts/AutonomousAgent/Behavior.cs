using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    [Range(0, 2)] public float strength = 1;
    public Perception perception;

    public AutonomousAgent Agent { get { return GetComponent<AutonomousAgent>(); } }

    public abstract Vector3 Execute();
}
