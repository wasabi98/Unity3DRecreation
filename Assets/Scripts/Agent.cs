using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    [SerializeField] private List<GameObject> path;
    [SerializeField] public Text t;
    private int currentDestination;
    private bool isfollowing;
    private Animator _animatior;
    

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        currentDestination = 0;
        _animatior = GetComponent<Animator>();
        _navMeshAgent.SetDestination(path[currentDestination].transform.position);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == path[currentDestination].transform.position.x &&
            transform.position.z == path[currentDestination].transform.position.z)
        {
            if (currentDestination < path.Count - 1)
            {
                currentDestination++;
            }
            else
            {
                currentDestination = 0;
            }
            _navMeshAgent.SetDestination(path[currentDestination].transform.position);
        }

       
        
        _animatior.SetFloat("velocityX", 0.0f);
        _animatior.SetFloat("velocityY", _navMeshAgent.velocity.magnitude/10);
        //t.text = (_navMeshAgent.velocity.magnitude/10).ToString();
        t.text =  _animatior.GetFloat("velocityX")+ " " + _animatior.GetFloat("velocityY");
       
        
    }
}

    

