using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : Kinematic
{
    public Node start;
    public Node goal;
    public Graph myGraph;

    Graph.weightType currentWeightMix = Graph.weightType.mixWeights;

    FollowPath myMoveType;
    LookWhereGoing myRotateType;

    private bool firstGraph = true;

    //public GameObject[] myPath = new GameObject[4];
    GameObject[] myPath;

    private void OnEnable()
    {
        FollowPath.OnRouteCompleted += GenerateNewGraph;
    }

    private void OnDisable()
    {
        FollowPath.OnRouteCompleted -= GenerateNewGraph;
    }

    // Start is called before the first frame update
    void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        myMoveType = new FollowPath();
        myMoveType.character = this;

        GenerateNewGraph();
    }

    private void GenerateNewGraph()
    {
        myGraph = new Graph();
        myGraph.myWeightType = currentWeightMix;
        myGraph.RandomizeNodeHeights();
        myGraph.Build();
        foreach (Node node in myGraph.nodes)
        {
            node.SetNodeColor(Color.white);
        }

        if (firstGraph)
        {
            firstGraph = false;
        }
        else
        {
            start = goal;
        }

        do
        {
            goal = myGraph.GetRandomNode();
        } while (goal == start);

        List<Connection> path = Dijkstra.pathfind(myGraph, start, goal);
        foreach (Connection con in path)
        {
            con.getFromNode().SetNodeColor(Color.blue);
        }
        start.SetNodeColor(Color.red);
        goal.SetNodeColor(Color.green);

        // path is a list of connections - convert this to gameobjects for the FollowPath steering behavior
        myPath = new GameObject[path.Count + 1];
        int i = 0;
        foreach (Connection c in path)
        {
            Debug.Log("from " + c.getFromNode() + " to " + c.getToNode() + " @" + c.getCost());
            myPath[i] = c.getFromNode().gameObject;
            i++;
        }
        myPath[i] = goal.gameObject;

        myMoveType.path = myPath;
        myMoveType.ResetPathIndex();
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.angular = myRotateType.getSteering().angular;
        steeringUpdate.linear = myMoveType.getSteering().linear;
        base.Update();
    }

    public void SetWeightMix(int type)
    {
        switch (type)
        {
            case 0:
                currentWeightMix = Graph.weightType.mixWeights;
                break;
            case 1:
                currentWeightMix = Graph.weightType.favorDistance;
                break;
            case 2:
                currentWeightMix = Graph.weightType.onlyDistance;
                break;
            case 3:
                currentWeightMix = Graph.weightType.favorHeight;
                break;
            case 4:
                currentWeightMix = Graph.weightType.onlyHeight;
                break;
        }
    }
}