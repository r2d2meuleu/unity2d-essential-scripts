using UnityEngine;

[RequireComponent(typeof(LineRenderer))] //Remember to setup the Line Render in the inspector
public class LineRender : MonoBehaviour
{
    LineRenderer lineRenderer;

    public static LineRender instance;

    private void Awake()
    {
        instance = this;
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lineRenderer.SetPositions(points);
    }

    public void EndLine()
    {
        lineRenderer.positionCount = 0;
    }
}
