using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;
    private MonsterAI monster;

    public Chase(MonsterAI _monster, ActionDelegate action)
    {
        monster = _monster;
        nodeAction = action;
    }

    public override NodeStates Evaluate()
    {
        if(nodeAction())
        {
            Debug.Log("Chasing target...");
            monster.ChaseTarget();
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
