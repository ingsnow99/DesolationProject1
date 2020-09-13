using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachDrone : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;
    private MonsterAI monster;
    public ApproachDrone(MonsterAI _monster, ActionDelegate action)
    {
        monster = _monster;
        nodeAction = action;
    }

    public override NodeStates Evaluate()
    {
        if(nodeAction())
        {
            Debug.Log("Approaching target...");
            monster.ApproachTarget();
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
