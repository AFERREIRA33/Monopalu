using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] boxs;

    public int[] playerCard;
    public GameObject image;
    public GameObject start;
    public GameObject[] taxe;
    public GameObject Destination;
    public GameObject HUD;
    public GameObject pos;
    public GameObject jail;
    public GameObject[] station;
    public GameObject[] lucky;
    public GameObject[] chest;

    public int boxIndex = 0;
    public int befor = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.FindGameObjectWithTag("ImageCenter");
        boxs = GameObject.FindGameObjectsWithTag("Case");
        transform.position = boxs[boxIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int rollnumber)
    {   
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
        
        boxIndex += rollnumber;
        
        pos = boxs[boxIndex];
        transform.position = boxs[boxIndex].transform.position;
        image.GetComponent<Properties>().SetIsOnCase(false);

        if (pos == jail)
        {
            transform.position = boxs[10].transform.position;
        }

        if (boxIndex < befor)
        {
            GetComponent<Money>().AddMoney(20000);
        }

        if (pos == start)
        {
            GetComponent<Money>().AddMoney(20000);
        }

        foreach (var item in station)
        {
            if (pos == item)
            {
                Destination.SetActive(true);
            }
        }
        foreach (var item in lucky)
        {
            if (pos == item)
            {
                Debug.Log("Tu est sur une case Lucky");
            }
        }
        foreach (var item in chest)
        {
            if (pos == item)
            {
                Debug.Log("Tu est sur une case coffre");
            }
        }
        foreach (var item in taxe)
        {
            if (pos == item)
            {
                GetComponent<Money>().Substract(20000);
                Debug.Log("T'es povre");
            }
        }
    }
}
