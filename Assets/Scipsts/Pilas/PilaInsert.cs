using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class PilaInsert : MonoBehaviour
{
    public GameObject cubo;
    public GameObject union;
    public GameObject valor1;
    private LinkedList lista;
    public GameObject cuboclon;
    public GameObject unionclon;
    GameObject[] cubos;
    GameObject[] uniones;

    [SerializeField]
    Transform lookAtTransform;
    Vector3 posision = new Vector3(-16.26f, 0.75f, -7.05f);
    Vector3 posisionI = new Vector3(-16.26f, 0.75f, -7.05f);
    Vector3 posisionO = new Vector3(-16.26f, 0.75f, -7.05f);
    int c = 0;
    int i = 0;
    // Start is called before the first frame update
    public class LinkedList
    {
        public Node head = null;
        public Node tail;
        public class Node
        {
            public string data;
            public Node next;
            public Node(string d)
            {
                data = d;
                next = null;
            } // Constructor
        }
    }
    public void CrearLista()
    {
        lista = new LinkedList();
    }
    public void alfinal()
    {
        string valor = valor1.GetComponent<TMP_Text>().text;
        LinkedList.Node vtx = new LinkedList.Node(valor);
        if (lista.head == null)
        {
            vtx.next = lista.head;
            lista.head = vtx;
            lista.tail = lista.head;
            i = 0;
            Vector3 uni = new Vector3(0, 1.00f, 0);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.GetComponent<cubito>().managerType = 1;
            newCubo.GetComponent<cubito>().UpdateInsert();
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";

            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posision + uni;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";
            newunion.GetComponent<union>().SetCubo(newCubo);

            lookAtTransform.position = posisionO;
        }
        else
        {
            if (lista.head.next == null || lista.head.next != null)
            {
                c = c + 1;
                i = c;
                lista.tail.next = vtx;
                lista.tail = vtx;
                Vector3 espacio = new Vector3(0, 1.68f, 0);
                GameObject newCubo;
                newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
                newCubo.GetComponent<cubito>().posision = posisionO + espacio;
                newCubo.GetComponent<cubito>().managerType = 1;
                newCubo.GetComponent<cubito>().UpdateInsert();
                newCubo.name = "Cubo" + i;
                newCubo.GetComponent<cubito>().c = c;
                newCubo.GetComponent<cubito>().i = i;
                newCubo.GetComponentInChildren<TMP_Text>().text = valor;
                newCubo.tag = "CUBO";

                Vector3 uni = new Vector3(0, 1.00f, 0);
                GameObject newunion;
                newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
                newunion.GetComponent<union>().posision = posisionO + espacio + uni;
                newunion.name = "Union" + i;
                newunion.GetComponent<union>().i = i;
                newunion.tag = "UNION";
                newunion.GetComponent<union>().SetCubo(newCubo);
                posisionO = posisionO + espacio;

                lookAtTransform.position = posisionO;
            }
        }
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void alfinalE()
    {
        LinkedList.Node pre = lista.head;
        Vector3 espacio = new Vector3(0, 1.68f, 0);
        LinkedList.Node temp = pre.next;
        if (i != 0)
        {
            while (temp.next != null)
            {
                pre = pre.next;
                temp = temp.next;
            }
            pre.next = null;
        }


        lista.tail = pre;

        cuboclon = GameObject.Find("Cubo" + i);
        cuboclon.GetComponent<cubito>().posision = cubo.transform.position;
        Destroy(cuboclon, 1);
        unionclon = GameObject.Find("Union" + i);
        unionclon.GetComponent<union>().posision = cubo.transform.position;
        Destroy(unionclon, 1);
        posisionO = posisionO - espacio;
        c--;
        i = c;


        lookAtTransform.position = posisionO;


        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
}
