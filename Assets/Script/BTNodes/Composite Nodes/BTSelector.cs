using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : INode
{
    protected List<INode> nodeList;

    public BTSelector(List<INode> list)
    {
        nodeList = list;
    }
    public override NodeStates Evaluate()
    {
        foreach(INode node in nodeList)
        {
            switch (node.Evaluate())
            {
                case NodeStates.FAILURE:
                    continue;

                case NodeStates.SUCCESS:
                    nodeState = NodeStates.SUCCESS;
                    return nodeState;

                case NodeStates.RUNNING:
                    nodeState = NodeStates.RUNNING;
                    return nodeState;

                default:
                    continue;
            }
        }

        nodeState = NodeStates.FAILURE;
        return nodeState;
    }
}
