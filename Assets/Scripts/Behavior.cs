using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Behavior : MonoBehaviour
{
    public BasicAgent Agent { get { return GetComponent<BasicAgent>(); } }

    public abstract Vector3 Execute(GameObject[] gameObjects);
}
