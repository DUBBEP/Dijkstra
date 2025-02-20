using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartSeeker : Kinematic
{
    Pursue myMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;

    public float maxPredictionTime;

    public bool Evade = false;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Pursue();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = Evade;
        myMoveType.maxPredictionTime = this.maxPredictionTime;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = Evade ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        base.Update();
    }
}
