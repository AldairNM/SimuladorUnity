using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeArbolContainer : MonoBehaviour
{
    public ArbolManager.ArbolBinarioOrdenado.Nodo node;

    public Text ValueTxt;

    public int value;

    [SerializeField]
    LineRenderer lrLeft;

    [SerializeField]
    LineRenderer lrRight;

    [SerializeField]
    Transform particleTransform;

    private void Update()
    {
        node.particlePosition = particleTransform.position;
        if (node.izq != null)
        {
            lrLeft.enabled = true;
            if(lrLeft != null)
            {
                lrLeft.transform.position = Vector3.zero;
                lrLeft.SetPosition(0, node.particlePosition);
                lrLeft.SetPosition(1, node.izq.particlePosition);
            }
        }
        if (node.der != null)
        {
            lrRight.enabled = true;
            if (lrRight != null)
            {
                lrRight.transform.position = Vector3.zero;
                lrRight.SetPosition(0, node.particlePosition);
                lrRight.SetPosition(1, node.der.particlePosition);
            }
        }

    }
    public void UpdateValue(int value)
    {
        ValueTxt.text = ""+value;
        this.value = value;
        gameObject.transform.position = node.position;
    }
}
