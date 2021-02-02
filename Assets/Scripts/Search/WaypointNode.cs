using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : SearchNode
{
    public WaypointNode nextWaypoint;

    private void OnTriggerEnter(Collider other)
    {
        SearchAgent searchAgent = other.GetComponent<SearchAgent>();
        if (searchAgent != null && searchAgent.Waypoint == this)
        {
            searchAgent.Waypoint = nextWaypoint;
        }
    }
}
