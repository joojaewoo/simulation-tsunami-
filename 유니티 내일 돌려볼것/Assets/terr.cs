using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class terr : MonoBehaviour
{
    public static int ROWSIZE =  215, COLSIZE = 108;
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
        string[] text = File.ReadAllLines(@"C:\Users\user\eclipse-workspace\simulation\output.txt");
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
        for (int i = 0; i < COLSIZE; i += 2)
        {
            for (int j = 0; j < ROWSIZE; j += 2)
            {
                if (j == ROWSIZE - 1)
                {
                    targetPosition.x -= 25f;
                    targetPosition.z += 25f;
                    for (int b = i; b < i + 2; b++)
                    {
                        if (Pst[b, j] == 0)       //길
                        {
                            GameObject roadObj = Instantiate(road) as GameObject;
                            roadObj.transform.parent = _roadParent;
                            roadObj.transform.localScale = targetScale;
                            roadObj.transform.localPosition = targetPosition;
                            _cellList.Add(roadObj);
                        }
                        else if (Pst[b, j] == 1)    //건물
                        {
                            GameObject blockObj = Instantiate(block) as GameObject;
                            blockObj.transform.parent = _blockParent;
                            blockObj.transform.localScale = buildingScale;
                            blockObj.transform.localPosition = targetPosition;
                            _cellList.Add(blockObj);
                        }
                        else if (Pst[b, j] == 2)  //바다
                        {
                            GameObject seaObj = Instantiate(sea) as GameObject;
                            seaObj.transform.parent = _seaParent;
                            seaObj.transform.localScale = seaScale;
                            seaObj.transform.localPosition = targetPosition;
                            _cellList.Add(seaObj);
                        }
                        else if (Pst[b, j] == 3)   //모래
                        {
                            GameObject sandObj = Instantiate(sand) as GameObject;
                            sandObj.transform.parent = _sandParent;
                            sandObj.transform.localScale = targetScale;
                            sandObj.transform.localPosition = targetPosition;
                            _cellList.Add(sandObj);
                        }
                        if (b == i)
                            targetPosition.z -= 50f;
                        else if (b == i + 1)
                            targetPosition.z += 50f;
                    }
                    targetPosition.x += 25f;
                    targetPosition.z -= 25f;
                }
                else if (Pst[i, j] == Pst[i, j + 1] && Pst[i, j] == Pst[i + 1, j] && Pst[i, j] == Pst[i + 1, j + 1])
                {
                    if (Pst[i, j] == 0)       //길
                    {
                        GameObject roadObj = Instantiate(road) as GameObject;
                        roadObj.transform.parent = _roadParent;
                        roadObj.transform.localScale = targetScale * 2;
                        roadObj.transform.localPosition = targetPosition;
                        _cellList.Add(roadObj);
                        targetPosition.x += 100f;
                    }
                    else if (Pst[i, j] == 1)    //건물
                    {
                        GameObject blockObj = Instantiate(block) as GameObject;
                        blockObj.transform.parent = _blockParent;
                        blockObj.transform.localScale = buildingScale * 2;
                        blockObj.transform.localPosition = targetPosition;
                        _cellList.Add(blockObj);
                        targetPosition.x += 100f;
                    }
                    else if (Pst[i, j] == 2)  //바다
                    {
                        GameObject seaObj = Instantiate(sea) as GameObject;
                        seaObj.transform.parent = _seaParent;
                        seaObj.transform.localScale = seaScale * 2;
                        seaObj.transform.localPosition = targetPosition;
                        _cellList.Add(seaObj);
                        targetPosition.x += 100f;
                    }
                    else if (Pst[i, j] == 3)   //모래
                    {
                        GameObject sandObj = Instantiate(sand) as GameObject;
                        sandObj.transform.parent = _sandParent;
                        sandObj.transform.localScale = targetScale * 2;
                        sandObj.transform.localPosition = targetPosition;
                        _cellList.Add(sandObj);
                        targetPosition.x += 100f;
                    }
                    else
                        targetPosition.x += 100f;
                }
                else
                {
                    targetPosition.x -= 25f;
                    targetPosition.z += 25f;
                    for (int a = i; a < i + 2; a++)
                    {
                        for (int b = j; b < j + 2; b++)
                        {
                            if (Pst[a, b] == 0)       //길
                            {
                                GameObject roadObj = Instantiate(road) as GameObject;
                                roadObj.transform.parent = _roadParent;
                                roadObj.transform.localScale = targetScale;
                                roadObj.transform.localPosition = targetPosition;
                                _cellList.Add(roadObj);
                                
                                targetPosition.x += 50f;
                            }
                            else if (Pst[a, b] == 1)    //건물
                            {
                                GameObject blockObj = Instantiate(block) as GameObject;
                                blockObj.transform.parent = _blockParent;
                                blockObj.transform.localScale = buildingScale;
                                blockObj.transform.localPosition = targetPosition;
                                _cellList.Add(blockObj);
                                targetPosition.x += 50f;
                            }
                            else if (Pst[a, b] == 2)  //바다
                            {
                                GameObject seaObj = Instantiate(sea) as GameObject;
                                seaObj.transform.parent = _seaParent;
                                seaObj.transform.localScale = seaScale;
                                seaObj.transform.localPosition = targetPosition;
                                _cellList.Add(seaObj);
                                targetPosition.x += 50f;
                            }
                            else if (Pst[a, b] == 3)   //모래
                            {
                                GameObject sandObj = Instantiate(sand) as GameObject;
                                sandObj.transform.parent = _sandParent;
                                sandObj.transform.localScale = targetScale;
                                sandObj.transform.localPosition = targetPosition;
                                _cellList.Add(sandObj);
                                targetPosition.x += 50f;
                            }
                            else
                                targetPosition.x += 50f;
                            if (a == i && b == j + 1)
                            {
                                targetPosition.x -= 100f;
                                targetPosition.z -= 50f;
                            }
                            if (a == i + 1 && b == j + 1)
                                targetPosition.z += 50f;
                        }
                    }
                    targetPosition.x += 25f;
                    targetPosition.z -= 25f;

                }
            }
            targetPosition.x = _xpos;
            targetPosition.z -= 100f;
        }
    }
}