using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Behavior
{
    [Range(0, 45)] public float displacement = 5;
    [Range(0, 5)] public float radius = 2;
    [Range(0, 5)] public float distance = 2;
    
    float angle = 0;

    public override Vector3 Execute()
    {
        Vector3 force = Vector3.zero;

        angle += Random.Range(-displacement, displacement); // Go from 30 to 20-40?
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up); //I think rotating around the y-axis is the way to go?

        Vector3 point = rotation * Vector3.forward * radius;
        Vector3 forward = Agent.Direction * distance;
        Vector3 direction = (forward + point).normalized;

        Vector3 desired = direction * Agent.maxSpeed;
        force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

        Debug.DrawLine(transform.position, transform.position + forward, Color.yellow);
        Debug.DrawLine(transform.position + forward, transform.position + forward + point, Color.yellow);

        Debug.DrawRay(transform.position, desired, Color.red); // desired
        Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green); // steering

        return force;
    }
}
