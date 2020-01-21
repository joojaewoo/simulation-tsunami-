using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class abcd1 : MonoBehaviour
{
    public static int ROWSIZE = 215, COLSIZE = 108;
    public GameObject road;
    public Transform _roadParent;
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
        string[] text = File.ReadAllLines(@"C:\Users\admin\Desktop\Tsunami\simulation-tsunami-\output.txt");
        targetScale = new Vector3(5f, 1f, 5f);
        seaScale = new Vector3(0.5f, 1f, 0.5f);
        buildingScale = new Vector3(1f, 1f, 1f);
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
                if (Pst[i, j] != 9)
                {
                    if ((i<COLSIZE-3&&j<ROWSIZE-3)&&(Pst[i, j] == Pst[i, j + 1] && Pst[i, j] == Pst[i + 1, j] && Pst[i, j] == Pst[i + 1, j + 1] && Pst[i, j] == Pst[i, j + 2]&& Pst[i, j] == Pst[i + 1, j + 2] && Pst[i, j] == Pst[i + 2, j] && Pst[i, j] == Pst[i + 2, j+1] && Pst[i, j] == Pst[i + 2, j+2])) //3by3 
                    {
                        targetPosition.x += 75f;
                        targetPosition.z -= 75f;
                        if (Pst[i, j] == 0)       //길
                        {
                            GameObject roadObj = Instantiate(road) as GameObject;
                            roadObj.transform.parent = _roadParent;
                            roadObj.transform.localScale = targetScale * 3;
                            roadObj.transform.localPosition = targetPosition;
                            _cellList.Add(roadObj);
                        }
                        else if (Pst[i, j] == 1)    //건물
                        {
                            GameObject blockObj = Instantiate(block) as GameObject;
                            blockObj.transform.parent = _blockParent;
                            blockObj.transform.localScale = buildingScale * 3;
                            blockObj.transform.localPosition = targetPosition;
                            _cellList.Add(blockObj);
                        }
                        else if (Pst[i, j] == 2)  //바다
                        {
                            GameObject seaObj = Instantiate(sea) as GameObject;
                            seaObj.transform.parent = _seaParent;
                            seaObj.transform.localScale = seaScale * 3;
                            seaObj.transform.localPosition = targetPosition;
                            _cellList.Add(seaObj);
                        }
                        else if (Pst[i, j] == 3)   //모래
                        {
                            GameObject sandObj = Instantiate(sand) as GameObject;
                            sandObj.transform.parent = _sandParent;
                            sandObj.transform.localScale = targetScale * 3;
                            sandObj.transform.localPosition = targetPosition;
                            _cellList.Add(sandObj);
                        }
                            targetPosition.x -=25f;
                            targetPosition.z += 75f;
                        for (int a = i; a < i +3; a++)
                        {
                            for (int b = j; b < j + 3; b++)
                            {
                                Pst[a, b] = 9;
                            }
                        }
                    }
                   else if (i < COLSIZE - 4 && j < ROWSIZE - 2 && Pst[i, j] == Pst[i, j + 1] && Pst[i, j] == Pst[i + 1, j] && Pst[i, j] == Pst[i + 1, j + 1] && Pst[i, j] == Pst[i + 2, j] && Pst[i, j] == Pst[i + 2, j + 1] && Pst[i, j] == Pst[i + 3, j ] && Pst[i, j] == Pst[i + 3, j + 1]) // 4by 2
                    {
                        targetPosition.x += 50f;
                        targetPosition.z -= 100f;
                        if (Pst[i, j] == 0)       //길
                        {
                            GameObject roadObj = Instantiate(road) as GameObject;
                            roadObj.transform.parent = _roadParent;
                            roadObj.transform.localScale = new Vector3(10f, 1f, 20f);
                            roadObj.transform.localPosition = targetPosition;
                            _cellList.Add(roadObj);
                        }
                        else if (Pst[i, j] == 1)    //건물
                        {
                            GameObject blockObj = Instantiate(block) as GameObject;
                            blockObj.transform.parent = _blockParent;
                            blockObj.transform.localScale = new Vector3(2f,4f,4f);
                            blockObj.transform.localPosition = targetPosition;
                            _cellList.Add(blockObj);
                         
                        }
                        else if (Pst[i, j] == 2)  //바다
                        {
                            GameObject seaObj = Instantiate(sea) as GameObject;
                            seaObj.transform.parent = _seaParent;
                            seaObj.transform.localScale = new Vector3(1f, 1f, 2f);
                            seaObj.transform.localPosition = targetPosition;
                            _cellList.Add(seaObj);
                          
                        }
                        else if (Pst[i, j] == 3)   //모래
                        {
                            GameObject sandObj = Instantiate(sand) as GameObject;
                            sandObj.transform.parent = _sandParent;
                            sandObj.transform.localScale = new Vector3(10f, 1f, 20f);
                            sandObj.transform.localPosition = targetPosition;
                            _cellList.Add(sandObj);
                          
                        }
                        for (int a = i; a < i + 4; a++)
                        {
                            for (int b = j; b < j + 2; b++)
                            {
                                Pst[a, b] = 9;
                            }
                        }
                        targetPosition.z += 100f;
                    }
                    else if (i < COLSIZE - 2 && j < ROWSIZE - 4 && Pst[i, j] == Pst[i, j + 1] && Pst[i, j] == Pst[i + 1, j] && Pst[i, j] == Pst[i + 1, j + 1] && Pst[i, j] == Pst[i, j+2] && Pst[i, j] == Pst[i, j + 3] && Pst[i, j] == Pst[i + 1, j+2] && Pst[i, j] == Pst[i + 1, j + 3]) // 2by 4
                    {
                        targetPosition.x += 100f;
                        targetPosition.z -= 50f;
                        if (Pst[i, j] == 0)       //길
                        {
                            GameObject roadObj = Instantiate(road) as GameObject;
                            roadObj.transform.parent = _roadParent;
                            roadObj.transform.localScale = new Vector3(20f, 1f, 10f);
                            roadObj.transform.localPosition = targetPosition;
                            _cellList.Add(roadObj);
                         
                        }
                        else if (Pst[i, j] == 1)    //건물
                        {
                            GameObject blockObj = Instantiate(block) as GameObject;
                            blockObj.transform.parent = _blockParent;
                            blockObj.transform.localScale = new Vector3(4f, 3f, 2f);
                            blockObj.transform.localPosition = targetPosition;
                            _cellList.Add(blockObj);
                         
                        }
                        else if (Pst[i, j] == 2)  //바다
                        {
                            GameObject seaObj = Instantiate(sea) as GameObject;
                            seaObj.transform.parent = _seaParent;
                            seaObj.transform.localScale = new Vector3(2f, 1f, 1f);
                            seaObj.transform.localPosition = targetPosition;
                            _cellList.Add(seaObj);
                        
                        }
                        else if (Pst[i, j] == 3)   //모래
                        {
                            GameObject sandObj = Instantiate(sand) as GameObject;
                            sandObj.transform.parent = _sandParent;
                            sandObj.transform.localScale = new Vector3(20f, 1f, 10f);
                            sandObj.transform.localPosition = targetPosition;
                            _cellList.Add(sandObj);
                           
                        }
                        for (int a = i; a < i + 2; a++)
                        {
                            for (int b = j; b < j + 4; b++)
                            {
                                Pst[a, b] = 9;
                            }
                        }
                        targetPosition.x -= 50f;
                        targetPosition.z += 50f;
                    }
                    else if ((i < COLSIZE - 2 && j < ROWSIZE - 2 )&&(Pst[i, j] == Pst[i, j + 1] && Pst[i, j] == Pst[i + 1, j] && Pst[i, j] == Pst[i + 1, j + 1]))
                    {
                        targetPosition.x += 50f;
                        targetPosition.z -= 50f;
                        if (Pst[i, j] == 0)       //길
                        {
                            GameObject roadObj = Instantiate(road) as GameObject;
                            roadObj.transform.parent = _roadParent;
                            roadObj.transform.localScale = targetScale * 2;
                            roadObj.transform.localPosition = targetPosition;
                            _cellList.Add(roadObj);
                        }
                        else if (Pst[i, j] == 1)    //건물
                        {
                            GameObject blockObj = Instantiate(block) as GameObject;
                            blockObj.transform.parent = _blockParent;
                            blockObj.transform.localScale = buildingScale * 2;
                            blockObj.transform.localPosition = targetPosition;
                            _cellList.Add(blockObj);
                        }
                        else if (Pst[i, j] == 2)  //바다
                        {
                            GameObject seaObj = Instantiate(sea) as GameObject;
                            seaObj.transform.parent = _seaParent;
                            seaObj.transform.localScale = seaScale * 2;
                            seaObj.transform.localPosition = targetPosition;
                            _cellList.Add(seaObj);
                        }
                        else if (Pst[i, j] == 3)   //모래
                        {
                            GameObject sandObj = Instantiate(sand) as GameObject;
                            sandObj.transform.parent = _sandParent;
                            sandObj.transform.localScale = targetScale * 2;
                            sandObj.transform.localPosition = targetPosition;
                            _cellList.Add(sandObj);
                        }
                        targetPosition.z += 50f;
                        for (int a = i; a < i + 2; a++)
                        {
                            for (int b = j; b < j + 2; b++)
                            {
                                Pst[a, b] = 9;
                            }
                        }
                    }
                    else
                    {
                        targetPosition.x += 25f;
                        targetPosition.z -= 25f;
                                if (Pst[i, j] == 0)       //길
                                {
                                    GameObject roadObj = Instantiate(road) as GameObject;
                                    roadObj.transform.parent = _roadParent;
                                    roadObj.transform.localScale = targetScale;
                                    roadObj.transform.localPosition = targetPosition;
                                    _cellList.Add(roadObj);
                                }
                                else if (Pst[i, j] == 1)    //건물
                                {
                                    GameObject blockObj = Instantiate(block) as GameObject;
                                    blockObj.transform.parent = _blockParent;
                                    blockObj.transform.localScale = buildingScale;
                                    blockObj.transform.localPosition = targetPosition;
                                    _cellList.Add(blockObj);
                                }
                                else if (Pst[i, j] == 2)  //바다
                                {
                                    GameObject seaObj = Instantiate(sea) as GameObject;
                                    seaObj.transform.parent = _seaParent;
                                    seaObj.transform.localScale = seaScale;
                                    seaObj.transform.localPosition = targetPosition;
                                    _cellList.Add(seaObj);

                                }
                                else if (Pst[i, j] == 3)   //모래
                                {
                                    GameObject sandObj = Instantiate(sand) as GameObject;
                                    sandObj.transform.parent = _sandParent;
                                    sandObj.transform.localScale = targetScale;
                                    sandObj.transform.localPosition = targetPosition;
                                    _cellList.Add(sandObj);
                                }
                        targetPosition.x += 25f;
                        targetPosition.z += 25f;
                        Pst[i,j] = 9;
                    }
                }
                else
                {
                    targetPosition.x += 50f;
                }
            }
            targetPosition.x = _xpos;
            targetPosition.z -= 50f;
        }
    }
}
