using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionJoin : MonoBehaviour
{

    public float swayAmoun = 8;

    public bool isSelected = false;
    Vector2 mousePos;
    float zDistance = 5.0f;
    Vector3 mouseToWorldPos;


    Color normalColor;
    MeshRenderer meshRenderer;

    [SerializeField]
    Transform joinRef;

    public GameObject cubo;
    public GameObject cuboFinalJoin;
    public GameObject cuboAux;

    [SerializeField]
    bool isInitJoin = false;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        normalColor = meshRenderer.materials[0].color;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) isSelected = true;
        meshRenderer.materials[0].color = Color.blue;
    }

    public void RefreshJoinPosition()
    {
        if (cuboFinalJoin && !isInitJoin) cuboFinalJoin = ListaInsert.LastCube;
    }



    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (cuboFinalJoin && !isInitJoin) transform.position = cuboFinalJoin.transform.position;
        else
        {
            if (Input.GetMouseButtonUp(0))
            {
                isSelected = false;
                if (cubo) cubo.GetComponent<cubito>().canMove = true;
            }

            if (!isSelected) transform.position = Vector3.MoveTowards(transform.position, joinRef.position, swayAmoun * Time.deltaTime);
            else
            {
                if (Input.GetMouseButton(0))
                {
                    if (cubo) cubo.GetComponent<cubito>().canMove = false;
                    mousePos = Input.mousePosition;
                    mouseToWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
                    this.transform.position = mouseToWorldPos;
                    if (cubo) cubo.transform.position = mouseToWorldPos;
                }
            }
            if (!Input.GetMouseButton(0))
            {
                if (cubo) cubo.GetComponent<cubito>().canMove = true;
            }
        }
        if(Input.GetMouseButtonUp(0)) meshRenderer.materials[0].color = normalColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(time > 0.5f && !cuboFinalJoin && other.gameObject.tag=="CUBO" && !isInitJoin)
        {
            cuboFinalJoin = other.gameObject;
            cuboFinalJoin.GetComponent<cubito>().canMove = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isInitJoin) time = 5;
    }


    void OnMouseExit()
    {
        if (!isSelected) meshRenderer.materials[0].color = normalColor;
    }
}
