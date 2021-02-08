using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMovement : Movement
{
    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.speed = speedMax;
        navMeshAgent.angularSpeed = 90;
    }

    public override void ApplyForce(Vector3 force)
    {
        //
    }

    public override void MoveTowards(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    public override void Stop()
    {
        navMeshAgent.isStopped = true;
    }
}
