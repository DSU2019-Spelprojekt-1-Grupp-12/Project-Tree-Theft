using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathingTest : MonoBehaviour
{
    public GameObject Node;
    Vector3 nodePosition;
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        nodePosition = new Vector3(Node.transform.position.x, Node.transform.position.y, 0f);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.Warp(new Vector3(-8f,2.25f,0f));
        //agent.SetDestination(new Vector3(-8f, 3.25f, 0f));
        agent.SetDestination(nodePosition);

    }

    // Update is called once per frame
    void Update()
    {
        var agent = GetComponent<NavMeshAgent>();
    }
}
