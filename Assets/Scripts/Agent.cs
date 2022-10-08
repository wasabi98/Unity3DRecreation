using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    [SerializeField] private List<GameObject> path;

    
    
    private int currentDestination;
    private bool isfollowing;
    private Animator _animatior;
    private float prevRotation;
    [FormerlySerializedAs("Bpath")] /*[SerializeField]*/ private bool Draw_Path;
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

        #region Turn

        float turn;
        float offset = 60f;
        if (prevRotation < transform.eulerAngles.y-offset)
            turn = -0.2f;
        else if (prevRotation > transform.eulerAngles.y+offset)
            turn = 0.2f;
        else
            turn = 0f;

        _animatior.SetFloat("velocityX", turn);
        
        #endregion

        #region Speed

        float speed;
        if (_navMeshAgent.velocity.magnitude / 10 >= 0.8f)
            speed = _navMeshAgent.velocity.magnitude / 10;
        else
            speed = 0.8f;
        
        _animatior.SetFloat("velocityY", speed);
        //t.text = (_navMeshAgent.velocity.magnitude/10).ToString();
        //t.text = ((prevRotation)).ToString();
        //prevRotation = transform.eulerAngles.y;

        #endregion
    }

    // source: https://www.youtube.com/watch?v=TpQbqRNCgM0&t=994s&ab_channel=TheKiwiCoder
    private void OnDrawGizmos()
    {
        if (Draw_Path)
        {
            Vector3 prevCorner = transform.position;
            if (_navMeshAgent != null)
            {
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
    /*private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(Vector3.zero, 10f);
    }*/
}

    

