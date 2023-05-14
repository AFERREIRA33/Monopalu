using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Properties : MonoBehaviour
{
    public GameObject db;
    public int[] dlc;
    public int[] price;
    public Sprite[] spritetable;
    public Image oldImage;
    public GameObject[] boxs;
    public GameObject button1;
    public GameObject button2;
    public GameObject okButton;
    public GameObject text;
    private int[][] paycase = new int[][]
    {
        new int[] {200,400,600,600,800,1000,1000,1200,1400,1400,1600,1800,1800,2000,2200,2200,2400,2600,2600,2800,3500,5000},
        new int[] {1000,2000,3000,3000,4000,5000,5000,6000,7000,7000,8000,9000,9000,10000,11000,11000,12000,13000,13000,15000,17500,20000},
        new int[] {3000,6000,9000,9000,10000,15000,15000,18000,20000,20000,22000,25000,25000,30000,33000,33000,36000,39000,39000,45000,50000,60000},
        new int[] {9000,18000,27000,27000,30000,45000,45000,50000,55000,55000,60000,70000,70000,75000,80000,80000,85000,90000,90000,100000,110000,140000},
        new int[] {16000,32000,40000,40000,45000,62500,62500,70000,70000,75000,80000,87500,87500,92500,97500,97500,102500,110000,110000,120000,130000,170000},
        new int[] {25000,45000,55000,55000,60000,75000,75000,90000,90000,95000,100000,105000,105000,110000,115000,115000,120000,127500,127500,140000,150000,200000},
    };
    private int globalindex;
    private GameObject[] player;
    public int userId = 0;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SpawnProperties(int id = 1)
    {
        userId = id-1;
        index = 0;
        foreach(GameObject property in boxs)
        {
            if (player[userId].transform.position == property.transform.position)
            {
                string[] numCase = property.name.Split("Case");
                globalindex = int.Parse(numCase[1])-1;
                string[][] numberpropre = db.GetComponent<SqliteTest>().Select(new string[] { "box_build", "box_id" }, "Box", $" WHERE box_id = {globalindex}");
                string[][] ownedbyother = db.GetComponent<SqliteTest>().Select(new string[] { "box_owner" }, "Box", $" WHERE box_id = {globalindex}");
                int numberpropeInt = int.Parse(numberpropre[0][0]);
                if (ownedbyother[0][0] != userId.ToString() && ownedbyother[0][0] != "0")
                {
                    PayOtherProperties();
                } else if (numberpropeInt > 5)
                {
                } else 
                {
                    if (userId ==0)
                    {
                        oldImage.enabled = true;
                        button1.SetActive(true);
                        button2.SetActive(true);
                        oldImage.sprite = spritetable[index];
                    } else
                    {
                        oldImage.enabled = true;
                        okButton.SetActive(true);
                        oldImage.sprite = spritetable[index];
                        BuyPropety();
                    }
                }
                break;
            }
            index++;
        }
    }

    public void BuyPropety()
    {
        string[][] numberpropre = db.GetComponent<SqliteTest>().Select(new string[] { "box_build" }, "Box", $" WHERE box_id = {globalindex}");
        int numberpropeties = int.Parse(numberpropre[0][0]);
        string[][] dbalreadyown = db.GetComponent<SqliteTest>().Select(new string[] { "box_owner" }, "Box", $" WHERE box_id = {globalindex}");
        if (dbalreadyown[0][0] == userId.ToString() && numberpropeties <= 5 && player[userId].GetComponent<Money>().GetMoney() >= dlc[index])
        {
            db.GetComponent<SqliteTest>().ModifyElement("Box", new string[] { "box_build" }, new string[] { $"{ numberpropeties }" }, $" WHERE box_id = {globalindex}");
            player[userId].GetComponent<Money>().Substract(dlc[index]);
            numberpropeties++;
            db.GetComponent<SqliteTest>().ModifyElement("Box", new string[] { "box_build" }, new string[] { $"{ numberpropeties }" }, $" WHERE box_id = {globalindex}");
            player[userId].GetComponent<Money>().Substract(dlc[index]);
            if (userId == 0)
            {
                oldImage.enabled = false;
                button1.SetActive(false);
                button2.SetActive(false);
            }
        } else if (dbalreadyown[0][0] == "0" && numberpropeties < 5 && player[userId].GetComponent<Money>().GetMoney() >= price[index])
        {
            db.GetComponent<SqliteTest>().ModifyElement("Box", new string[] { "box_owner" }, new string[] { $"{userId}" }, $" WHERE box_id = {globalindex}");
            player[userId].GetComponent<Money>().Substract(price[index]);
            numberpropeties++;
            if (userId == 0)
            {
                oldImage.enabled = false;
                button1.SetActive(false);
                button2.SetActive(false);
            }
        } else
        {
            text.SetActive(true);
        }
    }

    public void NotBuy()
    {
        oldImage.enabled = false;
        button1.SetActive(false);
        button2.SetActive(false);
        text.SetActive(false);
    }

    public void PayOtherProperties()
    {
        string[][] numberpropr = db.GetComponent<SqliteTest>().Select(new string[] { "box_build" }, "Box", $" WHERE box_id = {globalindex}");
        string[][] owner = db.GetComponent<SqliteTest>().Select(new string[] { "box_owner" }, "Box", $" WHERE box_id = {globalindex}");
        player[userId].GetComponent<Money>().Substract(paycase[globalindex][int.Parse(numberpropr[0][0])]);
    }

}
