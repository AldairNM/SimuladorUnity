using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class GraphComponent : MonoBehaviour
{
    List<GameObject> gameObjectsNodes = new List<GameObject>();
    List<GameObject> gameObjectsEdges = new List<GameObject>();

    [SerializeField]
    GameObject nodePrefab;

    [SerializeField]
    GameObject edgePrefab;

    [SerializeField]
    Transform lookTarget;

    [SerializeField]
    GameObject CreatorModeBtn;
    [SerializeField]
    GameObject ExitCreatorModeBtn;

    [SerializeField]
    GameObject EdgeModeBtn;
    [SerializeField]
    GameObject ExitEdgeModeBtn;

    public static GameObject fromNodeAux = null;
    public static GameObject toNodeAux = null;

    public static bool edgeBand = false;

    private Graph<Vector3, float> graph;

    GameObject lastNode;


    Vector2 mousePos;
    float zDistance = 5.0f;
    Vector3 mouseToWorldPos;

    public static bool isCreatorMode = false;
    public static bool isEdgeMode = false;

    int verifyEdgeInt = 0;

    int nodeNumber = 0;

    bool hasNumber = false;
    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph<Vector3, float>();
    }

    public void verifyNumber(InputField numberInputField)
    {
        if (numberInputField.text.Length == 0) hasNumber = false;
        else
        {
            nodeNumber = Int16.Parse(numberInputField.text);
            hasNumber = true;
        }
    }
    public void SetCreatorMode(bool value)
    {
        isCreatorMode = value;
        isEdgeMode = false;
        ExitEdgeModeBtn.SetActive(false);
        EdgeModeBtn.SetActive(true);
    }

    public void SetEdgeMode(bool value)
    {
        isEdgeMode = value;
        isCreatorMode = false;
        ExitCreatorModeBtn.SetActive(false);
        CreatorModeBtn.SetActive(true);
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (isCreatorMode && hasNumber) CreateNode();
            //if (isEdgeMode) CreateNode();
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            isCreatorMode = false;
            isEdgeMode = false;
            ExitCreatorModeBtn.SetActive(false);
            CreatorModeBtn.SetActive(true);
            ExitEdgeModeBtn.SetActive(false);
            EdgeModeBtn.SetActive(true);
        }

        if(isEdgeMode)
        {
            if (fromNodeAux != null) Debug.Log("FromNodeAux no null");
            if (toNodeAux != null) Debug.Log("ToNodeAux no null");
            if (fromNodeAux != null && toNodeAux != null)
            {
                if((fromNodeAux.GetComponent<NodeContainer>().node != toNodeAux.GetComponent<NodeContainer>().node))
                {
                    verifyEdgeInt = EdgeExist(fromNodeAux.GetComponent<NodeContainer>(), toNodeAux.GetComponent<NodeContainer>());
                    if (verifyEdgeInt == 3)
                    {
                        Debug.Log("creando nuevo node");
                        AddEdge(fromNodeAux.GetComponent<NodeContainer>().node, toNodeAux.GetComponent<NodeContainer>().node);
                        Debug.Log("Nuevo Arista | Desde: " + fromNodeAux.GetComponent<NodeContainer>().node.Value + " | Hasta: " + toNodeAux.GetComponent<NodeContainer>().node.Value);
                        CleanNodesAux();
                    }
                }
                else
                {
                    verifyEdgeInt = EdgeExist(fromNodeAux.GetComponent<NodeContainer>(), toNodeAux.GetComponent<NodeContainer>());
                    if (verifyEdgeInt == 3)
                    {
                        Debug.Log("creando nuevo node auto");
                        AddEdge(fromNodeAux.GetComponent<NodeContainer>().node, toNodeAux.GetComponent<NodeContainer>().node, true);
                        Debug.Log("Nuevo Arista | Desde: " + fromNodeAux.GetComponent<NodeContainer>().node.Value + " | Hasta: " + toNodeAux.GetComponent<NodeContainer>().node.Value);
                        CleanNodesAux();
                    }
                }
            }
        }
    }

    void CleanNodesAux()
    {
        fromNodeAux.GetComponent<NodeContainer>().SetNormalColor();
        toNodeAux.GetComponent<NodeContainer>().SetNormalColor();
        fromNodeAux = null;
        toNodeAux = null;
        DebugAllEdges();
    }

    void CreateNode()
    {
        mousePos = Input.mousePosition;
        mouseToWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
        lookTarget.position = mouseToWorldPos;
        AddNode(mouseToWorldPos);
    }

    void AddEdge(Node<Vector3> fromNode, Node<Vector3> toNode, bool isAutoRef = false)
    {
        var edge = new Edge<float, Vector3>() { Value = 1.0f, From = fromNode, To = toNode, EdgeColor = Color.yellow };
        graph.Edges.Add(edge);
        if (!isAutoRef) AddGameObjectEdge(edge);
        else
        {
            fromNodeAux.GetComponent<NodeContainer>().SetAutoRef();
            fromNodeAux.GetComponent<NodeContainer>().autoRef.AddComponent<EdgeContainer>();
            fromNodeAux.GetComponent<NodeContainer>().autoRef.GetComponent<EdgeContainer>().edge = edge;
            gameObjectsEdges.Add(fromNodeAux.GetComponent<NodeContainer>().autoRef);
        }
    }

    void AddNode(Vector3 anyPosition)
    {
        var newNode = new Node<Vector3>() { Value = anyPosition, Number = nodeNumber, NodeColor = Color.red };
        graph.Nodes.Add(newNode); //Crea un nodo y lo agrega al grafo
        AddGameObjectNode(newNode); //Referencia el nodo en el gameobject

    }


    void AddGameObjectNode(Node<Vector3> newNode)
    {
        GameObject gameObjectNode = Instantiate(nodePrefab, newNode.Value, Quaternion.identity);
        gameObjectNode.GetComponent<NodeContainer>().node = newNode;
        gameObjectNode.GetComponent<NodeContainer>().SetNumber(nodeNumber);
        gameObjectsNodes.Add(gameObjectNode);
        if(gameObjectsNodes.Count>1)
        {
            AddEdge(lastNode.GetComponent<NodeContainer>().node, newNode); // Se crea una arista que une el último nodo creado con el nuevo
        }
        lastNode = gameObjectNode;

    }

    void AddGameObjectEdge(Edge<float, Vector3> newEdge)
    {
        GameObject gameObjectEdge = Instantiate(edgePrefab, Vector3.zero, Quaternion.identity);
        gameObjectEdge.GetComponent<EdgeContainer>().edge = newEdge;
        gameObjectsEdges.Add(gameObjectEdge);
    }

    void DebugAllNodes()
    {
        foreach(GameObject currentNode in gameObjectsNodes)
        {
            Debug.Log(currentNode.GetComponent<NodeContainer>().node.Value);
        }

        Debug.Log("Total Nodes: " + gameObjectsNodes.Count);
    }

    int EdgeExist(NodeContainer fromToVerify, NodeContainer toToVerify)
    {
        bool isFromTo = false;
        bool isToFrom = false;
        foreach (GameObject currentEdge in gameObjectsEdges)
        {
            if ((currentEdge.GetComponent<EdgeContainer>().edge.From == fromToVerify.node) && (currentEdge.GetComponent<EdgeContainer>().edge.To == toToVerify.node))
            {
               
                isFromTo = true;
            }
            if ((currentEdge.GetComponent<EdgeContainer>().edge.To == fromToVerify.node) && (currentEdge.GetComponent<EdgeContainer>().edge.From == toToVerify.node))
            {
                isToFrom = true;
            }
        }

        if (isFromTo && !isToFrom)
        {
            Debug.Log("Conexión en un sentido From To");
            return 1;
        }
        if (!isFromTo && isToFrom)
        {
            Debug.Log("Conexión en un sentido To From");
            return 2;
        }

        if(!isFromTo && !isToFrom)
        {
            return 3;
        }

        return 0;
    }
    void DebugAllEdges()
    {
        foreach (GameObject currentEdge in gameObjectsEdges)
        {
            Debug.Log(currentEdge.GetComponent<EdgeContainer>().edge.From.Value+ currentEdge.GetComponent<EdgeContainer>().edge.To.Value);
        }

        Debug.Log("Total Edges: " + gameObjectsEdges.Count);
    }
}