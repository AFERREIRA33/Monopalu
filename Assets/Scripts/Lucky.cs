using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Lucky : MonoBehaviour

{
    public GameObject[] boxs;
    private GameObject[] Player;
    public GameObject Destination;
    public Image oldImage;
    public Sprite[] spriteTable;
    private Action[] lucky;
    private int rndNum;
    public GameObject getCard;
    public GameObject button;
    public int userId;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectsWithTag("Player");
        lucky = new Action[]
        {
            () => WarpKH(),
            () => WarpStart(),
            () => WarpZelda(),
            () => WarpCivilization(),
            () => dlcTaxe(),
            () => WarpTrain(),
            () => WorldCupLoL(),
            () => Smash(),
            () => Dividend(),
            () => ExitJail(),
            () => LuckyBack(),
            () => LuckyForward(),
            () => GoJail(),
            () => Penalty(),
            () => Collector(),
            () => Cheat(),
            () => Sell()
        };
    }

    public void OkButton()
    {
        oldImage.enabled = false;
        button.SetActive(false);
        getCard.GetComponent<RandomCard>().GetRandomCard();
    }

    public void GetRandomLucky(int id = 1)
    {
        userId = id-1;
        System.Random random = new System.Random();
        rndNum = random.Next(0, lucky.Length);
        oldImage.enabled = true;
        button.SetActive(true);
        oldImage.sprite = spriteTable[rndNum];
        lucky[rndNum]();
    }

    // Update is called once per frame
    void juif()
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
            if (i.transform.position == Player[userId].transform.position)
            {
                break;
            }
            index++;
        }
        index = index - 3;
        Player[userId].transform.position = boxs[index].transform.position;
    }

    public void LuckyForward()
    {
        int index = 0;
        

        foreach (GameObject i in boxs)
        {
            if (i.transform.position == Player[userId].transform.position)
            {
                break;
            }
            index++;
        }
        index = index + 3;
        Player[userId].transform.position = boxs[index].transform.position;
    }

    public void GoJail()
    {
        Player[userId].transform.position = boxs[10].transform.position;
    }

    public void WarpTrain()
    {
        if (userId == 0)
        {
            Destination.SetActive(true);
        }
        else
        {
            Player[userId].transform.position = boxs[36].transform.position;
            Player[userId].GetComponent<IA>().pos = 36;
        }

    }

    public void WarpCivilization()
    {
        Player[userId].transform.position = boxs[11].transform.position;
    }

    public void WarpZelda()
    {
        Player[userId].transform.position = boxs[24].transform.position;
    }

    public void WarpStart()
    {
        Player[userId].transform.position = boxs[0].transform.position;
        Player[userId].GetComponent<Money>().AddMoney(20000);
    }

    public void WarpKH()
    {
        Player[userId].transform.position = boxs[39].transform.position;
    }

    public void WorldCupLoL()
    {
        Player[userId].GetComponent<Money>().AddMoney(10000);
    }

    public void Smash()
    {
        Player[userId].GetComponent<Money>().AddMoney(100);
    }

    public void Dividend()
    {
        Player[userId].GetComponent<Money>().AddMoney(5000);
    }

    public void ExitJail()
    {
        Debug.Log("Faut ajoutez le syst�me");
    }

    public void Penalty()
    {
        Player[userId].GetComponent<Money>().Substract(1500);
    }
    public void Collector()
    {
        Player[userId].GetComponent<Money>().Substract(15000);

    }
    public void Cheat()
    {
        Player[userId].GetComponent<Money>().Substract(2000);
    }
    public void Sell()
    {
        Player[userId].GetComponent<Money>().AddMoney(15000);
    }
    public void dlcTaxe()
    {
        Debug.Log("Faut ajoutez le syst�me");
    }
}
