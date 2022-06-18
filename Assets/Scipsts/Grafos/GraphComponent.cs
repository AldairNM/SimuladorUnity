using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private Graph<Vector3, float> graph;

    GameObject lastNode;


    Vector2 mousePos;
    float zDistance = 5.0f;
    Vector3 mouseToWorldPos;

    public static bool isCreatorMode = false;
    // Start is called before the first frame update
    void Start()
    {
        graph = new Graph<Vector3, float>();

        /*
         var node1 = new Node<Vector3>() { Value = Vector3.zero, NodeColor = Color.red };
        var node2 = new Node<Vector3>() { Value = Vector3.one, NodeColor = Color.cyan };
        var edge = new Edge<float, Vector3>() { Value = 1.0f, From = node1, To = node2, EdgeColor = Color.yellow };
        graph.Nodes.Add(node1);
        AddGameObjectNode(node1);
        graph.Nodes.Add(node2);
        AddGameObjectNode(node2);
        graph.Edges.Add(edge);
         */
    }

    public void SetCreatorMode(bool value)
    {
        isCreatorMode = value;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (isCreatorMode) CreateNode();
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            isCreatorMode = false;
            ExitCreatorModeBtn.SetActive(false);
            CreatorModeBtn.SetActive(true);
        }
    }

    void CreateNode()
    {
        mousePos = Input.mousePosition;
        mouseToWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, zDistance));
        lookTarget.position = mouseToWorldPos;
        AddNode(mouseToWorldPos);
    }

    void AddEdge(Node<Vector3> fromNode, Node<Vector3> toNode)
    {
        var edge = new Edge<float, Vector3>() { Value = 1.0f, From = fromNode, To = toNode, EdgeColor = Color.yellow };
        graph.Edges.Add(edge);
        AddGameObjectEdge(edge);
    }

    void AddNode(Vector3 anyPosition)
    {
        var newNode = new Node<Vector3>() { Value = anyPosition, NodeColor = Color.red };
        graph.Nodes.Add(newNode); //Crea un nodo y lo agrega al grafo
        AddGameObjectNode(newNode); //Referencia el nodo en el gameobject

    }

    void AddGameObjectNode(Node<Vector3> newNode)
    {
        GameObject gameObjectNode = Instantiate(nodePrefab, newNode.Value, Quaternion.identity);
        gameObjectNode.GetComponent<NodeContainer>().node = newNode;
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
}