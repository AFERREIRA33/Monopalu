using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject[] boxs;
    private GameObject[] Player;
    public GameObject Destination;
    public Image oldImage;
    public Sprite[] spriteTable;
    private Action[] chest;
    private int rndNum;
    public GameObject getCard;
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public int userId = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        boxs = GameObject.FindGameObjectsWithTag("Case");
        chest = new Action[]
        {
            () => WarpStart(),
            () => ErrorBank(),
            () => Doc(),
            () => SellConsol(),
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

    public void GetRandomChest(int id = 1)
    {
        userId = id - 1;
        System.Random random = new System.Random();
        rndNum = random.Next(0, chest.Length);
        oldImage.enabled = true;
        button.SetActive(true);
        oldImage.sprite = spriteTable[rndNum];
        chest[rndNum]();
        userId++;
    }

    public void ChestBack()
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
        index = index - 2;
        Player[userId].transform.position = boxs[index].transform.position;
    }

    public void ChestForward()
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
        index = index + 5;
        Player[userId].transform.position = boxs[index].transform.position;
    }

    public void GoJail()
    {

        Player[userId].transform.position = boxs[10].transform.position;
        GetComponent<GameManager>().ChangeAction();
    }
    
    public void WarpStart()
    {
        Player[userId].transform.position = boxs[0].transform.position;
        Player[userId].GetComponent<Money>().AddMoney(20000);
    }
    public void ErrorBank()
    {
        Player[userId].GetComponent<Money>().AddMoney(20000);
    }
    public void Doc()
    {
        Player[userId].GetComponent<Money>().Substract(5000);
    }
    public void SellConsol()
    {
        Player[userId].GetComponent<Money>().AddMoney(5000);
    }
    public void Income()
    {
        Player[userId].GetComponent<Money>().AddMoney(10000);
    }
    public void Birthday()
    {
        int index = 0;
        foreach (var item in Player)
        {
            index++;
            if (item == Player[userId])
            {
                Player[userId].GetComponent<Money>().AddMoney(3000);
            }
            else
            {
                Player[index].GetComponent<Money>().Substract(1000);
            }
        }
    }
    public void Contribution()
    {
        Player[userId].GetComponent<Money>().AddMoney(2000);
    }
    public void intrest()
    {
        Player[userId].GetComponent<Money>().AddMoney(2500);
    }
    public void Insurance()
    {
        Player[userId].GetComponent<Money>().Substract(5000);
    }
    public void Penalty()
    {
        Player[userId].GetComponent<Money>().Substract(1000);
    }
    public void WarpTrain()
    {
        if (userId == 0)
        {
            Destination.SetActive(true);
        } else
        {
            Player[userId].transform.position = boxs[36].transform.position;
            Player[userId].GetComponent<IA>().pos = 36;
        }
    }
    public void WinPrice()
    {
        Player[userId].GetComponent<Money>().AddMoney(1000);
    }
    public void Legacy()
    {
        Player[userId].GetComponent<Money>().AddMoney(10000);
    }
}