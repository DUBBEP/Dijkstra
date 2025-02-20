using UnityEngine;
public class Avoider : Kinematic
{
    CollisionAvoidance myAvoidType;

    public Kinematic[] myTargets = new Kinematic[4];

    // Start is called before the first frame update
    void Start()
    {
        myAvoidType = new CollisionAvoidance();
        myAvoidType.character = this;
        myAvoidType.targets = myTargets;
    }

    // Update is called once per frame
    protected override void Update()
    {
        steeringUpdate = myAvoidType.getSteering();
        base.Update();
    }
}