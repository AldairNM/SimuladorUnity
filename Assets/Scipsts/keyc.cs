using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyc : MonoBehaviour
{
    public float swayAmoun = 8;
    public Vector3 posision;
    public int i;
    public int c;
    public int d;
    // Start is called before the first frame update
    void Start()
    {
        
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
        name = "Key" + i;
    }
    public void cambioO()
    {
        i--;
        name = "Key" + i;
    }
}
