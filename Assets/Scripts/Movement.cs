using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public GameObject[] boxs;

    public int[] playerCard;
    public GameObject image;
    public GameObject start;
    public GameObject[] taxe;
    public GameObject Destination;
    public GameObject pos;
    public GameObject jail;
    public GameObject sleep;
    public GameObject[] station;
    public GameObject[] chest;
    public GameObject[] lucky;
    public GameObject[] lightCase;
    public GameObject[] player;
    public GameObject button;
    public GameObject button2;
    public bool isAI;
    public int randomnumber;
    public bool isjail;

    public int boxIndex = 0;
    public int befor = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.FindGameObjectWithTag("ImageCenter");
        boxs = GameObject.FindGameObjectsWithTag("Case");
        player = GameObject.FindGameObjectsWithTag("Player");
        transform.position = boxs[boxIndex].transform.position;
        isjail = false;
    }

    public int RandomNumber()
    {
        System.Random random = new System.Random();
        int nombre = random.Next(1, 13);
        return nombre;
    }

    public void Move(int rollnumber)
    {
        Debug.Log("rollnumber : " + rollnumber);
        if (boxIndex + rollnumber > 39)
        {
            befor = boxIndex - rollnumber;
            while (boxIndex <= 39)
            {
                boxIndex++;
                rollnumber--;
            }
            boxIndex = 0;
        }  
        Debug.Log("position avant : " + boxIndex);
        boxIndex += rollnumber;
        pos = boxs[boxIndex];
        Debug.Log("position apres : " + pos.name);
        transform.position = boxs[boxIndex].transform.position;
        if (isAI)
        {
            image.GetComponent<Properties>().SpawnProperties(GetComponent<IA>().userId);
        } else
        {
            image.GetComponent<Properties>().SpawnProperties();
        }

        if (pos == jail)
        {
            transform.position = boxs[10].transform.position;
            isjail =  true;
            button.SetActive(true);

        }

        if (boxIndex < befor)
        {
            GetComponent<Money>().AddMoney(20000);
            button.SetActive(true);
        }
        if (pos == sleep || pos == boxs[10])
        {
            button.SetActive(true);
        }

        if (pos == start)
        {
            GetComponent<Money>().AddMoney(20000);
            button.SetActive(true);
        }
        if (ArrayUtility.Contains(station, pos))
        {
            if (!isAI)
            {
                Destination.SetActive(true);
            } else
            {
                button.SetActive(true);
            }
        }
        if (ArrayUtility.Contains(lucky, pos))
        {
            if (isAI)
            {
                image.GetComponent<Lucky>().GetRandomLucky(GetComponent<IA>().userId);
            }
            else
            {
                image.GetComponent<Lucky>().GetRandomLucky();
            }
        }
        if (ArrayUtility.Contains(chest, pos)) {
            if(isAI)
            {
                image.GetComponent<Chest>().GetRandomChest(GetComponent<IA>().userId);
            } else
            {
                image.GetComponent<Chest>().GetRandomChest();
            }
        }
        if (ArrayUtility.Contains(taxe, pos))
        {
            GetComponent<Money>().Substract(20000);
            button.SetActive(true);
        }
        if (ArrayUtility.Contains(lightCase, pos))
        {
            randomnumber = RandomNumber();
            Move(randomnumber);
        }
    }
}
