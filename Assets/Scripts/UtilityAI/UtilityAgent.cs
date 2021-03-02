using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UtilityAgent : Agent
{
    public enum eState
    {
        Idle,
        ActionStart,
        ActionInProgress,
        ActionComplete
    }

    [Range(0, 1)] public float utilityThreshold = 0.25f;
    public bool utilityAI = true;

    public float Happiness 
    { 
        get
        {
            float utility = 0;
            foreach (var goal in goals)
            {
                utility += goal.Utility;
            }

            return utility / goals.Length;
        }
    }

    public eState state { get; set; } = eState.Idle;

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
                if (utilityAI)
                {
                    UtilityObject[] utilityObjects = FindObjectsOfType<UtilityObject>();
                    utilityObject = GetMaxScoreUtilityObject(utilityObjects);
                    if (utilityObject != null)
                    {
                        StartUtilityObject(utilityObject);
                    }
                }

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

        // Move to Action Location
        GetComponent<NavMeshAgent>().enabled = false;
        if (utilityObject.actionLocation != null)
        {
            float time = 1;
            float timer = 0;
            Transform start = transform;

            while (timer < time)
            {
                timer += Time.deltaTime;
                timer = Mathf.Min(timer, time);
                Utilities.Lerp(start, utilityObject.actionLocation, transform, timer / time);
                yield return null;
            }
        }

        // Perform UtilityObject action
        animator.SetTrigger(utilityObject.animationID);
        utilityObject.actionEffects.SetActive(true);

        // Wait for action duration
        yield return new WaitForSeconds(utilityObject.duration);

        // Return to Idle
        GetComponent<NavMeshAgent>().enabled = true;
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

    UtilityObject GetMaxScoreUtilityObject(UtilityObject[] utilityObjects)
    {
        UtilityObject maxUtilityObject = null;

        // Find goal with highest need
        float maxUtility = 0;
        UtilityAgentGoal maxGoal = null;
        foreach (var goal in goals)
        {
            if (goal.Utility > maxUtility)
            {
                maxUtility = goal.Utility;
                maxGoal = goal;
            }
        }

        // 
        if (maxUtility > utilityThreshold)
        {
            float maxScore = 0;
            foreach (var utilityObject in utilityObjects)
            {
                float score = utilityObject.GetScore(maxGoal.id);
                if (score > maxScore)
                {
                    maxScore = score;
                    maxUtilityObject = utilityObject;
                }
            }
        }

        return maxUtilityObject;
    }
}
