using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WFind : MonoBehaviour
{
    public enum State // 에이전트의 상태
    {
        Idle = 0,
        Walk = 1,
        Run = 2
    }

    public Transform target0, target1, target2; // 목적지
    private Transform[] target = new Transform[3]; // 목적지가 들어갈 배열
    private NavMeshAgent agent; // 에이전트
    private double[] dist = new double[3]; // 에이전트와 목적지간의 거리가 들어갈 배열
    private double[] Xdis = new double[215]; // 물셀과 에이전트간의 x축 거리가 들어갈 배열
    private GameObject[] Waters; // 물셀을 태그로 찾아서 넣을 배열
    private Animator anim;
    int j;

    private State state = State.Walk;
    //public bool isNewState;

    /*
    IEnumerator FSMMain()
    {
        while (true)
        {
            isNewState = false;
            yield return StartCoroutine(state.ToString());
        }
    }
    */
    public void SetState(State newState)
    {
        //isNewState = true;
        state = newState;
        anim.SetInteger("state", (int)state);
    }

    /*
    protected virtual IEnumerator Idle()
    {
        do
        {
            //1프레임에 한번만 체크한다.
            yield return null;
            for (int i = 0; i < Waters.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, Waters[i].transform.position) > 2000.0f)
                {
                    Debug.Log(Vector3.Distance(agent.transform.position, Waters[i].transform.position));
                    SetState(State.Walk);
                }
                else
                {
                    SetState(State.Run);
                }
            }
        } while (!isNewState); //do 문 종료조건.
    }
    */
    /*
    protected virtual IEnumerator Walk()
    {
        do
        {
            //1프레임에 한번만 체크한다.
            yield return null;
            for (int i = 0; i < Waters.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, Waters[i].transform.position) <= 2000.0f)
                {
                    SetState(State.Run);
                }
                else if (Vector3.Distance(agent.transform.position, Waters[i].transform.position) == 0.0f)
                {
                    SetState(State.Idle);
                }
            }
        } while (!isNewState); //do 문 종료조건.
    }
    */
    /*
    protected virtual IEnumerator Run()
    {
        do
        {
            //1프레임에 한번만 체크한다.
            yield return null;
            for (int i = 0; i < Waters.Length; i++)
            {
                if (Vector3.Distance(agent.transform.position, Waters[i].transform.position) > 2000.0f)
                {
                    SetState(State.Walk);
                }
                else if (Vector3.Distance(agent.transform.position, Waters[i].transform.position) == 0.0f)
                {
                    SetState(State.Idle);
                }
            }
        } while (!isNewState); //do 문 종료조건.
    }
    */
    void Start()
    {
        Waters = GameObject.FindGameObjectsWithTag("Water");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

    void Update()
    {
        if (state != 0) Move();

    }
    private void Move()
    {
       
        for (int i = 0; i < Waters.Length; i++) // 에이전트와 물셀의 x축 거리 저장
        {
            Vector3 pos1, apos1;
            pos1 = Waters[i].transform.position;
            apos1 = agent.transform.position;
            double xdis = apos1.x - pos1.x;
            Xdis[i] = xdis;
        }
        agent.SetDestination(target[j].position); // 목적지 지정
        int k = 0;
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
        double dis = Mathf.Sqrt((apos2.z - water_z) * (apos2.z - water_z));
        Debug.Log(dis);
        if (dis > 1500.0f)
        {
            SetState(State.Walk);
            
        }

        else if (dis > 50f && dis <= 1500.0f)
        {
            SetState(State.Run);
            agent.speed = 50.0f;
        }

        else if (dis <= 10f)
        {
            SetState(State.Idle);
            agent.speed = 0;
        }

    }
}