using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class union : MonoBehaviour
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

    public void SetCubo(GameObject cubo)
    {
        JoinInicio.GetComponent<UnionJoin>().cubo = cubo;
    }
    public void SetCuboF(GameObject cubo)
    {
        JoinFinal.GetComponent<UnionJoin>().cuboFinalJoin = cubo;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponent<MeshRenderer>();
        normalColor = meshRenderer.materials[0].color;
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
        //Inicio de la unión
        lineRenderer.SetPosition(0, JoinInicio.transform.localPosition);


        //Final de la unión
        lineRenderer.SetPosition(1, JoinFinal.transform.localPosition);
        float velo = swayAmoun * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, posision, velo);
    }
    public void cambioI()
    {
        i++;
        name = "Union" + i;
        animator.enabled = true;
        animator.SetBool("isCurrent", true);
        JoinFinal.GetComponent<UnionJoin>().RefreshJoinPosition();

    }
    public void cambioO()
    {
        i--;
        name = "Union" + i;
        animator.enabled = true;
        animator.SetBool("isCurrent", true);
        JoinFinal.GetComponent<UnionJoin>().RefreshJoinPosition();
    }
}
