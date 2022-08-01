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

    
    

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
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

    

