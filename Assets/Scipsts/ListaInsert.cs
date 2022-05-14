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

    Vector3 posision = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionI = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionO = new Vector3(-17.65371f, 2.58f, -7.19f);
    int c = 0;
    int i = 0;
    public class LinkedList
    {
        public Node head=null;
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
    public void ObtenerValor(int x)
    {
        if (x == 1)
        {
            string dato1 = valor1.GetComponent<TMP_Text>().text;
            alinicio(dato1);
        }
        else
        {
            if (x == 2)
            {
                string dato1 = valor2.GetComponent<TMP_Text>().text;
                alfinal(dato1);
            }
            else
            {
                if (x == 3)
                {
                    string dato1 = valor3.GetComponent<TMP_Text>().text;
                    int i = int.Parse(valor31.text);
                    iespecifico(dato1, i);
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
        
        if (vtx.next==null)
        {
            lista.tail = lista.head;
            i = 0;
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo"+i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            GameObject newnada;
            newnada = Instantiate(nada, nada.transform.position, nada.transform.rotation);
            newnada.name = "Union" + i;


        }
        else
        {
            i=0;
            c=c+1;
            for (int x = 0; x < c; x++)
            {
                cuboclon = GameObject.Find("Cubo" + x);
                cuboclon.GetComponent<cubito>().cambioI();
                unionclon = GameObject.Find("Union" + x);
                unionclon.GetComponent<union>().cambioI();
            }
            

            Vector3 espacio = new Vector3(0, 0, 1.68f);
            Vector3 uni = new Vector3(0, 0, 1.00f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posisionI - espacio;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posisionI - espacio + uni;
            newunion.name = "Union" + i;
            posisionI = posisionI - espacio;
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
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            GameObject newnada;
            newnada = Instantiate(nada, nada.transform.position, nada.transform.rotation);
            newnada.name = "Union" + i;

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
                Vector3 uni = new Vector3(0, 0, 1.00f);
                GameObject newunion;
                newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
                newunion.GetComponent<union>().posision = posisionO + espacio - uni;
                newunion.name = "Union" + i;
                posisionO = posisionO + espacio;
            }
        }
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void iespecifico(string valor, int w)
    {
        int x=0;
        Vector3 espacio = new Vector3(0, 0, 1.68f);
        Vector3 espacio1 = new Vector3(0, 0, 0.21f);
        cuboclon = GameObject.Find("Cubo" + w);
        Vector3 ubi = cuboclon.transform.position;
        Vector3 uni = new Vector3(0, 0, 1.00f);
        LinkedList.Node pre = lista.head;
        for (int k = 0; k < w-1; k++)
        {
            pre = pre.next;
            x = k;
        }
        i = w;
        c = c + 1;
        /*for(int a = 0; a < w; a++)
        {
            cuboclon = GameObject.Find("Cubo" + a);
            cuboclon.GetComponent<cubito>().posision = cuboclon.transform.position - espacio1;
            unionclon = GameObject.Find("Union" + a);
            unionclon.GetComponent<union>().posision = unionclon.transform.position - espacio1;
        }
        posisionI = posisionI - espacio;*/
        for (int a = w; a >= w && a < c; a++)
        {
            cuboclon = GameObject.Find("Cubo" + a);
            cuboclon.GetComponent<cubito>().posision = cuboclon.transform.position + espacio;
            
            unionclon = GameObject.Find("Union" + a);
            unionclon.GetComponent<union>().posision = unionclon.transform.position + espacio;
        }
        posisionO = posisionO + espacio;
        for (int k = w; k < c; k++)
        {
            cuboclon = GameObject.Find("Cubo" + k);
            cuboclon.GetComponent<cubito>().cambioI();
            unionclon = GameObject.Find("Union" + k);
            unionclon.GetComponent<union>().cambioI();
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
        GameObject newunion;
        newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
        newunion.GetComponent<union>().posision = ubi + uni;
        newunion.name = "Union" + i;
        

    }
}
