using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindDestination : MonoBehaviour
{
    public Transform target0, target1, target2; // 목적지
    public Transform[] target = new Transform[3]; // 목적지가 들어갈 배열
    private NavMeshAgent agent; // 에이전트
    double[] dist = new double[3]; // 에이전트와 목적지간의 거리가 들어갈 배열

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        int j = 0;
        target[0] = target0;
        target[1] = target1;
        target[2] = target2;
        for (int i = 0; i < 3; i++) // 에이전트와 각각의 목적지와의 거리를 계산하여 dist 배열에 저장
        {
            dist[i] = Vector3.Distance(agent.transform.position, target[i].transform.position);
        }
        double min = dist[0];
        for (int i = 0; i < 3; i++) // 가장 가까운 목적지 찾기
        {
            if (dist[i] < min)
            {
                min = dist[i];
                j = i;
            }
        }
        agent.SetDestination(target[j].position); // 목적지 지정

    }
}