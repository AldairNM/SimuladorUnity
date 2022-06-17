using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;



public class ListaInsert : MonoBehaviour
{
    public GameObject cubo;
    public GameObject union;
    public GameObject valor1;
    public GameObject valor2;
    public GameObject valor3;
    public TMP_InputField valor31;
    private LinkedList lista;
    public GameObject nada;
    public GameObject cuboclon;
    public GameObject unionclon;
    GameObject[] cubos;
    GameObject[] uniones;
    cubito lastCubito;
    [SerializeField]
    Transform lookAtTransform;
    [SerializeField]
    GameObject vcm;



    public TMP_InputField valorE;

    Vector3 posision = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionI = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionO = new Vector3(-17.65371f, 2.58f, -7.19f);
    int c = 0;
    int i = 0;

    private void Update()
    {
    }
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

    void UpdateCameraLookAt(Vector3 pos)
    {
        lookAtTransform.position = pos;
    }
    public void ObtenerValor(int x)
    {
        if (x == 1)
        {
            string dato1 = valor1.GetComponent<TMP_Text>().text;
            alinicio(dato1);
            UpdateCameraLookAt(posisionI);
        }
        else
        {
            if (x == 2)
            {
                string dato1 = valor2.GetComponent<TMP_Text>().text;
                alfinal(dato1);
                UpdateCameraLookAt(posisionO);
            }
            else
            {
                if (x == 3)
                {
                    string dato1 = valor3.GetComponent<TMP_Text>().text;
                    int i = int.Parse(valor31.text);
                    iespecifico(dato1, i);
                    UpdateCameraLookAt(posisionO);
                }
            }
        }
    }

