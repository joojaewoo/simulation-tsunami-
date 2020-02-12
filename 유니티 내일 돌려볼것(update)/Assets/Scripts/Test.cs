using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Test : MonoBehaviour
{
    public enum State // 에이전트의 상태
    {
        Idle = 0,
        Walk = 1,
        Run = 2
    }

    public Transform target0, target1, target2; // 목적지
    private Transform[] target = new Transform[3]; // 목적지가 들어갈 배열
    private GameObject[] points;
    private NavMeshAgent agent; // 에이전트
    private double[] dist = new double[3]; // 에이전트와 목적지간의 거리가 들어갈 배열
    private double[] Xdis = new double[215]; // 물셀과 에이전트간의 x축 거리가 들어갈 배열
    private double xdis = 0;
    private double dis = 0;
    private int destPoint;

    private GameObject[] Waters; // 물셀을 태그로 찾아서 넣을 배열
    private Animator anim;
    private int j;
    private int k;

    private State state = State.Walk;
    //private bool isNewState;

    public void SetState(State newState)
    {
        //isNewState = true;
        state = newState;
        anim.SetInteger("state", (int)state);
    }
 
   
    
    void Start()
    {
        Waters = GameObject.FindGameObjectsWithTag("Water");
        points = GameObject.FindGameObjectsWithTag("Point");
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        anim = GetComponent<Animator>();
        SetState(State.Walk);
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        destPoint = Random.Range(0, points.Length-1);
        agent.SetDestination(points[destPoint].transform.position);
        //Debug.Log(agent.remainingDistance);
    }
    void Calcdist()
    {
        j = 0;
        target[0] = target0;
        target[1] = target1;
        target[2] = target2;
        for (int i = 0; i < 3; i++) // 에이전트와 각각의 목적지와의 거리를 계산하여 dist 배열에 저장
        {
            dist[i] = Vector3.Distance(agent.transform.position, target[i].transform.position);
        }
        double min1 = dist[0];
        for (int i = 0; i < 3; i++) // 가장 가까운 목적지 찾기
        {
            if (dist[i] < min1)
            {
                min1 = dist[i];
                j = i;
            }
        }

    }
    void SetDest()
    {
        agent.SetDestination(target[j].position); // 목적지 지정
    }

    [System.Obsolete]
    void Update()
    {
        Calcdist();
        CalcAtoW();
        if (dis > 1500.0f && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
            Debug.Log(destPoint);
            //Debug.Log(Vector3.Distance(agent.transform.position, points[destPoint].transform.position));
        }
        
        if (dis > 50.0f && dis <= 1500.0f)
        {
            SetDest();
            SetState(State.Run);
            agent.speed = 50.0f;
        }
        else if (dis <= 50.0f)
        {
            SetState(State.Idle);
            agent.Stop();
        }
        

    }
    
    void CalcAtoW()
    {
        for (int i = 0; i < Waters.Length; i++) // 에이전트와 물셀의 x축 거리 저장
        {
            Vector3 pos1, apos1;
            pos1 = Waters[i].transform.position;
            apos1 = agent.transform.position;
            xdis = apos1.x - pos1.x;
            Xdis[i] = xdis;
        }
        for (int i = 0; i < Xdis.Length; i++)  // 에이전트와 가장 가까운 물 셀 찾기
        {
            if (Mathf.Abs((float)Xdis[i]) < Mathf.Abs((float)Xdis[k]))
            {
                k = i;
            }
        }
        // 에이전트와 물셀의 z축 거리를 구한 뒤 거리에 따라 상태 변화
        Vector3 pos2, apos2;
        float z_scale = Waters[k].transform.localScale.z;
        z_scale = z_scale * 50;
        pos2 = Waters[k].transform.position;
        float water_z = pos2.z + z_scale;
        apos2 = agent.transform.position;
        dis = Mathf.Sqrt((apos2.z - water_z) * (apos2.z - water_z));
        //Debug.Log(dis);
    }
    
}
