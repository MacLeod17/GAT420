using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityObject : MonoBehaviour
{
    public string id;
    public string animationID;
    public float duration;
    public Transform location;
    public GameObject actionEffects;

    public UtilityScore[] scores { get; set; }

    void Start()
    {
        scores = GetComponentsInChildren<UtilityScore>();
    }

    public float GetScore(string id)
    {
        float change = 0;

        foreach (var score in scores)
        {
            if (score.id == id)
            {
                change += score.change;
            }
        }

        return change;
    }
}
