using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgent : Agent
{
    public enum eState
    {
        Idle,
        ActionStart,
        ActionInProgress,
        ActionComplete
    }

    void Start()
    {
        
    }

    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);
    }
}
