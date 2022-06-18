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

    public bool canMove = true;

    [SerializeField]
    int indice = 0;


    [SerializeField]
    ListaInsert listaInsert;

    [SerializeField]
    PilaInsert pilaInsert;

    public int managerType = 0; // 0 = lista enlazada | 1 = pila

    // Start is called before the first frame update
    void Start()
    {
        UpdateInsert();
    }

    public void UpdateInsert()
    {
        if (managerType == 0) listaInsert = GameObject.Find("ManagerInsert").GetComponent<ListaInsert>();
        if (managerType == 1) pilaInsert = GameObject.Find("ManagerPila").GetComponent<PilaInsert>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) transform.position = Vector3.MoveTowards(transform.position, posision, swayAmoun * Time.deltaTime);
    }

    void OnMouseOver()
    {
        string numberrr = gameObject.name.Remove(0, 4);
        if (Input.GetMouseButtonDown(1))
        {
            if(managerType == 0)
            {
                if (GameObject.FindGameObjectsWithTag("CUBO").Length == 1) listaInsert.valorE.text = "0";
                else listaInsert.valorE.text = numberrr;
                listaInsert.ObtenerValorEli(3);
            }
            if(managerType == 1)
            {

            }
        }
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
