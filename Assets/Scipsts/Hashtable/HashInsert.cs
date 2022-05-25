using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HashInsert : MonoBehaviour
{
    public GameObject cubo;
    public GameObject union;
    public GameObject value;


    public TMP_InputField tamaño;
    public TMP_InputField valueValor;
    public GameObject valueValorString;
    public TMP_InputField valueValorE;

    public GameObject cuboclon;
    public GameObject unionclon;
    public GameObject valueclon;
    Dictionary<GameObject, GameObject> CubitosXD;
    Hashtable hashtableXD;

    GameObject[] cubos;
    GameObject[] cubos2;
    GameObject[] uniones;
    GameObject[] values;

    Vector3 posision = new Vector3(-16.75f, 8.64f, -11.082f);
    Vector3 posisionI = new Vector3(-16.75f, 8.64f, -11.082f);
    Vector3 posisionO = new Vector3(-16.75f, 8.64f, -11.082f);


    int c = 0;
    int i = 0;
    int n = 0;


    public void Crearhash()
    {
        CubitosXD = new Dictionary<GameObject, GameObject>();
        hashtableXD = new Hashtable(CubitosXD);

        n = int.Parse(tamaño.text);
        cubos = new GameObject[n];
        for (int x = 0; x < n; x++)
        {
            Vector3 espacio = new Vector3(0, 1.44f, 0);
            GameObject newCubo;
            newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
            newCubo.GetComponent<cubito>().posision = posisionO;
            newCubo.name = "Cubo" + i;
            newCubo.GetComponent<cubito>().i = i;
            newCubo.GetComponentInChildren<TMP_Text>().text = i.ToString();
            newCubo.tag = "CUBO";
            posisionO = posisionO - espacio;
            cubos[x] = newCubo;
            i = i + 1;
        }
    }
    public void Insertarhash()
    {

        string valor = valueValorString.GetComponent<TMP_Text>().text;
        int valor3 = int.Parse(valueValor.text);
        Vector3 espacio = new Vector3(0, 1.44f, 0);
        Vector3 espacio2 = new Vector3(0, 0, 1.68f);
        Vector3 uni = new Vector3(0, 0, 0.76f);
        Vector3 ubi = new Vector3(-16.75f, 8.64f, -11.082f);
        int i2 = 0;


        int a = valor3 % 10;

        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i == a)
            {
                ubi = cubo.transform.position;
                i2 = cubo.GetComponent<cubito>().i;
            }
        }
        if (GameObject.Find("Union" + i2))
        {
            values = GameObject.FindGameObjectsWithTag("VALUE");
            foreach (GameObject value in values)
            {
                if (value.GetComponent<valuec>().i == i2)
                {
                    ubi = value.transform.position;
                    i2 = value.GetComponent<valuec>().i;
                }
            }
            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = ubi + uni + uni + (uni / 2);
            newunion.name = "Union" + i2;
            newunion.GetComponent<union>().i = i2;
            newunion.tag = "UNION";

            GameObject newValue;
            newValue = Instantiate(value, cubo.transform.position, value.transform.rotation);
            newValue.GetComponent<valuec>().posision = ubi + uni + uni + uni + espacio2;
            newValue.name = "Value" + i2;
            newValue.GetComponent<valuec>().c = c;
            newValue.GetComponent<valuec>().i = i2;
            newValue.GetComponent<valuec>().d = valor3;
            newValue.tag = "VALUE";
            newValue.GetComponentInChildren<TMP_Text>().text = valor;

            CubitosXD.Add(newunion, newValue);
            hashtableXD = new Hashtable(CubitosXD);

        }
        else
        {
            GameObject newunion;
            newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
            newunion.GetComponent<union>().posision = ubi + uni;
            newunion.name = "Union" + i2;
            newunion.GetComponent<union>().i = i2;
            newunion.tag = "UNION";

            GameObject newValue;
            newValue = Instantiate(value, cubo.transform.position, value.transform.rotation);
            newValue.GetComponent<valuec>().posision = ubi + uni + espacio2;
            newValue.name = "Value" + i2;
            newValue.GetComponent<valuec>().c = c;
            newValue.GetComponent<valuec>().i = i2;
            newValue.GetComponent<valuec>().d = valor3;
            newValue.tag = "VALUE";
            newValue.GetComponentInChildren<TMP_Text>().text = valor;

            CubitosXD.Add(newunion, newValue);
            hashtableXD = new Hashtable(CubitosXD);
        }

        Debug.Log(hashtableXD.Count);

        foreach (DictionaryEntry kvp in hashtableXD)
            Debug.Log(kvp.Key + " " + kvp.Value);
    }
    public void iespecificoE()
    {
        int w = int.Parse(valueValorE.text);
        int z = 0;
        Vector3 uni2 = new Vector3(0, 0, 0);
        Vector3 uni21 = new Vector3(0, 0, 0);
        Vector3 espacio2 = new Vector3(0, 0, 1.68f);
        Vector3 uni = new Vector3(0, 0, 0.76f);
        Vector3 espacio = new Vector3(0, 1.44f, 0);
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i == w)
            {
                z = cubo.GetComponent<cubito>().i;
                uni2 = new Vector3(0, 0, 0);
                uni21 = new Vector3(0, 0, 0);
            }
        }

        unionclon = GameObject.Find("Union" + z);
        Destroy(unionclon);
        valueclon = GameObject.Find("Value" + z);
        Destroy(valueclon);
        
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        foreach (GameObject union in uniones)
        {
            if (union.GetComponent<union>().i == z)
            {
                union.GetComponent<union>().posision = union.transform.position - espacio2 - espacio2 - uni2;
                if (uni2.z< (uni / 2).z) 
                {
                    uni2 = uni2 + (uni / 2);
                } 
            }
        }
        
        values = GameObject.FindGameObjectsWithTag("VALUE");
        foreach (GameObject value in values)
        {
            if (value.GetComponent<valuec>().i == z)
            {
                value.GetComponent<valuec>().posision=value.transform.position - espacio2 - espacio2-uni21;
                if (uni21.z < (uni / 2).z)
                {
                    uni21 = uni21 + (uni / 2);
                }
            }
        }

        CubitosXD.Remove(unionclon);
        hashtableXD = new Hashtable(CubitosXD);

        Debug.Log(hashtableXD.Count);

        foreach (DictionaryEntry kvp in hashtableXD)
            Debug.Log(kvp.Key + " " + kvp.Value);
    }
}
