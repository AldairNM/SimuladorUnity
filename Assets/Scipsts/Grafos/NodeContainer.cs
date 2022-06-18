using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeContainer : MonoBehaviour
{
    public Node<Vector3> node;
    
    Color normalColor;

    [SerializeField]
    MeshRenderer meshRenderer;

    public bool isSelected = false;
    Vector2 mousePos;
    float zDistance = 5.0f;
    Vector3 mouseToWorldPos;

    private void Start()
    {
        normalColor = meshRenderer.materials[0].color;
    }

    private void Update()
    {
        if (node != null)
        {
            if (!GraphComponent.isCreatorMode)
            {
                if (isSelected)
                {
                    mousePos = Input.mousePosition;
                    mouseToWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
                    this.transform.position = mouseToWorldPos;
                }
            }

            node.Value = transform.Find("Particle").position;
            Debug.Log(node.Value);
            

            if (Input.GetMouseButtonUp(0))
            {
                isSelected = false;
                meshRenderer.materials[0].color = normalColor;
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !GraphComponent.isCreatorMode)
        {
            isSelected = true;
        }

        meshRenderer.materials[0].color = Color.blue;
    }

    void OnMouseExit()
    {
        if (!isSelected) meshRenderer.materials[0].color = normalColor;
    }
}
