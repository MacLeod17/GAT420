using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPerception : Perception
{
    public Transform raycastTransform;
    [Range(1, 40)] public float distance = 1;
    [Range(0, 90)] public float angle = 0;
    [Min(1)] public int numRaycast = 1;

    public override GameObject[] GetGameObjects()
    {
        List<GameObject> gameObjects = new List<GameObject>();

        for (int i = 0; i < numRaycast; i++)
        {
            var tempTransform = raycastTransform;
            // Change direction of transform.forward here

            Ray ray = new Ray(tempTransform.position, tempTransform.forward);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, distance))
            {
                gameObjects.Add(raycastHit.collider.gameObject);
            }
            Debug.DrawRay(ray.origin, ray.direction * distance);

            //Debug.DrawRay(ray.origin, (ray.direction) * distance, Color.red);
            //Debug.DrawRay(ray.origin, (ray.direction) * distance, Color.red);
        }

        return gameObjects.ToArray();
    }
}
