using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : Seek
{
    public GameObject[] pathTargets;

    private int currentPathTarget = 0;

    private float targetReachedTheshold = 2f;

    protected override Vector3 getTargetPosition()
    {
        // get distance to current target on path
        Vector3 direction = character.transform.position - target.transform.position;
        float distance = direction.magnitude;

        // If target has been reached increment to next target
        if (distance < targetReachedTheshold)
        {
            ++currentPathTarget;
        }

        if (currentPathTarget > pathTargets.Length - 1)
        {
            currentPathTarget = 0;
        }

        target = pathTargets[currentPathTarget];


        return base.getTargetPosition();
    }
}
