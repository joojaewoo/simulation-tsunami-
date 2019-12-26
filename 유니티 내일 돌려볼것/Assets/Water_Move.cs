using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Move : MonoBehaviour
{
    public float speed=0.04f;
    public float go = 2.0f;
    public float x, y, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveObject();
    }
    void moveObject()

    {

        float keyHorizontal = Input.GetAxis("Horizontal");

        float keyVertical = Input.GetAxis("Vertical");

        /*transform.Translate(Vector3.right * speed * Time.smoothDeltaTime * keyHorizontal, Space.World);
    
        transform.Translate(Vector3.forward, Space.World);*/
        transform.Translate(new Vector3(0, 0, go));
        transform.localScale += new Vector3(x, y, z + speed);
        //transform.localScale -= new Vector3(0, 0.2,0);
    }

}
