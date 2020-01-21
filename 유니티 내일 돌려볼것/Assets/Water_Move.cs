using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Water_Move : MonoBehaviour
{
    public float speed=0.04f;
    float go;
    float height;
    float x = 0, y = 0, z = 0;
    Vector3 pos;
    int tmp;
    float angle;
    float length;
    // Start is called before the first frame update
    void Start()
    {   
        
        pos = this.gameObject.transform.position;
        pos.x += 376;
        height = pos.y;
        go = speed * 50;
        string text = File.ReadAllText(@"C:\Users\admin\eclipse-workspace\simulation\src\simulation\arr.txt");
        float j = pos.x / 50;
        tmp = int.Parse(text.Substring((int) j*2, 2));
        length = tmp * 53;
        angle = Mathf.Atan2(height, length) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
    }
    void moveObject()

    {
        if (this.gameObject.transform.position.y>80) { 
        transform.Translate(new Vector3(0, 0, go));
        transform.localScale += new Vector3(x, y, z + speed); }        
    }

}
