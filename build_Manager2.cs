using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class build_manager : MonoBehaviour
{
    public static int ROWSIZE = 860 / 4, COLSIZE = 432 / 4;
    public GameObject block;
    public Transform _blockParent;
    public GameObject sea;
    public Transform _seaParent;
    public GameObject sand;
    public Transform _sandParent;
    List<GameObject> _cellList = new List<GameObject>();
    public Vector3 targetPosition;
    public Vector3 seaScale;
    public Vector3 buildingScale;
    public Vector3 bigBuildingScale;
    public Vector3 targetScale;
    public int[,] Pst = new int[COLSIZE, ROWSIZE];
    public int tmp = 0;
    private float _xpos = 0f;
    private float _zpos = 0f;

    // Use this for initialization
    void Start()
    {
        blockInit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void blockInit()
    {
        string[] text = File.ReadAllLines(@"C:\Users\glps2\Desktop\textFile\output.txt");
        targetScale = new Vector3(5f, 1f, 5f);
        seaScale = new Vector3(1f, 1f, 0.5f);
        buildingScale = new Vector3(1f, 1f, 1f);
        bigBuildingScale = new Vector3(3f, 2f, 3f);
        targetPosition = new Vector3(_xpos, 0, _zpos);
        
        for (int i = 0; i < COLSIZE; i++)
        {
            for (int j = 0; j < ROWSIZE; j++)
            {
                int tmp = int.Parse(text[i].Substring(j, 1));
                Pst[i, j] = tmp;
            }
        }

        for (int i = 0; i < COLSIZE; i++)
        {
            for (int j = 0; j < ROWSIZE; j++)
            {
                if (Pst[i, j] == 0)       //길
                {
                    targetPosition.x += 50f;
                }
                else if (Pst[i, j] == 1)    //건물
                {
                    if( j == 213 || j==214 || i==106 || i==107)
                    {
                        GameObject blockObj = Instantiate(block) as GameObject;
                        blockObj.transform.parent = _blockParent;
                        blockObj.transform.localScale = buildingScale;
                        blockObj.transform.localPosition = targetPosition;
                        _cellList.Add(blockObj);
                        targetPosition.x += 50f;
                    }
                    else if (Pst[i,j] == 1 && Pst[i+1,j] == 1 && Pst[i,j+1] == 1 && Pst[i+1,j+1] == 1 && Pst[i+2,j] == 1 && Pst[i+2,j+1] == 1
                        && Pst[i+2,j+2] == 1 && Pst[i,j+2] == 1 && Pst[i+1,j+2] == 1)
                    {
                        GameObject blockObj = Instantiate(block) as GameObject;
                        blockObj.transform.parent = _blockParent;
                        blockObj.transform.localScale = bigBuildingScale;
                        blockObj.transform.localPosition = targetPosition;
                        _cellList.Add(blockObj);
                        targetPosition.x += 150f;
                        Pst[i, j] = 4; Pst[i + 1, j] = 4; Pst[i, j + 1] = 4; Pst[i + 1, j + 1] = 4; Pst[i + 2, j] = 4; Pst[i + 2, j + 1] = 4;
                        Pst[i + 2, j + 2] = 4; Pst[i, j + 2] = 4; Pst[i + 1, j + 2] = 4;
                        j += 2;
                    }
                    else
                    {
                        GameObject blockObj = Instantiate(block) as GameObject;
                        blockObj.transform.parent = _blockParent;
                        blockObj.transform.localScale = buildingScale;
                        blockObj.transform.localPosition = targetPosition;
                        _cellList.Add(blockObj);
                        targetPosition.x += 50f;
                    }
                }
                else if (Pst[i, j] == 2)  //바다
                {
                    GameObject seaObj = Instantiate(sea) as GameObject;
                    seaObj.transform.parent = _seaParent;
                    seaObj.transform.localScale = seaScale;
                    seaObj.transform.localPosition = targetPosition;
                    _cellList.Add(seaObj);
                    targetPosition.x += 50f;
                }
                else if (Pst[i, j] == 3)   //모래
                {
                    GameObject sandObj = Instantiate(sand) as GameObject;
                    sandObj.transform.parent = _sandParent;
                    sandObj.transform.localScale = targetScale;
                    sandObj.transform.localPosition = targetPosition;
                    _cellList.Add(sandObj);
                    targetPosition.x += 50f;
                }
                else if(Pst[i,j] == 4)
                {
                    j+= 2;
                    targetPosition.x += 150f;
                }
                else
                    targetPosition.x += 50f;
            }
            targetPosition.x = 0f;
            targetPosition.z -= 50f;
           
        }

    }

}