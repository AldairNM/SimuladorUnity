using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeArbolContainer : MonoBehaviour
{
    public ArbolManager.ArbolBinarioOrdenado.Nodo node;

    public Text ValueTxt;

    public int value;
    public void PrintInfo()
    {
        Debug.Log("Info: "+ node.info);
    }

    public void SetValue(int value)
    {
        ValueTxt.text = ""+value;
        this.value = value;
    }
}
