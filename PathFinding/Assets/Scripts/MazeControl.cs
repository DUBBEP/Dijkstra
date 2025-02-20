using UnityEngine;

public class MazeControl : MonoBehaviour
{
    [SerializeField]
    Transform flockTarget;

    [SerializeField]
    Vector3 verticalOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool hasHit = Physics.Raycast(ray, out hit);

            if (hasHit)
            {
                if (hit.transform.tag == "Floor")
                {
                    flockTarget.position = hit.point + verticalOffset;
                }
            }
        }
    }
}
