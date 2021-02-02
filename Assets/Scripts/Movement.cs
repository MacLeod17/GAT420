using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedMax = 2;
    public float accelerationMax = 2;
    public bool orientToMovement = true; 

    public Vector3 Velocity { get; set; }
    public Vector3 Acceleration { get; set; }
    public Vector3 Direction { get { return Velocity.normalized; } }

	void Update()
    {
        Acceleration = Vector3.zero;
    }

    private void LateUpdate()
    {
        Velocity += Acceleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, speedMax);
        transform.position += Velocity * Time.deltaTime;

        if (orientToMovement && Direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(Direction);
        }
    }

    public void MoveTowards(Vector3 target)
	{
        Vector3 direction = (target - transform.position).normalized;
        ApplyForce(direction * accelerationMax);
    }

    public void ApplyForce(Vector3 force)
	{
        Acceleration += force;
        Acceleration = Vector3.ClampMagnitude(Acceleration, accelerationMax);
	}
}
