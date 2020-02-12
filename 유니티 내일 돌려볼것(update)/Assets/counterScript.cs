using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counterScript : MonoBehaviour
{
    public Text CountText;
    // Start is called before the first frame update
    void Start()
    {
        global.num= GameObject.FindGameObjectsWithTag("Player").Length;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        SetCountText();
    }

    void SetCountText()
    {
        CountText.text = "총    원 : "+global.num+"\n사망자 : " + global.count.ToString() + "\n생존자 : " + (global.num - global.count).ToString();

    }
}
