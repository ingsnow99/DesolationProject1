using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;

    public Attack(ActionDelegate action)
    {
        nodeAction = action;
    }

    public override NodeStates Evaluate()
    {
        if(nodeAction())
        {
            Debug.Log("Attacking target...");
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
