using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class union2 : MonoBehaviour
{
    public float swayAmoun = 8;
    public Vector3 posision;
    public int i;

    Animator animator;
    Color normalColor;
    MeshRenderer meshRenderer;

    [SerializeField]
    LineRenderer lineRenderer;

    [SerializeField]
    GameObject JoinInicio;

    [SerializeField]
    GameObject JoinFinal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        normalColor = meshRenderer.materials[0].color;
    }
    public void SetCubo(GameObject cubo)
    {
        JoinInicio.GetComponent<UnionJoin>().cubo = cubo;
    }

    void OnMouseOver()
    {

        animator.enabled = false;
        meshRenderer.materials[0].color = Color.yellow;
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Insertando en indice: ");
        }
    }

    void OnMouseExit()
    {
        meshRenderer.materials[0].color = normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(lineRenderer!=null)
        {
            lineRenderer.SetPosition(0, JoinInicio.transform.localPosition);


            //Final de la uni?n
            lineRenderer.SetPosition(1, JoinFinal.transform.localPosition);
        }
        //Inicio de la uni?n
        
        float velo = swayAmoun * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posision, velo);
    }
    public void cambioI()
    {
        i++;
        name = "Union2" + i;
        animator.enabled = true;
        animator.SetBool("isCurrent", true);
    }
    public void cambioO()
    {
        i--;
        name = "Union2" + i;
        animator.enabled = true;
        animator.SetBool("isCurrent", true);
    }
}
