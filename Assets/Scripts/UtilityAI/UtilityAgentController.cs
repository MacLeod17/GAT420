using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityAgentController : MonoBehaviour
{
    public UtilityAgent agent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                UtilityObject utilityObject = raycastHit.collider.gameObject.GetComponent<UtilityObject>();

                if (utilityObject != null && agent.utilityAI == false)
                {
                    Debug.Log(utilityObject.id);
                    agent.StartUtilityObject(utilityObject);
                }
                else
                {
                    agent.movement.MoveTowards(raycastHit.point);
                }
            }
        }
    }
}
