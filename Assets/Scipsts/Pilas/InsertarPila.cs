using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsertarPila : MonoBehaviour
{
    public GameObject insert1_1;
    public Button eliminar1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Insertarpila()
    {
        insert1_1.gameObject.SetActive(true);

        eliminar1.gameObject.SetActive(false);
    }
}
