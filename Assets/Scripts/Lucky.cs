using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lucky : MonoBehaviour

{
    public GameObject[] boxs;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            LuckyForward();
        }
    }

    public void LuckyBack()
    {
        int index = 0;
        Player = GameObject.FindGameObjectWithTag("Player");

        foreach (GameObject i in boxs)
        {
            if (i.transform.position == Player.transform.position)
            {
                break;
            }
            index++;
        }
        index = index - 3;
            Player.transform.position = boxs[index].transform.position;
    }

    public void LuckyForward()
    {
        int index = 0;
        Player = GameObject.FindGameObjectWithTag("Player");

        foreach (GameObject i in boxs)
        {
            if (i.transform.position == Player.transform.position)
            {
                break;
            }
            index++;
        }
        index = index + 3;
        Player.transform.position = boxs[index].transform.position;
    }
}
