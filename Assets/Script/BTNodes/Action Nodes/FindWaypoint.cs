using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWaypoint : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;
    private MonsterAI monster;

    public FindWaypoint(MonsterAI _monster, ActionDelegate action)
    {
        monster = _monster;
        nodeAction = action;
    }

    public override NodeStates Evaluate()
    {
        if(nodeAction())
        {
            Debug.Log("Patroling...");
            monster.MoveToWayPoint();
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
