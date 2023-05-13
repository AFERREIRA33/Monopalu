using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject[] boxs;
    private GameObject Player;
    public GameObject Destination;
    public Image oldImage;
    public Sprite[] spriteTable;
    private Action[] chest;
    private int rndNum;
    public GameObject getCard;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        boxs = GameObject.FindGameObjectsWithTag("Case");
        chest = new Action[]
        {
            () => WarpStart(),
            () => ErrorBank(),
            () => Doc(),
            () => SellConsol(),
            () => ExitJail(),
            () => GoJail(),
            () => Income(),
            () => ChestForward(),
            () => ChestBack(),
            () => Birthday(),
            () => Contribution(),
            () => intrest(),
            () => Insurance(),
            () => Penalty(),
            () => WarpTrain(),
            () => WinPrice(),
            () => Legacy()
        };
    }
    public void OkButton()
    {
        oldImage.enabled = false;
        button.SetActive(false);
        getCard.GetComponent<RandomCard>().GetRandomCard();
    }

    public void GetRandomChest()
    {
        System.Random random = new System.Random();
        rndNum = random.Next(0, chest.Length);
        oldImage.enabled = true;
        button.SetActive(true);
        oldImage.sprite = spriteTable[rndNum];
        chest[rndNum]();

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
        Player.GetComponent<Money>().AddMoney(20000);
    }
    public void ErrorBank()
    {
        Player.GetComponent<Money>().AddMoney(20000);
    }
    public void Doc()
    {
        Player.GetComponent<Money>().Substract(5000);
    }
    public void SellConsol()
    {
        Player.GetComponent<Money>().AddMoney(5000);
    }
    public void ExitJail()
    {
        Debug.Log("Faut ajoutez le systéme");
    }
    public void Income()
    {
        Player.GetComponent<Money>().AddMoney(10000);
    }
    public void Birthday()
    {
        Debug.Log("Faut ajoutez le systéme");
    }
    public void Contribution()
    {
        Player.GetComponent<Money>().AddMoney(2000);
    }
    public void intrest()
    {
        Player.GetComponent<Money>().AddMoney(2500);
    }
    public void Insurance()
    {
        Player.GetComponent<Money>().Substract(5000);
    }
    public void Penalty()
    {
        Player.GetComponent<Money>().Substract(1000);
    }
    public void WarpTrain()
    {
        Destination.SetActive(true);
    }
    public void WinPrice()
    {
        Player.GetComponent<Money>().AddMoney(1000);
    }
    public void Legacy()
    {
        Player.GetComponent<Money>().AddMoney(10000);
    }
}