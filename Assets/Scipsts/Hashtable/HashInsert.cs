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
    public GameObject key;
    public GameObject value;
    public GameObject key1;
    public TMP_InputField key1_1;
    public TMP_InputField key2;
    public GameObject valorI;
    public GameObject cuboclon;
    public GameObject unionclon;
    public GameObject keyclon;
    public GameObject valueclon;
    Dictionary<GameObject, GameObject> CubitosXD;
    Hashtable hashtableXD;
    GameObject[] cubos;
    GameObject[] uniones;
    GameObject[] keys;
    GameObject[] values;

    Vector3 posision = new Vector3(-16.75f, 8.64f, -11.082f);
    Vector3 posisionI = new Vector3(-16.75f, 8.64f, -11.082f);
    Vector3 posisionO = new Vector3(-16.75f, 8.64f, -11.082f);
    int c = 0;
    int i = 0;

    public void Crearhash()
    {
        CubitosXD = new Dictionary<GameObject, GameObject>();
        hashtableXD = new Hashtable(CubitosXD);
    }
    public void Insertarhash()
    {
        
        string valor = valorI.GetComponent<TMP_Text>().text;
        string valor2 = key1.GetComponent<TMP_Text>().text;
        int valor3 = int.Parse(key1_1.text);
        Vector3 espacio = new Vector3(0, 1.44f, 0);
        Vector3 espacio2 = new Vector3(0, 0, 1.68f);
        Vector3 uni = new Vector3(0, 0, 0.76f);


        GameObject newCubo;
        newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
        newCubo.GetComponent<cubito>().posision = posisionO ;
        newCubo.name = "Cubo" + i;
        newCubo.GetComponent<cubito>().c = c;
        newCubo.GetComponent<cubito>().i = i;
        newCubo.tag = "CUBO";
        newCubo.GetComponentInChildren<TMP_Text>().text = i.ToString();

        GameObject newunion;
        newunion = Instantiate(union, cubo.transform.position, union.transform.rotation);
        newunion.GetComponent<union>().posision = posisionO + uni;
        newunion.name = "Union" + i;
        newunion.GetComponent<union>().i = i;
        newunion.tag = "UNION";


        GameObject newKey;
        newKey = Instantiate(key, cubo.transform.position, key.transform.rotation);
        newKey.GetComponent<keyc>().posision = posisionO + espacio2;
        newKey.name = "Key" + i;
        newKey.GetComponent<keyc>().c = c;
        newKey.GetComponent<keyc>().i = i;
        newKey.GetComponent<keyc>().d = valor3;
        newKey.tag = "KEY";
        newKey.GetComponentInChildren<TMP_Text>().text = valor2;

        GameObject newValue;
        newValue = Instantiate(value, cubo.transform.position, value.transform.rotation);
        newValue.GetComponent<valuec>().posision = posisionO + espacio2 + espacio2 + espacio2;
        newValue.name = "Value" + i;
        newValue.GetComponent<valuec>().c = c;
        newValue.GetComponent<valuec>().i = i;
        newValue.tag = "VALUE";
        newValue.GetComponentInChildren<TMP_Text>().text = valor;

        posisionO = posisionO - espacio;
        c = c + 1;
        i = c;
        CubitosXD.Add(newKey, newValue);
        hashtableXD = new Hashtable(CubitosXD);


        Debug.Log(hashtableXD.Count);

        foreach (DictionaryEntry kvp in hashtableXD)
            Debug.Log(kvp.Key + " " + kvp.Value);
    }
    public void iespecificoE()
    {
        int w = int.Parse(key2.text);
        int z = 0;
        Vector3 espacio = new Vector3(0, 1.44f, 0);
        keys = GameObject.FindGameObjectsWithTag("KEY");
        foreach(GameObject key in keys)
        {
            if (key.GetComponent<keyc>().d == w)
            {
                z = key.GetComponent<keyc>().i;
            }
        }

        cuboclon = GameObject.Find("Cubo" + z);
        Destroy(cuboclon);
        unionclon = GameObject.Find("Union" + z);
        Destroy(unionclon);
        keyclon = GameObject.Find("Key" + z);
        Destroy(keyclon);
        valueclon = GameObject.Find("Value" + z);
        Destroy(valueclon);

        CubitosXD.Remove(keyclon);
        hashtableXD = new Hashtable(CubitosXD);
        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        keys = GameObject.FindGameObjectsWithTag("KEY");
        values = GameObject.FindGameObjectsWithTag("VALUE");
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i >= z)
            {
                cubo.GetComponent<cubito>().posision = cubo.transform.position + espacio;
            }
        }
        foreach (GameObject union in uniones)
        {
            if (union.GetComponent<union>().i >= z)
            {
                union.GetComponent<union>().posision = union.transform.position + espacio;
            }
        }
        foreach (GameObject key in keys)
        {
            if (key.GetComponent<keyc>().i >= z)
            {
                key.GetComponent<keyc>().posision = key.transform.position + espacio;
            }
        }
        foreach (GameObject value in values)
        {
            if (value.GetComponent<valuec>().i >= z)
            {
                value.GetComponent<valuec>().posision = value.transform.position + espacio;
            }
        }

        cubos = GameObject.FindGameObjectsWithTag("CUBO");
        uniones = GameObject.FindGameObjectsWithTag("UNION");
        keys = GameObject.FindGameObjectsWithTag("KEY");
        values = GameObject.FindGameObjectsWithTag("VALUE");
        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i >= z)
            {
                cubo.GetComponent<cubito>().cambioO();
                cubo.GetComponentInChildren<TMP_Text>().text = cubo.GetComponent<cubito>().i.ToString();
            }
        }
        foreach (GameObject union in uniones)
        {
            if (union.GetComponent<union>().i >= z)
            {
                union.GetComponent<union>().cambioO();
            }
        }
        foreach (GameObject key in keys)
        {
            if (key.GetComponent<keyc>().i >= z)
            {
                key.GetComponent<keyc>().cambioO();
            }
        }
        foreach (GameObject value in values)
        {
            if (value.GetComponent<valuec>().i >= z)
            {
                value.GetComponent<valuec>().cambioO();
            }
        }

        posisionO = posisionO + espacio;
        c--;
        i = c;

        Debug.Log(hashtableXD.Count);

        foreach (DictionaryEntry kvp in hashtableXD)
            Debug.Log(kvp.Key + " " + kvp.Value);
    }
}
