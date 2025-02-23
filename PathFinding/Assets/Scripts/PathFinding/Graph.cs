using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public enum weightType
    {
        onlyDistance,
        favorDistance,
        mixWeights,
        favorHeight,
        onlyHeight
    }

    public weightType myWeightType = weightType.mixWeights;

    public Node[] nodes = GameObject.FindObjectsOfType<Node>();

    List<Connection> mConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }

    public void Build()
    {
        // find all nodes in scene
        // iterate over the nodes
        //   create connection objects,
        //   stuff them in mConnections
        mConnections = new List<Connection>();

        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float cost = GetWeight(fromNode, toNode);
                //float cost = (toNode.transform.position - fromNode.transform.position).magnitude;
                Connection c = new Connection(cost, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }

    private float GetWeight(Node fromNode, Node toNode)
    {
        switch (myWeightType)
        {
            case weightType.onlyDistance:
                return (toNode.transform.position - fromNode.transform.position).magnitude;
            case weightType.onlyHeight:
                return toNode.GetHeight();
            case weightType.favorDistance:
                return (toNode.transform.position - fromNode.transform.position).magnitude + (toNode.GetHeight() / 3);
            case weightType.favorHeight:
                return (toNode.transform.position - fromNode.transform.position).magnitude + (toNode.GetHeight() * 3);
            case weightType.mixWeights:
                return (toNode.transform.position - fromNode.transform.position).magnitude + (toNode.GetHeight());
        }

        return (toNode.transform.position - fromNode.transform.position).magnitude;
    }

    public void RandomizeNodeHeights()
    {
        foreach (Node node in nodes)
        {
            node.SetRandomHeight();
        }
    }

    public Node GetRandomNode()
    {
        return nodes[Random.Range(0, nodes.Length)];
    }
}

public class Connection
{
    float cost;
    Node fromNode;
    Node toNode;

    public Connection(float cost, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }
}