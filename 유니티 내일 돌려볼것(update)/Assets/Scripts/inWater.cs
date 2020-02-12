using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inWater : MonoBehaviour
{
    public static bool isWater = false;

    [SerializeField] private float waterDrag;   //물속 중력
    private float originDrag;

    [SerializeField] private Color waterColor;  //물속 색깔
    [SerializeField] private float waterFogDensity; //물 탁함 정도

    private Color originColor;
    private float originFogDensity;
    // Start is called before the first frame update
    void Start()
    {
        originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;

        originDrag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            getWater(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            getOutWater(other);
        }
    }
    private void getWater(Collider _player) {
        isWater = true;
        _player.transform.GetComponent<Rigidbody>().drag = waterDrag;
        RenderSettings.fogColor = waterColor;
        RenderSettings.fogDensity = waterFogDensity;
    }

    private void getOutWater(Collider _player) {
        if (isWater)
        {
            isWater = false;
            _player.transform.GetComponent<Rigidbody>().drag = originDrag;
            RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = waterFogDensity;
        }
    }
}
