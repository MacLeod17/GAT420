using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatToStringConverter : MonoBehaviour
{
    public UnityEvent<string> unityEvent;

    public float value
    {
        set
        {
            unityEvent.Invoke(value.ToString());
        }
    }
}
