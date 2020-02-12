using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Diagnostics;

public class Water_Move : MonoBehaviour
{
    public float speed=0.05f;
    float go;
    float height;
    float x = 0, y = 0, z = 0;
    Vector3 pos;
    int tmp;
    bool a = false;
    float angle;
    float length;
    Stopwatch sw = new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        /*while (true)
        {
            a += Time.deltaTime;
            if (a >= 5000)
                break;
        }*/
        //StartCoroutine("delay");
        pos = this.gameObject.transform.position;
        pos.x += 376;
        float j = pos.x / 50;
        for(int i=0;i<Mathf.Abs((107-j)/4);i++)
            speed *= 0.99f;
        height = pos.y;
        go = speed * 50;
        string text = File.ReadAllText(@"C:\Users\admin\eclipse-workspace\simulation\src\simulation\arr.txt");
        tmp = int.Parse(text.Substring((int) j*2, 2));
        length = tmp * 55;
        angle = Mathf.Atan2(height, length) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
        // Invoke("speed_L", 5f);
        sw.Start();
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
    }
    // Update is called once per frame
    void Update()
    {
        if (sw.ElapsedMilliseconds >= 15000) {
            sw.Stop();
            a = true;
        }
        if(a)
        moveObject();
    }
    void moveObject()

    {
        if (this.gameObject.transform.position.y > 150)
        {
            transform.Translate(new Vector3(0, 0, go));
            transform.localScale += new Vector3(x, y, z + speed);
        }     
    }
    void speed_L()
    {
        speed *= 0.995f;
        go = speed * 50;
        Invoke("speed_L", 1f);
    }
}
