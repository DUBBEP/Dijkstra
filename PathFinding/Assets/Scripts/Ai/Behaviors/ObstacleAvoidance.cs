using UnityEngine;

public class ObstacleAvoidance : Seek
{
    public float avoidDistance = 1f;

    public float lookahead = 3f;

    protected override Vector3 getTargetPosition()
    {
        Vector3 direction = (target.transform.position - character.transform.position).normalized;

        direction = new Vector3(direction.x, 0, direction.z);


        Debug.DrawRay(character.transform.position, direction);

        RaycastHit hit;
        if (Physics.Raycast(character.transform.position, direction, out hit, lookahead) && hit.transform.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("avoiding obstacle");
            return hit.point - (hit.normal * avoidDistance);
        }
        else
        {
            return Vector3.one * 10000;
        }
    }
}
