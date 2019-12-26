using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent1;
    // Start is called before the first frame update
    void Start()
    {
        agent1 = GetComponent<NavMeshAgent>();
        //agent2 = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent1.SetDestination(target.position);
        //agent2.SetDestination(target.position);
    }
}