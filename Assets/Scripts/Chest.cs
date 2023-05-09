using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
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
            ChestBack();
        }
    }

    public void ChestBack()
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
        index = index - 2;
            Player.transform.position = boxs[index].transform.position;
    }

    public void ChestForward()
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
        index = index + 5;
        Player.transform.position = boxs[index].transform.position;
    }

    public void GoJail()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[10].transform.position;
    }
    
    public void WarpStart()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[0].transform.position;
        Debug.Log("Ajouter gain d'argent)");
    }
}