using UnityEngine;

public class ArriveSeparator : Kinematic
{
    Arrive myMoveType;
    Separation myAvoidType;
    Face mySeekRotateType;

    public float separationThreshold;
    public float arriveRaidus;
    public float arriveSlowdown;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Arrive();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.targetRadius = arriveRaidus;
        myMoveType.slowRadius = arriveSlowdown;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myAvoidType = new Separation();
        myAvoidType.character = this;
        myAvoidType.targets = FindObjectsOfType<Kinematic>();
        myAvoidType.threshold = separationThreshold;


    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myAvoidType.getSteering().linear.magnitude != 0 ? myAvoidType.getSteering().linear : myMoveType.getSteering().linear;
        steeringUpdate.angular = mySeekRotateType.getSteering().angular;
        
        base.Update();
    }
}
