public class Wanderer : Kinematic
{
    Wander myMoveType;
    LookWhereGoing myRotateType;

    public float OffSet;
    public float Radius;
    public float Rate;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Wander();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.wanderOffSet = OffSet;
        myMoveType.wanderRadius = Radius;
        myMoveType.wanderRate = Rate;

        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = myMoveType.getSteering().linear;
        steeringUpdate.angular = myRotateType.getSteering().angular;
        base.Update();
    }
}
