using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    protected int prevFrame = -1;

    public abstract bool IsTrue();
}
