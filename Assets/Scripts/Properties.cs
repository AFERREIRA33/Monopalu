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
    public GameObject text;
    private int globalindex;
    private bool isOncase = true;
    private GameObject Player;
    private int numberpropeties;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOncase)
        {
            SpawnProperties();
        }
    }

    public void SpawnProperties()
    {
        int index = 0;

        foreach(GameObject property in boxs)
        {
            if (Player.transform.position == property.transform.position)
            {
                if (numberpropeties > 4)
                {
                    isOncase = true;
                } else
                {
                    oldImage.enabled = true;
                    button1.SetActive(true);
                    button2.SetActive(true);
                    oldImage.sprite = spritetable[index];
                    globalindex = index;
                    isOncase = true;
                }
            }
            index++;
        }
    }

    public void BuyPropety()
    {
        string[][] dbalreadyown = db.GetComponent<SqliteTest>().Select(new string[] { "box_owner" }, "Box", $" WHERE box_id = {globalindex}");
        if (dbalreadyown[0][0] == "1" && numberpropeties <= 4 && Player.GetComponent<Money>().GetMoney() >= dlc[globalindex])
        {
            db.GetComponent<SqliteTest>().ModifyElement("Box", new string[] { "box_build" }, new string[] { $"{ numberpropeties }" }, $" WHERE box_id = {globalindex}");
            Player.GetComponent<Money>().Substract(dlc[globalindex]);
            numberpropeties++;
            oldImage.enabled = false;
            button1.SetActive(false);
            button2.SetActive(false);
        } else if (dbalreadyown[0][0] == "0" && numberpropeties < 4 && Player.GetComponent<Money>().GetMoney() >= price[globalindex])
        {
            db.GetComponent<SqliteTest>().ModifyElement("Box", new string[] { "box_owner" }, new string[] { "1" }, $" WHERE box_id = {globalindex}");
            Player.GetComponent<Money>().Substract(price[globalindex]);
            numberpropeties++;
            oldImage.enabled = false;
            button1.SetActive(false);
            button2.SetActive(false);
        } else
        {
            text.SetActive(true);
        }
    }

    public void NotBuy()
    {
        Debug.Log("no");
        oldImage.enabled = false;
        button1.SetActive(false);
        button2.SetActive(false);
        text.SetActive(false);
    }

    public void SetIsOnCase(bool cas)
    {
        isOncase = cas;
    }


}
