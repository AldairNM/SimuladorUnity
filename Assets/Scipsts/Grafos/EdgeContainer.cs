using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeContainer : MonoBehaviour
{
    public Edge<float, Vector3> edge;

    [SerializeField]
    LineRenderer lineRenderer;


    private void Update()
    {
        if (edge != null)
        {
            lineRenderer.SetPosition(0, edge.From.Value);
            lineRenderer.SetPosition(1, edge.To.Value);
        }
    }
}
