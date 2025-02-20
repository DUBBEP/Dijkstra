using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Seek
{
    // the radius and forward offset of the wander circle
    public float wanderOffSet;
    public float wanderRadius;

    public float wanderRate;

    private Vector2 wanderOrientation;

    

    protected override Vector3 getTargetPosition()
    {

        Vector3 targetPosition = character.transform.position + wanderOffSet * character.transform.TransformDirection(Vector3.forward);
        wanderOrientation += Random.insideUnitCircle * wanderRadius * wanderRate;

        Vector3 target = new Vector3(targetPosition.x + wanderOrientation.x, 0, targetPosition.z + wanderOrientation.y);

        return target;

    }
}
