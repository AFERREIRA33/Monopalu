using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        money = 148000;
        Debug.Log(money);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BuyProperties(int propetiesprize)
    {
        money -= propetiesprize;
        Debug.Log(money);
    }

    public void AddMoney(int moneytoadd)
    {
        money += moneytoadd;
        Debug.Log(money);
    }
}
