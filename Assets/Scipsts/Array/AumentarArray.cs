using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AumentarArray : MonoBehaviour
{
    public GameObject insert1_1;
    public GameObject tamano_1;
    public GameObject tamano_2;
    public Button eliminar1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Aumentararray()
    {
        insert1_1.gameObject.SetActive(false);
        tamano_1.gameObject.SetActive(false);
        tamano_2.gameObject.SetActive(true);

        eliminar1.gameObject.SetActive(false);
    }
}
