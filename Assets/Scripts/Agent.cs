using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    [SerializeField] 
    private Transform destination;

    public Path path;

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        path = new Path(this);
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void SetDestination()
    {
        if (destination != null)
        {
            Vector3 target = destination.transform.position;
            _navMeshAgent.SetDestination(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class Path 
{
    
    public List<Node> Nodes;
    private Agent _agent;

    public Path(Agent a)
    {
        _agent = a;
        Nodes = new List<Node>();
    }

    
}

public class Node
{
    public Node(Vector3 pos)
    {
        this.pos = pos;
    }
    public Vector3 pos;
}


    

    

