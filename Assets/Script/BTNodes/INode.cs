using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeStates
{
    SUCCESS, FAILURE, RUNNING
}

[System.Serializable]
public abstract class INode
{
    protected NodeStates nodeState;

    public NodeStates getNodeState
    {
        get { return nodeState; }
    }

    public INode() { }

    public abstract NodeStates Evaluate();
}
