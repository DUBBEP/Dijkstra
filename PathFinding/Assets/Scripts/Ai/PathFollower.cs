using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : Kinematic
{
    FollowPath myMoveType;
    Face myRotateType;

    public GameObject[] Targets;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new FollowPath();
        myMoveType.character = this;
        myMoveType.pathTargets = Targets;
        myMoveType.target = Targets[0];

        myRotateType = new Face();
        myRotateType.character = this;
        myRotateType.target = Targets[0];
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;

        if (myRotateType.target != myMoveType.target)
        {
            myRotateType.target = myMoveType.target;
        }

        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
