using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;
    private MonsterAI monster;

    public Idle(MonsterAI _monster, ActionDelegate action)
    {
        monster = _monster;
        nodeAction = action;
    }

    public override NodeStates Evaluate()
    {
        if(!nodeAction())
        {
            Debug.Log("Idling...");
            monster.Idle();
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
