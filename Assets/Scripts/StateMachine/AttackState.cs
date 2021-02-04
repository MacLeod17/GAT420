using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    float timer;
    Vector3 lastTargetPosition;

    public override void Enter(Agent owner)
    {
        Debug.Log(GetType().Name + " Enter");
    }

    public override void Execute(Agent owner)
    {
        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        // Player Seen
        if (player != null)
        {
            lastTargetPosition = player.transform.position;
            timer = 1;
        }

        owner.movement.MoveTowards(lastTargetPosition);

        if (player == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ((StateAgent)owner).StateMachine.SetState("IdleState");
            }
        }
    }

    public override void Exit(Agent owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}
