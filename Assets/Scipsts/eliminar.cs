using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eliminar : MonoBehaviour
{
    public Button eliminar1;
    public Button eliminar2;
    public Button eliminar3;
    public Button insertar1;
    public Button insertar2;
    public Button insertar3;
    public GameObject insertar1_1;
    public GameObject insertar1_2;
    public GameObject insertar1_3;
    public GameObject eliminar3_3;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void Eliminar1()
    {
        eliminar1.gameObject.SetActive(true);
        eliminar2.gameObject.SetActive(true);
        eliminar3.gameObject.SetActive(true);

        insertar1.gameObject.SetActive(false);
        insertar2.gameObject.SetActive(false);
        insertar3.gameObject.SetActive(false);

        insertar1_1.gameObject.SetActive(false);
        insertar1_2.gameObject.SetActive(false);
        insertar1_3.gameObject.SetActive(false);

    }
    public void eliminar_3()
    {
        eliminar3_3.gameObject.SetActive(true);
    }
}
