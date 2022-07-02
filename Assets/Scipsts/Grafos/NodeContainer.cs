using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeContainer : MonoBehaviour
{
    public Node<Vector3> node;
    
    Color normalColor;

    [SerializeField]
    MeshRenderer meshRenderer;

    [SerializeField]
    public GameObject autoRef;
    public bool isSelected = false;
    Vector2 mousePos;
    float zDistance = 5.0f;
    Vector3 mouseToWorldPos;
    [SerializeField]
    Text numberTxt;

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
            
            

            if (Input.GetMouseButtonUp(0))
            {
                isSelected = false;
                if(!GraphComponent.isEdgeMode) SetNormalColor();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                isSelected = false;
                SetNormalColor();
            }
        }

    }

    public void SetNumber(int value)
    {
        numberTxt.text = value + "";
    }
    public void SetAutoRef()
    {
        autoRef.SetActive(!autoRef.activeSelf);
    }

    void OnMouseOver()
    {
        meshRenderer.materials[0].color = Color.blue;

        if (Input.GetMouseButtonDown(0) && !GraphComponent.isCreatorMode)
        {
            isSelected = true;
        }

        if (Input.GetMouseButtonDown(0) && GraphComponent.isEdgeMode)
        {
            SelectNode();
        }
    }

    void SelectNode()
    {
        if (GraphComponent.fromNodeAux == null)
        {
            GraphComponent.fromNodeAux = gameObject;
            return;
        }
        if (GraphComponent.toNodeAux == null)
        {
            GraphComponent.toNodeAux = gameObject;
            return;
        }
    }

    public void SetNormalColor()
    {
        meshRenderer.materials[0].color = normalColor;
    }
    void OnMouseExit()
    {
        if (!isSelected) SetNormalColor();
    }
}
