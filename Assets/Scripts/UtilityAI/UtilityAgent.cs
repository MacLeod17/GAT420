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

    eState state = eState.Idle;
    UtilityAgentGoal[] goals;
    UtilityObject utilityObject;

    void Start()
    {
        goals = GetComponentsInChildren<UtilityAgentGoal>();
    }

    void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);

        switch (state)
        {
            case eState.Idle:
                break;
            case eState.ActionStart:
                StartCoroutine(ExecuteUtilityObject(utilityObject));
                break;
            case eState.ActionInProgress:
                break;
            case eState.ActionComplete:
                StopCoroutine("ExecuteUtilityObject");
                utilityObject = null;
                state = eState.Idle;
                break;
            default:
                break;
        }
    }

    IEnumerator ExecuteUtilityObject(UtilityObject utilityObject)
    {
        state = eState.ActionInProgress;

        // Walk to UtilityObject
        movement.MoveTowards(utilityObject.location.position);
        while (Vector3.Distance(transform.position, utilityObject.location.position) > 0.1f)
        {
            yield return null;
        }

        // Perform UtilityObject action
        animator.SetTrigger(utilityObject.animationID);
        utilityObject.actionEffects.SetActive(true);

        // Wait for action duration
        yield return new WaitForSeconds(utilityObject.duration);

        // Return to Idle
        animator.SetTrigger("Idle");
        utilityObject.actionEffects.SetActive(false);

        // Add utility score
        UpdateUtilityObjectScore(utilityObject);

        state = eState.ActionComplete;

        yield return null;
    }

    public void StartUtilityObject(UtilityObject utilityObject)
    {
        if (state == eState.Idle)
        {
            state = eState.ActionStart;
            this.utilityObject = utilityObject;
        }
    }

    void UpdateUtilityObjectScore(UtilityObject utilityObject)
    {
        foreach (var goal in goals)
        {
            float score = utilityObject.GetScore(goal.id);
            goal.input += score;
        }
    }
}
