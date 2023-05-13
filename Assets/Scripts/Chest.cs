using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] boxs;
    private GameObject Player;
    public GameObject Destination;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        boxs = GameObject.FindGameObjectsWithTag("Case");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            GoJail();
        }
    }

    public void ChestBack()
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
        index = index - 2;
            Player.transform.position = boxs[index].transform.position;
    }

    public void ChestForward()
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
        index = index + 5;
        Player.transform.position = boxs[index].transform.position;
    }

    public void GoJail()
    {
        
        Player.transform.position = boxs[10].transform.position;
    }
    
    public void WarpStart()
    {
        Player.transform.position = boxs[0].transform.position;
        GetComponent<Money>().AddMoney(20000);
    }
    public void ErrorBank()
    {
        GetComponent<Money>().AddMoney(20000);
    }
    public void Doc()
    {
        GetComponent<Money>().Substract(5000);
    }
    public void SellConsol()
    {
        GetComponent<Money>().AddMoney(5000);
    }
    public void ExitJail()
    {
        Debug.Log("Faut ajoutez le systéme");
    }
    public void Income()
    {
        GetComponent<Money>().AddMoney(10000);
    }
    public void Birthday()
    {
        Debug.Log("Faut ajoutez le systéme");
    }
    public void Contribution()
    {
        GetComponent<Money>().AddMoney(2000);
    }
    public void intrest()
    {
        GetComponent<Money>().AddMoney(2500);
    }
    public void Insurance()
    {
        GetComponent<Money>().Substract(5000);
    }
    public void Penalty()
    {
        GetComponent<Money>().Substract(1000);
    }
    public void WarpTrain()
    {
        Destination.SetActive(true);
    }
    public void WinPrice()
    {
        GetComponent<Money>().AddMoney(1000);
    }
    public void Legacy()
    {
        GetComponent<Money>().AddMoney(10000);
    }
}