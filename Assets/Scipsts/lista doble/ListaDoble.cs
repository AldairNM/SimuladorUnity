using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;



public class ListaDoble : MonoBehaviour
{
    public Transform LookAt;
    public GameObject cubo;
    public GameObject union;
    public GameObject union1;
    public GameObject valor1;
    public GameObject valor2;
    public GameObject valor3;
    public TMP_InputField valor31;
    private LinkedList lista;
    public GameObject nada;
    public GameObject cuboclon;
    public GameObject unionclon;
    public GameObject unionclon2;
    GameObject[] cubos;
    GameObject[] uniones;
    GameObject[] uniones2;
    public Vector3 espacio = new Vector3(0, 0, 2.68f);
    public Vector3 uni = new Vector3(0, 0, 1.00f);
    public Vector3 unid = new Vector3(0, 0, 1.00f);
    public TMP_InputField valorE;

    Vector3 posision = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionI = new Vector3(-17.65371f, 2.58f, -7.19f);
    Vector3 posisionO = new Vector3(-17.65371f, 2.58f, -7.19f);
    int c = 0;
    int i = 0;
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
    public void ObtenerValorEli(int x)
    {
        if (x == 1)
        {
            alinicioE();
        }
        else
        {
            if (x == 2)
            {
                alfinalE();
            }
            else
            {
                if (x == 3)
                {
                    int i = int.Parse(valorE.text);
                    iespecificoE(i);
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
            
            Vector3 uni2 = new Vector3(0, 0.3f, 0);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";


            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posision + unid + uni2;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";

            GameObject newunion2;
            newunion2 = Instantiate(union1, cubo.transform.position, union1.transform.rotation);
            newunion2.GetComponent<union2>().posision = posision - uni - uni2;
            newunion2.name = "Union2" + i;
            newunion2.GetComponent<union2>().i = i;
            newunion2.tag = "UNION2";


        }
        else
        {
            i = 0;
            c = c + 1;
            cubos = GameObject.FindGameObjectsWithTag("CUBO");
            uniones = GameObject.FindGameObjectsWithTag("UNION");
            uniones2 = GameObject.FindGameObjectsWithTag("UNION2");
            foreach (GameObject cubo in cubos)
            {
                cubo.GetComponent<cubito>().cambioI();
            }
            foreach (GameObject union in uniones)
            {
                union.GetComponent<union>().cambioI();
            }
            foreach (GameObject union2 in uniones2)
            {
                union2.GetComponent<union2>().cambioI();
            }


            /*for (int x = 0; x < c; x++)
            {
                cuboclon = GameObject.Find("Union" + x);
                cuboclon.GetComponent<cubito>().cambioI();
                unionclon = GameObject.Find("Union" + x);
                unionclon.GetComponent<union>().cambioI();
            }*/




            Vector3 uni2 = new Vector3(0, 0.3f, 0);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posisionI - espacio;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";
            LookAt.position = posisionO;

            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posisionI - espacio + unid+uni2;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";

            GameObject newunion2;
            newunion2 = Instantiate(union1, cubo.transform.position, union1.transform.rotation);
            newunion2.GetComponent<union2>().posision = posisionI - espacio - uni-uni2;
            newunion2.name = "Union2" + i;
            newunion2.GetComponent<union2>().i = i;
            newunion2.tag = "UNION2";


            posisionI = posisionI - espacio;


            LookAt.position = posisionI;
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

            Vector3 uni2 = new Vector3(0, 0.3f, 0);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posision;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().c = c;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = valor;
            newCubo.tag = "CUBO";
            LookAt.position = posision;

            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = posision + unid + uni2;
            newunion.name = "Union" + i;
            newunion.GetComponent<union>().i = i;
            newunion.tag = "UNION";

            GameObject newunion2;
            newunion2 = Instantiate(union1, cubo.transform.position, union1.transform.rotation);
            newunion2.GetComponent<union2>().posision = posision - uni - uni2;
            newunion2.name = "Union2" + i;
            newunion2.GetComponent<union2>().i = i;
            newunion2.tag = "UNION2";

        }
        else
        {
            if (lista.head.next == null || lista.head.next != null)
            {
                c = c + 1;
                i = c;
                lista.tail.next = vtx;
                lista.tail = vtx;

                GameObject newCubo;
                newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
                newCubo.GetComponent<cubito>().posision = posisionO + espacio;
                newCubo.name = "Cubo" + i;
                newCubo.GetComponent<cubito>().c = c;
                newCubo.GetComponent<cubito>().i = i;
                newCubo.GetComponentInChildren<TMP_Text>().text = valor;
                newCubo.tag = "CUBO";




                Vector3 uni2 = new Vector3(0, 0.3f, 0);
                GameObject newunion;
                newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
                newunion.GetComponent<union>().posision = posisionO + espacio + unid + uni2;
                newunion.name = "Union" + i;
                newunion.GetComponent<union>().i = i;
                newunion.tag = "UNION";

                GameObject newunion2;
                newunion2 = Instantiate(union1, cubo.transform.position, union1.transform.rotation);
                newunion2.GetComponent<union2>().posision = posisionO + espacio - uni - uni2;
                newunion2.name = "Union2" + i;
                newunion2.GetComponent<union2>().i = i;
                newunion2.tag = "UNION2";


                posisionO = posisionO + espacio;

                LookAt.position = posisionO;
            }
        }
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void iespecifico(string valor, int w)
    {
        int x = 0;

        Vector3 espacio1 = new Vector3(0, 0, 0.21f);
        cuboclon = GameObject.Find("Cubo" + w);
        Vector3 ubi = cuboclon.transform.position;
       
        Vector3 uni2 = new Vector3(0, 0.3f, 0);
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

            unionclon2 = GameObject.Find("Union2" + a);
            unionclon2.GetComponent<union2>().posision = unionclon2.transform.position + espacio;
        }

        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        uniones2 = GameObject.FindGameObjectsWithTag("UNION2");
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i == w )
            {

                LookAt.position = cubo.transform.position;
            }

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
        foreach (GameObject union2 in uniones2)
        {
            if (union2.GetComponent<union2>().i >= w)
            {
                union2.GetComponent<union2>().cambioI();
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

        GameObject newunion;
        newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
        newunion.GetComponent<union>().posision = ubi + unid + uni2;
        newunion.name = "Union" + i;
        newunion.GetComponent<union>().i = i;
        newunion.tag = "UNION";

        GameObject newunion2;
        newunion2 = Instantiate(union1, cubo.transform.position, union1.transform.rotation);
        newunion2.GetComponent<union2>().posision = ubi  - uni - uni2;
        newunion2.name = "Union2" + i;
        newunion2.GetComponent<union2>().i = i;
        newunion2.tag = "UNION2";


        posisionO = posisionO + espacio;


        i = c;
        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void alinicioE()
    {
        LinkedList.Node temp = lista.head;

        lista.head = lista.head.next;

        temp.next = null;

        cuboclon = GameObject.Find("Cubo" + 0);
        cuboclon.GetComponent<cubito>().posision = cubo.transform.position;
        Destroy(cuboclon, 1);
        unionclon = GameObject.Find("Union" + 0);
        unionclon.GetComponent<union>().posision = cubo.transform.position;
        Destroy(unionclon, 1);
        unionclon2 = GameObject.Find("Union2" + 0);
        unionclon2.GetComponent<union2>().posision = cubo.transform.position;
        Destroy(unionclon2, 1);
        posisionI = posisionI + espacio;

        if (c > 0)
        {
            for (int k = 1; k <= c; k++)
            {
                cuboclon = GameObject.Find("Cubo" + k);
                cuboclon.GetComponent<cubito>().cambioO();
                unionclon = GameObject.Find("Union" + k);
                unionclon.GetComponent<union>().cambioO();
                unionclon2 = GameObject.Find("Union2" + k);
                unionclon2.GetComponent<union2>().cambioO();
            }
            c--;
            i = c;

        }



        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void alfinalE()
    {
        LinkedList.Node pre = lista.head;

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
        unionclon2 = GameObject.Find("Union2" + i);
        unionclon2.GetComponent<union2>().posision = cubo.transform.position;
        Destroy(unionclon2, 1);
        posisionO = posisionO - espacio;
        c--;
        i = c;




        Debug.Log(lista.head.data + " " + lista.tail.data);
    }
    public void iespecificoE(int w)
    {

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
        unionclon2 = GameObject.Find("Union2" + w);
        unionclon2.GetComponent<union2>().posision = cubo.transform.position;
        Destroy(unionclon2);

        for (int a = w; a >= w && a <= c; a++)
        {
            cuboclon = GameObject.Find("Cubo" + a);
            cuboclon.GetComponent<cubito>().posision = cuboclon.transform.position - espacio;


            unionclon = GameObject.Find("Union" + a);
            unionclon.GetComponent<union>().posision = unionclon.transform.position - espacio;

            unionclon2 = GameObject.Find("Union2" + a);
            unionclon2.GetComponent<union2>().posision = unionclon2.transform.position - espacio;
        }

        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        uniones2 = GameObject.FindGameObjectsWithTag("UNION2");
        foreach (GameObject cubo in cubos)
        {
            if(cubo.GetComponent<cubito>().i == w)
            {

                LookAt.position = cubo.transform.position;
            }

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
        foreach (GameObject union2 in uniones2)
        {
            if (union2.GetComponent<union2>().i >= w)
            {
                union2.GetComponent<union2>().cambioO();
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
