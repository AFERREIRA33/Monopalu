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
            GoJail();
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

    public void GoJail()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[10].transform.position;
    }

    public void WarpTrain()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

    }

    public void WarpCivilization()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[11].transform.position;
        Debug.Log("Ajouter gain d'argent (si passage par la case départ)");
    }

    public void WarpZelda()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[24].transform.position;
        Debug.Log("Ajouter gain d'argent (si passage par la case départ)");
    }

    public void WarpStart()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[0].transform.position;
        Debug.Log("Ajouter gain d'argent)");
    }

    public void WarpKH()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.transform.position = boxs[39].transform.position;
    }
}
