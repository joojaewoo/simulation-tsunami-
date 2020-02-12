using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject sea;
    public Transform _seaParent;
    public Vector3 seaScale;
    private float _xpos = -376f;
    private float _zpos = -5646f;
    public Vector3 targetPosition;
    void Start()
    {
        targetPosition = new Vector3(_xpos, 0, _zpos);
        blockInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void blockInit()
    {
        seaScale = new Vector3(0.5f, 1f, 0.5f);
        for(int i = 0; i < 215; i++)
        {
            GameObject seaObj = Instantiate(sea) as GameObject;
            seaObj.transform.parent = _seaParent;
            seaObj.transform.localScale = seaScale;
            seaObj.transform.localPosition = targetPosition;
            targetPosition.x += 50f - 0.46511627906976744186046511627907f;
        }
    }
}
