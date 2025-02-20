using UnityEngine;

public class Separator : Kinematic
{
    Seek myMoveType;
    Separation myAvoidType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;

    public float separationThreshold;

    public bool flee = false;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Seek();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = flee;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;

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
        steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
        
        base.Update();
    }
}
