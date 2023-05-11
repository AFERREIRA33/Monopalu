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
        Player = GameObject.FindGameObjectWithTag("Player");

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
        Player.transform.position = boxs[10].transform.position;
    }

    public void WarpTrain()
    {
        Debug.Log("Faut ajoutez le systéme");
    }

    public void WarpCivilization()
    {
        Player.transform.position = boxs[11].transform.position;
    }

    public void WarpZelda()
    {
        Player.transform.position = boxs[24].transform.position;
    }

    public void WarpStart()
    {
        Player.transform.position = boxs[0].transform.position;
        GetComponent<Money>().AddMoney(20000);
    }

    public void WarpKH()
    {
        Player.transform.position = boxs[39].transform.position;
    }

    public void WorldCupLoL()
    {
        GetComponent<Money>().AddMoney(10000);
    }

    public void Smach()
    {
        GetComponent<Money>().AddMoney(100);
    }

    public void Dividend()
    {
        GetComponent<Money>().AddMoney(5000);
    }

    public void ExitJail()
    {
        Debug.Log("Faut ajoutez le systéme");
    }

    public void Penalty()
    {
        GetComponent<Money>().Substract(1500);
    }
    public void Collector()
    {
        GetComponent<Money>().Substract(15000);

    }
    public void Cheat()
    {
        GetComponent<Money>().Substract(2000);
    }
    public void Sell()
    {
        GetComponent<Money>().AddMoney(15000);
    }
}
