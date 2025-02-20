using UnityEngine;
public class StaticsAvoider : Kinematic
{
    Face mySeekRotateType;
    Seek myMoveType;
    ObstacleAvoidance avoidType;

    public float lookDistance;
    public float avoidDistance;

    public bool flee;



    // Start is called before the first frame update
    void Start()
    {
        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myMoveType = new Seek();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = false;

        avoidType = new ObstacleAvoidance();
        avoidType.character = this;
        avoidType.target = myTarget;
        avoidType.lookahead = lookDistance;
        avoidType.avoidDistance = this.avoidDistance;
        avoidType.flee = flee;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();

        if (avoidType.getSteering() != null)
        {
            steeringUpdate.linear = avoidType.getSteering().linear;
        }
        else
        {
            steeringUpdate.linear = myMoveType.getSteering().linear;
        }
        steeringUpdate.angular = mySeekRotateType.getSteering().angular;
        base.Update();
    }
}
