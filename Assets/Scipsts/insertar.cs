using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class insertar : MonoBehaviour
{
    public Button insert1;
    public Button insert2;
    public Button insert3;

    public Button eliminar1;
    public Button eliminar2;
    public Button eliminar3;
    public GameObject eliminar3_3;

    public GameObject insert1_1;
    public GameObject insert2_2;
    public GameObject insert3_3;
    // Start is called before the first frame update
    void Start()
    {

    }
        

    // Update is called once per frame
    void Update()
    {
        
    }
    public void insertar1()
    {
        insert1.gameObject.SetActive(true);
        insert2.gameObject.SetActive(true);
        insert3.gameObject.SetActive(true);

        eliminar1.gameObject.SetActive(false);
        eliminar2.gameObject.SetActive(false);
        eliminar3.gameObject.SetActive(false);
        eliminar3_3.gameObject.SetActive(false);

    }
    public void insertar_1()
    {
        insert1_1.gameObject.SetActive(true);
        insert2_2.gameObject.SetActive(false);
        insert3_3.gameObject.SetActive(false);
    }
    public void insertar_2()
    {
        insert2_2.gameObject.SetActive(true);
        insert1_1.gameObject.SetActive(false);
        insert3_3.gameObject.SetActive(false);
    }
    public void insertar_3()
    {
        insert3_3.gameObject.SetActive(true);
        insert1_1.gameObject.SetActive(false);
        insert2_2.gameObject.SetActive(false);
    }
}
