using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Diagnostics;


public class WP : MonoBehaviour
{

    public enum State // 에이전트의 상태
    {
        Idle = 0,
        Walk = 1,
        Run = 2
    }

    private GameObject[] points;
    private NavMeshAgent agent; // 에이전트
    private double[] dist ; // 에이전트와 목적지간의 거리가 들어갈 배열
    private double[] Xdis = new double[215]; // 물셀과 에이전트간의 x축 거리가 들어갈 배열
    private double xdis = 0;
    private double dis = 0;
    private int destPoint;
    private SkinnedMeshRenderer color;
    private Rigidbody rb;

    private GameObject[] Waters; // 물셀을 태그로 찾아서 넣을 배열
    private Animator anim;
    private int j;
    private int k;
    private GameObject[] destination;

    private State state = State.Walk;
    Stopwatch sw = new Stopwatch();
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
        destination = GameObject.FindGameObjectsWithTag("Finish");
        dist = new double[destination.Length];
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        anim = GetComponent<Animator>();
        color = GetComponentInChildren<SkinnedMeshRenderer>();
        rb = GetComponent<Rigidbody>();
        SetState(State.Walk);
        sw.Start();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        destPoint = Random.Range(0, points.Length - 1);
        agent.SetDestination(points[destPoint].transform.position);
        //Debug.Log(agent.remainingDistance);
    }
    void Calcdist()
    {
        j = 0;
        for (int i = 0; i < destination.Length; i++) // 에이전트와 각각의 목적지와의 거리를 계산하여 dist 배열에 저장
        {
            dist[i] = Vector3.Distance(agent.transform.position,destination[i].transform.position);
        }
        double min1 = dist[0];
        for (int i = 0; i < dist.Length; i++) // 가장 가까운 목적지 찾기
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
        //agent.SetDestination(destination[j].transform.position); // 목적지 지정
        agent.destination = destination[j].transform.position;
    }

    [System.Obsolete]
    void Update()
    {
        if (sw.ElapsedMilliseconds >= 10000)
        {
            Calcdist();
            SetState(State.Run);
            sw.Stop();
            sw.Reset();
        }
  //      if (state == State.Idle&&agent.isStopped)
   //         agent.Stop(true);
        Move();
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
        // dis = Mathf.Sqrt((apos2.z - water_z) * (apos2.z - water_z));
        dis = apos2.z - water_z;
        //Debug.Log(dis);
    }

    void Move()
    {
        CalcAtoW();
        if (state == State.Walk)
        {
            GotoNextPoint();
            //Debug.Log(destPoint);
            //Debug.Log(Vector3.Distance(agent.transform.position, points[destPoint].transform.position));
        }
            if (state == State.Run&& dis > -10.0f)
            {
            // SetState(State.Run);
            // SetDest();
            agent.angularSpeed = 100.0f;
            agent.speed = 50.0f;
            }
            else if (state == State.Idle)
            {
                rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
                float angle = Waters[k].transform.rotation.eulerAngles.x * Mathf.PI / 180;
                float z = -5646 + 300 / (Mathf.Tan(angle));
                if (Mathf.Tan(angle) * (-agent.transform.position.z + z) < rb.transform.position.y + 18)
                {
                    rb.isKinematic = true;
                   rb.rotation = Quaternion.Euler(-60, 0, 0);
                }

                //Debug.Log(global.count);
            }
            else if (dis <= -10.0f)
            {
                SetState(State.Idle);
                agent.enabled = false;
                // rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
                color.material.color = Color.red;
                global.count += 1;
        }
        }
}
