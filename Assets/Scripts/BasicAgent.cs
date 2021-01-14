using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
    public float maxSpeed = 2;
    public float maxForce = 2;

    public Perception perception;
    public Behavior behavior;

    public Vector3 Velocity { get; set; }
    public Vector3 Acceleration { get; set; }
    public Vector3 Direction { get { return Velocity.normalized; } }

    void Update()
    {
        Acceleration = Vector3.zero;

        GameObject[] gameObjects = perception.GetGameObjects();
        Vector3 force = behavior.Execute(gameObjects);
        Acceleration += force;

        Velocity += Acceleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        transform.position += Velocity * Time.deltaTime;

        Debug.DrawRay(transform.position, Velocity, Color.white);

        if (Direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(Direction);
        }

        transform.position = Utilities.Wrap(transform.position, new Vector3(-10, -10, -10), new Vector3(10, 10, 10));
    }
}
