using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubito : MonoBehaviour
{
    public float swayAmoun = 8;
    public Vector3 posision;
    public int i;
    public int c;
    public int d;
    Color normalColor;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalColor = meshRenderer.materials[0].color;
    }
    void OnMouseOver()
    {
        meshRenderer.materials[0].color = Color.blue;
    }
    void OnMouseExit()
    {   
        meshRenderer.materials[0].color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        float velo = swayAmoun * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posision, velo);
    }
    public void cambioI()
    {
        i++;
        name = "Cubo" + i;
    }
    public void cambioO()
    {
        i--;
        name = "Cubo" + i;
    }
   
}
