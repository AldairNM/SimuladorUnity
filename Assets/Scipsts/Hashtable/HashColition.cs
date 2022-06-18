using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HashColition : MonoBehaviour
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


    [SerializeField]
    Transform lookAtTransform;

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
            newCubo.GetComponent<cubito>().managerType = 4;
            posisionO = posisionO - espacio;
            cubos[x] = newCubo;
            i = i + 1;
            lookAtTransform.position = newCubo.GetComponent<cubito>().posision;
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
        int i2=0;


        int a = valor3 % 10;

        foreach (GameObject cubo in cubos)
        {
            if (cubo.GetComponent<cubito>().i == a)
            {
                ubi = cubo.transform.position;
                i2 = cubo.GetComponent<cubito>().i;
            }
        }
        if(GameObject.Find("Union" + i2))
        {
            i2 = i2+1;
            if (GameObject.Find("Cubo"+i2))
            {
                if (GameObject.Find("Union" + i2))
                {
                    if (GameObject.Find("Union" + 0))
                    {

                    }
                    else
                    {
                        foreach (GameObject cubo in cubos)
                        {
                            if (cubo.GetComponent<cubito>().i == 0)
                            {
                                ubi = cubo.transform.position;
                                i2 = cubo.GetComponent<cubito>().i;
                            }
                        }
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
                        lookAtTransform.position = newValue.GetComponent<valuec>().posision;
                        CubitosXD.Add(newunion, newValue);
                        hashtableXD = new Hashtable(CubitosXD);
                    }
                }
                else
                {
                    foreach (GameObject cubo in cubos)
                    {
                        if (cubo.GetComponent<cubito>().i == i2)
                        {
                            ubi = cubo.transform.position;
                            i2 = cubo.GetComponent<cubito>().i;
                        }
                    }
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

                    lookAtTransform.position = newValue.GetComponent<valuec>().posision;

                    CubitosXD.Add(newunion, newValue);
                    hashtableXD = new Hashtable(CubitosXD);
                }
                
            }
            else
            {
                if (GameObject.Find("Union" + 0))
                {

                }
                else
                {
                    foreach (GameObject cubo in cubos)
                    {
                        if (cubo.GetComponent<cubito>().i == 0)
                        {
                            ubi = cubo.transform.position;
                            i2 = cubo.GetComponent<cubito>().i;
                        }
                    }
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

                    lookAtTransform.position = newValue.GetComponent<valuec>().posision;
                    CubitosXD.Add(newunion, newValue);
                    hashtableXD = new Hashtable(CubitosXD);
                }
            }
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
            lookAtTransform.position = newValue.GetComponent<valuec>().posision;
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
        Vector3 espacio = new Vector3(0, 1.44f, 0);
        values = GameObject.FindGameObjectsWithTag("VALUE");
        foreach (GameObject value in values)
        {
            if (value.GetComponent<valuec>().d == w)
            {
                z = value.GetComponent<valuec>().i;
            }
        }

        unionclon = GameObject.Find("Union" + z);
        Destroy(unionclon);
        valueclon = GameObject.Find("Value" + z);
        Destroy(valueclon);

        CubitosXD.Remove(unionclon);
        hashtableXD = new Hashtable(CubitosXD);

        Debug.Log(hashtableXD.Count);

        foreach (DictionaryEntry kvp in hashtableXD)
            Debug.Log(kvp.Key + " " + kvp.Value);
    }
}
