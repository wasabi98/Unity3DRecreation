using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    

    [SerializeField] private List<GameObject> path;
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

    private void FollowPath()
    {
            /*Vector3 target = destination.transform.position;
            _navMeshAgent.SetDestination(target);*/
            




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

        if (_navMeshAgent.velocity == Vector3.zero)
        {
            _animatior.SetBool("isWalking", false);
        }
        else
        {
            _animatior.SetBool("isWalking", true);
        }
    }
}

    

