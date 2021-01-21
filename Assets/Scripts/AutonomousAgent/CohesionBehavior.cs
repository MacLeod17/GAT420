using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohesionBehavior : Behavior
{
    public override Vector3 Execute()
    {
        Vector3 force = Vector3.zero;

        GameObject[] gameObjects = perception.GetGameObjects();
        if (gameObjects != null && gameObjects.Length > 0)
        {
            // asdasdasdsad
            Vector3 positions = Vector3.zero;
            foreach(GameObject gameObject in gameObjects)
            {
                positions += gameObject.transform.position;
            }
            Vector3 center = positions / gameObjects.Length;

            Vector3 direction = (center - transform.position).normalized;
            // asdsadasdads

            Vector3 desired = direction * Agent.maxSpeed;
            force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

            Debug.DrawRay(transform.position, desired, Color.red); // Desired
            Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green); // Steering
        }

        return force;
    }
}
