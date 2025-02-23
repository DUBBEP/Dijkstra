using UnityEngine;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;

    [SerializeField]
    private Transform scalingAnchor;

    private float height;

    private void Awake()
    {
        SetRandomHeight();
    }

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, n.transform.position);
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }

    private void SetHeight()
    {
        scalingAnchor.localScale = new Vector3(scalingAnchor.localScale.x, height, scalingAnchor.localScale.z);
    }

    public float GetHeight()
    {
        return height;
    }

    public void GiveNewHeight(float height)
    {
        this.height = height;
        SetHeight();
    }

    public void SetRandomHeight()
    {
        height = Random.Range(0.2f, 4f);
        SetHeight();
    }

    public void SetNodeColor(Color color)
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        renderer.material.color = color;
    }

}