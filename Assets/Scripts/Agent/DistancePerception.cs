using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancePerception : Perception
{
    public float distance = 10.0f;
    public float angle = 30.0f;
    public string tagName = "";

    public override GameObject[] GetGameObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagName);
        gameObjects = GetGameObjectsInDistance(gameObjects, distance);
        gameObjects = GetGameObjectsInAngle(gameObjects, angle);
        gameObjects = SortGameObjectsByDistance(gameObjects);

        return gameObjects;
    }

    public GameObject[] GetGameObjectsInDistance(GameObject[] gameObjects, float maxDistance)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == this.gameObject) continue;

            float d = Vector3.Distance(transform.position, gameObject.transform.position);
            if (d <= maxDistance)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject[] GetGameObjectsInAngle(GameObject[] gameObjects, float maxAngle)
    {
        List<GameObject> result = new List<GameObject>();

        foreach (GameObject gameObject in gameObjects)
        {
            if (gameObject == this.gameObject) continue;

            Vector3 direction = (gameObject.transform.position - transform.position).normalized;

            float dot = Utilities.Dot(transform.forward, direction);
            dot = Mathf.Clamp(dot, -0.99f, 1);
            float a = Mathf.Acos(dot) * Mathf.Rad2Deg;

            if (a <= maxAngle)
            {
                result.Add(gameObject);
            }
        }

        return result.ToArray();
    }

    public GameObject[] SortGameObjectsByDistance(GameObject[] gameObjects)
    {
        List<GameObject> sortGameObjects = new List<GameObject>(gameObjects);

        sortGameObjects.Sort(SortByDistance);

        return sortGameObjects.ToArray();
    }

    int SortByDistance(GameObject gameObjectA, GameObject gameObjectB)
    {
        float distanceA = Vector3.Distance(gameObjectA.transform.position, transform.position);
        float distanceB = Vector3.Distance(gameObjectB.transform.position, transform.position);

        return distanceA.CompareTo(distanceB);
    }
}
