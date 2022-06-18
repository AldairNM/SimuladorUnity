using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class ArrayInsert : MonoBehaviour
{
    public GameObject cubo;
    public TMP_InputField tamaño1;
    public TMP_InputField tamaño2;
    public GameObject valorI;
    public GameObject cuboclon;
    GameObject[] cubos;
    GameObject[] cubos2;
    String[] cubos3=new String[100];

    Vector3 posision = new Vector3(-16.52f, 1.02f, -11.12f);
    Vector3 posisionI = new Vector3(-16.52f, 1.02f, -11.12f);
    Vector3 posisionO = new Vector3(-16.52f, 1.02f, -11.12f);
    int c = 0;
    int i = 0;
    int n=0;
    int m = 0;

    public void Creararray()
    {
        n = int.Parse(tamaño1.text);
        cubos=new GameObject[n];
        for(int x=0; x < n; x++)
        {
            Vector3 espacio = new Vector3(0, 0, 1.68f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().managerType = 2;
            newCubo.GetComponent<cubito>().posision = posisionO;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = " ";
            newCubo.tag = "CUBO";
            posisionO = posisionO + espacio;
            cubos[x] = newCubo;
            i = i + 1;
        }
    }
    public void ingresar()
    {
        if (c<=i) 
        {
            string valor = valorI.GetComponent<TMP_Text>().text;
            cuboclon = GameObject.Find("Cubo" + c);
            cuboclon.GetComponentInChildren<TMP_Text>().text = valor;
            cubos3[c] = cuboclon.GetComponentInChildren<TMP_Text>().text;
            c++;

        }
        Debug.Log(c);
    }
    public void eliminar()
    {
        if (c>=0)
        {
            int xd = c - 1;
            cuboclon = GameObject.Find("Cubo" + xd);
            cuboclon.GetComponentInChildren<TMP_Text>().text = " ";
            cubos3[c] = cuboclon.GetComponentInChildren<TMP_Text>().text;
            if (c!=0)
            {
                c--;
            }
        }
        Debug.Log(c);

    }
    public void aumentar()
    {
        posisionO = new Vector3(-16.52f, 1.02f, -11.12f);
        Vector3 espacio2 = new Vector3(0, 5.82f, 0);
        foreach (GameObject cubo in cubos)
        {
            cubo.GetComponent<cubito>().posision = cubo.transform.position + espacio2;
        }
        foreach (GameObject cubo in cubos)
        {
            Destroy(cubo, 5);
        }
        i = 0;
        m = int.Parse(tamaño2.text);
        int a = n + m;
        n = a;
        cubos = new GameObject[n];
        for (int x = 0; x < n; x++)
        {
            Vector3 espacio = new Vector3(0, 0, 1.68f);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().managerType = 2;
            newCubo.GetComponent<cubito>().posision = posisionO;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = " ";
            newCubo.tag = "CUBO";
            posisionO = posisionO + espacio;
            cubos[x] = newCubo;
            i = i + 1;
        }
        for (int x=0; x<=c;x++)
        {
            cubos[x].GetComponentInChildren<TMP_Text>().text = cubos3[x];
        }

    }

}
