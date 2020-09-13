using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeDrone : INode
{
    public delegate bool ActionDelegate();

    private ActionDelegate nodeAction;

    public SeeDrone(ActionDelegate action)
    {
        nodeAction = action;
    }
    public override NodeStates Evaluate()
    {
        if(nodeAction())
        {
            nodeState = NodeStates.SUCCESS;
        }
        else
        {
            nodeState = NodeStates.FAILURE;
        }

        return nodeState;
    }
}
