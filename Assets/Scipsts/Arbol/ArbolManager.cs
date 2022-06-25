using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class ArbolManager : MonoBehaviour
{


    [SerializeField]
    GameObject nodePrefab;

    List<GameObject> gameObjectsNodes = new List<GameObject>();

    ArbolBinarioOrdenado arbol;

    Vector3 currentPosition = new Vector3(0,0,0);

    [SerializeField]
    Transform lookTarget;

    public void NewArbol()
    {
        arbol = new ArbolBinarioOrdenado();
    }
    public class ArbolBinarioOrdenado
    {
        public class Nodo
        {
            public int info;
            public Vector3 position;
            public Vector3 particlePosition;
            public Nodo izq, der;
        }

        Nodo raiz;

        public int altura = 0;
        float distanceFactor = 3;
        public float xPos = 0;
        public int ladoUltimaInsercion = 0; //-1 izquierda 1 derecha
        public ArbolBinarioOrdenado()
        {
            raiz = null;
        }

        public Nodo Insertar(int info)
        {
            distanceFactor = 1;
            altura = 0;
            xPos = 0;
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = info;
            nuevo.izq = null;
            nuevo.der = null;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo anterior = null, reco;
                reco = raiz;
                while (reco != null)
                {
                    anterior = reco;
                    if (info < reco.info)
                    {
                        reco = reco.izq;
                        altura++;
                    }
                    else
                    {
                        reco = reco.der;
                        altura++;
                    }
                    
                }
                if (info < anterior.info)
                {
                    nuevo.position.z = anterior.position.z - 1;
                    anterior.izq = nuevo;
                }
                else
                {
                    nuevo.position.z = anterior.position.z + 1;
                    anterior.der = nuevo;
                }

                nuevo.position.y = -altura;
            }

            return nuevo;
        }


        private void ImprimirPre(Nodo reco)
        {
            if (reco != null)
            {
                Debug.Log(reco.info + " ");
                ImprimirPre(reco.izq);
                ImprimirPre(reco.der);
            }
        }

        public void ImprimirPre()
        {
            ImprimirPre(raiz);
        }

        private void ImprimirEntre(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirEntre(reco.izq);
                Debug.Log(reco.info + " ");
                ImprimirEntre(reco.der);
            }
        }

        public void ImprimirEntre()
        {
            ImprimirEntre(raiz);
        }


        private void ImprimirPost(Nodo reco)
        {
            if (reco != null)
            {
                ImprimirPost(reco.izq);
                ImprimirPost(reco.der);
                Debug.Log("Reco "+reco.info + " ");
            }
        }


        public void ImprimirPost()
        {
            ImprimirPost(raiz);
        }
    }

    public void CreateNode(InputField inputFieldTxt)
    {
        AddNode(Int16.Parse(inputFieldTxt.text),arbol);
    }

    public void Delete(InputField inputFieldTxt)
    {

        EliminarNodo(Int16.Parse(inputFieldTxt.text));
    }

    public void EliminarNodo(int info)
    {
        ArbolBinarioOrdenado arbolAux = new ArbolBinarioOrdenado();
        arbol = null;
        List<int> values = new List<int>();
        foreach (GameObject obj in gameObjectsNodes)
        {
            if (obj.GetComponent<NodeArbolContainer>().value != info) values.Add(obj.GetComponent<NodeArbolContainer>().value);
        }
        foreach (GameObject obj in gameObjectsNodes)
        {
            Destroy(obj);
        }

        gameObjectsNodes = null;
        gameObjectsNodes = new List<GameObject>();

        NewArbol();


        foreach (int value in values)
        {
            AddNode(value, arbol);
        }
    }


    public void InprimirArbol()
    {
        arbol.ImprimirPre();
    }


    bool VerificarValorRepetido(int value)
    {
        foreach(GameObject obj in gameObjectsNodes)
        {
            if (obj.GetComponent<NodeArbolContainer>().value == value) return true;
        }
        return false;
    }
    public void AddNode(int value, ArbolBinarioOrdenado arbol)
    {
        if (VerificarValorRepetido(value)) return;
        ArbolBinarioOrdenado.Nodo node = arbol.Insertar(value);
        GameObject gameObjectNode = Instantiate(nodePrefab, Vector3.zero, Quaternion.identity);
        gameObjectNode.GetComponent<NodeArbolContainer>().node = node;
        gameObjectNode.GetComponent<NodeArbolContainer>().UpdateValue(value);
        gameObjectsNodes.Add(gameObjectNode);
        lookTarget.position = gameObjectNode.transform.position;
    }
}
