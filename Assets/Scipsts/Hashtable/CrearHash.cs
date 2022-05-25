using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrearHash : MonoBehaviour
{
    public GameObject insert1_1;
    public GameObject eliminar1_1;
    public GameObject crear1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void crearhash()
    {
        insert1_1.gameObject.SetActive(false);

        eliminar1_1.gameObject.SetActive(false);

        crear1.gameObject.SetActive(true);
    }
}
