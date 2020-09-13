using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSequence : INode
{
    protected List<INode> nodeList;

    public BTSequence(List<INode> list)
    {
        nodeList = list;
    }
    public override NodeStates Evaluate()
    {
        bool isChildRunning = false;

        foreach(INode node in nodeList)
        {
            switch (node.Evaluate())
            {
                case NodeStates.SUCCESS:
                    continue;

                case NodeStates.RUNNING:
                    isChildRunning = true;
                    continue;

                case NodeStates.FAILURE:
                    nodeState = NodeStates.FAILURE;
                    return nodeState;

                default:
                    nodeState = NodeStates.SUCCESS;
                    return nodeState;
            }
        }

        nodeState = isChildRunning ? NodeStates.RUNNING : NodeStates.SUCCESS; 
        return nodeState;
    }
}
