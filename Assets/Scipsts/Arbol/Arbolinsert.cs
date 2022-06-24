using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Arbolinsert : MonoBehaviour
{
    public GameObject cubo;
    public GameObject union;


    public TMP_InputField primervalor;
    public GameObject primervalorString;

    public TMP_InputField valueValor;
    public GameObject valueValorString;

    public TMP_InputField valueValorE;

    public GameObject cuboclon;
    public GameObject unionclon;

    GameObject[] cubos;
    GameObject[] cubos2;
    GameObject[] uniones;

    Vector3 posision = new Vector3(-17.65f, 11.24f, -6.86f);
    Vector3 posisionI = new Vector3(-17.65f, 11.24f, -6.86f);
    Vector3 posisionO = new Vector3(-17.65f, 11.24f, -6.86f);

    [SerializeField]
    Transform LookAtTarget;


    int c = 0;
    int i = 0;

    [SerializeField]
    int Level=0;
    Nodo_Arbol t=new Nodo_Arbol();
    public class Nodo_Arbol
    {
        public int info;
        public Nodo_Arbol Izquierdo;
        public Nodo_Arbol Derecho;
        public Nodo_Arbol Padre;
        public int altura;
        public int nivel;

        public Nodo_Arbol()
        {

        }
        public Nodo_Arbol(int nueva_info, Nodo_Arbol izquierdo, Nodo_Arbol derecho, Nodo_Arbol padre)
        {
            info = nueva_info;
            Izquierdo = izquierdo;
            Derecho = derecho;
            Padre = padre;
            altura = 0;
        }
    }
    public void CrearArbol()
    {
        int z = int.Parse(primervalor.text);
        string valor = primervalorString.GetComponent<TMP_Text>().text;

        t = new Nodo_Arbol(z, null, null, null);
        t.nivel = Level;

        Vector3 espacio = new Vector3(0, 1.68f, 0);
        Vector3 espacio2 = new Vector3(0, 0, 1.68f);

        CreadorCuboI(valor);

    }
    public void CreadorCuboI(String x)
    {
        
        GameObject newCubo;
        newCubo = Instantiate(cubo, cubo.transform.position, cubo.transform.rotation);
        newCubo.GetComponent<cubito>().posision = posisionO;
        newCubo.GetComponent<cubito>().managerType = 7;
        newCubo.name = "Cubo" + i;
        newCubo.GetComponent<cubito>().c = c;
        newCubo.GetComponent<cubito>().i = i;
        newCubo.GetComponentInChildren<TMP_Text>().text = x;
        newCubo.tag = "CUBO";
        LookAtTarget.position = posisionO;

    }
    public void inseratarbol()
    {
        
        int x = int.Parse(valueValor.text);
        string valor = valueValorString.GetComponent<TMP_Text>().text;
        t=Insertar(x,t,Level,valor);
        
    }
    public Nodo_Arbol Insertar(int x, Nodo_Arbol t, int nivel1, String valor1)
    {
        Vector3 espacio = new Vector3(0, 1.68f, 0);
        Vector3 espacio2 = new Vector3(0, 0, 1.68f);

        if (t == null)
        {
            t = new Nodo_Arbol(x, null, null, null);
            t.nivel = Level;
            c = c + 1;
            i = c;
            CreadorCuboI(valor1);
            posisionO = new Vector3(-17.65f, 11.24f, -6.86f);

        }
        else if (x < t.info)
        {
            nivel1++;
            t.Izquierdo = Insertar(x, t.Izquierdo, nivel1, valor1);
            posisionO = posisionO - espacio + espacio2;
        }
        else if (x > t.info)
        {
            nivel1++;
            t.Derecho = Insertar(x, t.Derecho, nivel1, valor1);
            posisionO = posisionO - espacio - espacio2;
        }
        else
        {

        }
        return t;
    }
    public static int Alturas(Nodo_Arbol t)
    {
        return t == null? -1 : t.altura;
    }
    public void Eliminar(int x, ref Nodo_Arbol t)
    {
        if (t!=null)
        {
            if (x < t.info)
            {
                Eliminar(x, ref t.Izquierdo);
            }
            else
            {
                if (x > t.info)
                {
                    Eliminar(x, ref t.Derecho);
                }
                else
                {
                    Nodo_Arbol NodoEliminar = t;
                    if (NodoEliminar.Derecho == null)
                    {
                        t = NodoEliminar.Izquierdo;
                    }
                    else
                    {
                        if (NodoEliminar.Izquierdo == null)
                        {
                            t = NodoEliminar.Derecho;
                        }
                        else
                        {
                            if (Alturas(t.Izquierdo) - Alturas(t.Derecho) > 0)
                            {
                                Nodo_Arbol AuxiliarNodo = null;
                                Nodo_Arbol Auxiliar = t.Izquierdo;
                                bool Bandera = false;

                                while (Auxiliar.Derecho != null)
                                {
                                    AuxiliarNodo = Auxiliar;
                                    Auxiliar = Auxiliar.Derecho;
                                    Bandera = true;
                                }
                                t.info = Auxiliar.info;
                                NodoEliminar = Auxiliar;

                                if (Bandera == true)
                                {
                                    AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                }
                                else
                                {
                                    t.Izquierdo = Auxiliar.Izquierdo;
                                }
                            }
                            else
                            {
                                if (Alturas(t.Derecho) - Alturas(t.Izquierdo) > 0)
                                {
                                    Nodo_Arbol AuxiliarNodo = null;
                                    Nodo_Arbol Auxiliar = t.Derecho;
                                    bool Bandera = false;

                                    while (Auxiliar.Izquierdo != null)
                                    {
                                        AuxiliarNodo = Auxiliar;
                                        Auxiliar = Auxiliar.Izquierdo;
                                        Bandera = true;
                                    }
                                    t.info = Auxiliar.info;
                                    NodoEliminar = Auxiliar;

                                    if (Bandera == true)
                                    {
                                        AuxiliarNodo.Izquierdo = Auxiliar.Derecho;
                                    }
                                    else
                                    {
                                        t.Derecho = Auxiliar.Derecho;
                                    }
                                }
                                else
                                {
                                    if (Alturas(t.Derecho) - Alturas(t.Izquierdo) == 0)
                                    {
                                        Nodo_Arbol AuxiliarNodo = null;
                                        Nodo_Arbol Auxiliar = t.Izquierdo;
                                        bool Bandera = false;

                                        while (Auxiliar.Derecho != null)
                                        {
                                            AuxiliarNodo = Auxiliar;
                                            Auxiliar = Auxiliar.Derecho;
                                            Bandera = true;
                                        }
                                        t.info = Auxiliar.info;
                                        NodoEliminar = Auxiliar;

                                        if (Bandera == true)
                                        {
                                            AuxiliarNodo.Derecho = Auxiliar.Izquierdo;
                                        }
                                        else
                                        {
                                            t.Izquierdo = Auxiliar.Izquierdo;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {

        }
    }
}
