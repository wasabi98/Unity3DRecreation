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
    private float prevRotation;
    [SerializeField] private bool Bpath;
    

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        currentDestination = 0;
        _animatior = GetComponent<Animator>();
        _navMeshAgent.SetDestination(path[currentDestination].transform.position);
        prevRotation = transform.eulerAngles.y;
    }
    
    // Update is called once per frame
    void Update()
    {
        
        //_navMeshAgent.Move(transform.forward * Time.deltaTime);
        /*if (transform.position.x == path[currentDestination].transform.position.x &&
            transform.position.z == path[currentDestination].transform.position.z)*/
        if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
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
            //_navMeshAgent.Move(transform.forward * Time.deltaTime);
        }

       
        
        _animatior.SetFloat("velocityX", 0.0f);
        _animatior.SetFloat("velocityY", _navMeshAgent.velocity.magnitude/10);
        //t.text = (_navMeshAgent.velocity.magnitude/10).ToString();
        //t.text = ((prevRotation)).ToString();
        //prevRotation = transform.eulerAngles.y;



    }

    // source: https://www.youtube.com/watch?v=TpQbqRNCgM0&t=994s&ab_channel=TheKiwiCoder
    private void OnDrawGizmos()
    {
        if (Bpath)
        {
            Vector3 prevCorner = transform.position;
            var agentpath = _navMeshAgent.path;
            foreach (var corner in agentpath.corners)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawLine(prevCorner, corner);
                Gizmos.DrawSphere(corner, 0.1f);
                prevCorner = corner;
            }
        }
    }
}

    