    public void ObtenerValorEli(int x)
    {
        if (x == 1)
        {
            alinicioE();
            UpdateCameraLookAt(posisionI);
        }
        else
        {
            if (x == 2)
            {
                alfinalE();
                UpdateCameraLookAt(posisionO);
            }
            else
            {
                if (x == 3)
                {
                    int i = int.Parse(valorE.text);
                    iespecificoE(i);
                    UpdateCameraLookAt(posision);
                }
            }
        }
    }
    public void CrearLista()
    {
        lista = new LinkedList();
    }
    public void alinicio(string valor)
    {
        LinkedList.Node vtx = new LinkedList.Node(valor);
        vtx.next = lista.head;
        lista.head = vtx;

        if (vtx.next == null)
        {
            lista.tail = lista.head;
            i = 0;
            Vector3 uni = new Vector3(0, 0, 1.00f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";
            lastCubito = GetComponent<cubito>();
            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posision + uni;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";


        }
        else
        {
            i = 0;
            c = c + 1;
            cubos = GameObject.FindGameObjectsWithTag("CUBO");
            uniones = GameObject.FindGameObjectsWithTag("UNION");
            foreach (GameObject cubo in cubos)
            {
                cubo.GetComponent<cubito>().cambioI();
            }
            foreach (GameObject union in uniones)
            {
                union.GetComponent<union>().cambioI();
            }


            /*for (int x = 0; x < c; x++)
            {
                cuboclon = GameObject.Find("Union" + x);
                cuboclon.GetComponent<cubito>().cambioI();
                unionclon = GameObject.Find("Union" + x);
                unionclon.GetComponent<union>().cambioI();
            }*/


            Vector3 espacio = new Vector3(0, 0, 1.68f);
            Vector3 uni = new Vector3(0, 0, 1.00f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posisionI - espacio;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";
            lastCubito = GetComponent<cubito>();


            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posisionI - espacio + uni;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";
            posisionI = posisionI - espacio;
            i = c;
        }

        Debug.Log(lista.head.data + " " + lista.tail.data);

    }
    public void alfinal(string valor)
    {
        LinkedList.Node vtx = new LinkedList.Node(valor);
        if (lista.head == null)
        {
            vtx.next = lista.head;
            lista.head = vtx;
            lista.tail = lista.head;
            i = 0;
            Vector3 uni = new Vector3(0, 0, 1.00f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";
            lastCubito = GetComponent<cubito>();

            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posision + uni;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";

        }
        else
        {
            if (lista.head.next == null || lista.head.next != null)
            {
                c = c + 1;
                i = c;
                lista.tail.next = vtx;
                lista.tail = vtx;
                Vector3 espacio = new Vector3(0, 0, 1.68f);
                GameObject newCubo;
                newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
                newCubo.GetComponent<cubito>().posision = posisionO + espacio;
                newCubo.name = "Cubo" + i;
                newCubo.GetComponent<cubito>().c = c;
                newCubo.GetComponent<cubito>().i = i;
                newCubo.GetComponentInChildren<TMP_Text>().text = valor;
                newCubo.tag = "CUBO";
                lastCubito = GetComponent<cubito>();

                Vector3 uni = new Vector3(0, 0, 1.00f);
                GameObject newunion;
                newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
                newunion.GetComponent<union>().posision = posisionO + espacio + uni;
                newunion.name = "Union" + i;
                newunion.GetComponent<union>().i = i;
                newunion.tag = "UNION";
                posisionO = posisionO + espacio;
            }
        }
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void iespecifico(string valor, int w)
    {
        int x = 0;
        Vector3 espacio = new Vector3(0, 0, 1.68f);
        Vector3 espacio1 = new Vector3(0, 0, 0.21f);
        cuboclon = GameObject.Find("Cubo" + w);
        Vector3 ubi = cuboclon.transform.position;
        Vector3 uni = new Vector3(0, 0, 1.00f);
        LinkedList.Node pre = lista.head;
        for (int k = 0; k < w - 1; k++)
        {
            pre = pre.next;
            x = k;
        }
        i = w;
        c = c + 1;

        for (int a = w; a >= w && a < c; a++)
        {
            cuboclon = GameObject.Find("Cubo" + a);
            cuboclon.GetComponent<cubito>().posision = cuboclon.transform.position + espacio;


            unionclon = GameObject.Find("Union" + a);
            unionclon.GetComponent<union>().posision = unionclon.transform.position + espacio;
        }

        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i >= w)
            {
                cubo.GetComponent<cubito>().cambioI();
            }
        }
        foreach (GameObject union in uniones)
        {
            if (union.GetComponent<union>().i >= w)
            {
                union.GetComponent<union>().cambioI();
            }
        }
        LinkedList.Node aft = pre.next;
        LinkedList.Node vtx = new LinkedList.Node(valor);
        vtx.next = aft;
        pre.next = vtx;
        GameObject newCubo;
        newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
        newCubo.GetComponent<cubito>().posision = ubi;
        newCubo.name = "Cubo" + i;
        newCubo.GetComponent<cubito>().c = c;
        newCubo.GetComponent<cubito>().i = i;
        newCubo.GetComponentInChildren<TMP_Text>().text = valor;
        newCubo.tag = "CUBO";
        lastCubito = GetComponent<cubito>();

        GameObject newunion;
        newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
        newunion.GetComponent<union>().posision = ubi + uni;
        newunion.name = "Union" + i;
        newunion.GetComponent<union>().i = i;
        newunion.tag = "UNION";
        posisionO = posisionO + espacio;
        i = c;
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void alinicioE()
    {
        LinkedList.Node temp = lista.head;
        Vector3 espacio = new Vector3(0, 0, 1.68f);
        lista.head = lista.head.next;

        temp.next=null;
        
        cuboclon = GameObject.Find("Cubo" + 0);
        cuboclon.GetComponent<cubito>().posision = cubo.transform.position;
        Destroy(cuboclon, 1);
        unionclon = GameObject.Find("Union" + 0);
        unionclon.GetComponent<union>().posision = cubo.transform.position;
        Destroy(unionclon, 1);
        posisionI = posisionI + espacio;

        if (c > 0)
        {
            for (int k = 1; k <= c; k++)
            {
                cuboclon = GameObject.Find("Cubo" + k);
                cuboclon.GetComponent<cubito>().cambioO();
                unionclon = GameObject.Find("Union" + k);
                unionclon.GetComponent<union>().cambioO();
            }
            c--;
            i = c;

        }
        


        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void alfinalE()
    {
        LinkedList.Node pre = lista.head;
        Vector3 espacio = new Vector3(0, 0, 1.68f);
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


        

        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void iespecificoE(int w)
    {
        Vector3 espacio = new Vector3(0, 0, 1.68f);
        LinkedList.Node pre = lista.head;
        for (int k = 0; k < w - 1; k++)
        {
            pre = pre.next;
        }
        
        cuboclon = GameObject.Find("Cubo" + w);
        cuboclon.GetComponent<cubito>().posision = cubo.transform.position;
        Destroy(cuboclon);
        unionclon = GameObject.Find("Union" + w);
        unionclon.GetComponent<union>().posision = cubo.transform.position;
        Destroy(unionclon);
        
        for (int a = w; a >= w && a <= c; a++)
        {
            cuboclon = GameObject.Find("Cubo" + a);
            cuboclon.GetComponent<cubito>().posision = cuboclon.transform.position - espacio;


            unionclon = GameObject.Find("Union" + a);
            unionclon.GetComponent<union>().posision = unionclon.transform.position - espacio;
        }

        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i >= w)
            {
                cubo.GetComponent<cubito>().cambioO();
            }
        }
        foreach (GameObject union in uniones)
        {
            if (union.GetComponent<union>().i >= w)
            {
                union.GetComponent<union>().cambioO();
            }
        }
        
        LinkedList.Node del = pre.next;
        LinkedList.Node aft = del.next;
        pre.next = aft;
        del.next = null;
        posisionO = posisionO - espacio; 
        c--;
        i = c;

        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
}
