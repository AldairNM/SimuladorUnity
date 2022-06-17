using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class union : MonoBehaviour
{
    public float swayAmoun = 8;
    public Vector3 posision;
    public int i;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        name = "Union" + i;
        animator.SetBool("isCurrent", true);
    }
    public void cambioO()
    {
        i--;
        name = "Union" + i;
        animator.SetBool("isCurrent", true);
    }
}
