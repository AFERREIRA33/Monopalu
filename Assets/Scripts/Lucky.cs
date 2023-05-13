using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Lucky : MonoBehaviour

{
    public GameObject[] boxs;
    private GameObject Player;
    public GameObject Destination;
    public Image oldImage;
    public Sprite[] spriteTable;
    private Action[] lucky;
    private int rndNum;
    public GameObject getCard;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectWithTag("Player");
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

    public void GetRandomLucky()
    {
        System.Random random = new System.Random();
        rndNum = random.Next(0, lucky.Length);
        oldImage.enabled = true;
        button.SetActive(true);
        oldImage.sprite = spriteTable[rndNum];
        lucky[rndNum]();

    }

    public void GetRandomCard()
    {
        System.Random random = new System.Random();
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
        Destination.SetActive(true);

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

    public void Smash()
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
    public void dlcTaxe()
    {
        Debug.Log("Faut ajoutez le systéme");
    }
}
