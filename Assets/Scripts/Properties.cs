using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Properties : MonoBehaviour
{
    public int[] price;
    public GameObject Player;
    public Sprite[] spritetable;
    public Image oldImage;
    public GameObject[] boxs;
    public GameObject button1;
    public GameObject button2;
    private int globalindex;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnProperties();
    }

    public void SpawnProperties()
    {
        int index = 0;

        foreach(GameObject property in boxs)
        {
            if (Player.transform.position == property.transform.position)
            {
                oldImage.enabled = true;
                button1.SetActive(true);
                button2.SetActive(true);
                oldImage.sprite = spritetable[index];
                globalindex = index;
            }
            index++;
        }
    }

    public void BuyPropety()
    {
        Debug.Log(globalindex);
        Player.GetComponent<Money>().BuyProperties(price[globalindex]);
        oldImage.enabled = false;
        button1.SetActive(false);
        button2.SetActive(false);
        
    }

    public void NotBuy()
    {
        Debug.Log("no");
        oldImage.enabled = false;
        button1.SetActive(false);
        button2.SetActive(false);
    }


}