using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    [Range(0, 2)] public float strength = 1;

    public BasicAgent Agent { get { return GetComponent<BasicAgent>(); } }

    public abstract Vector3 Execute(GameObject[] gameObjects);
}
