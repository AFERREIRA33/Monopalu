using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Money : MonoBehaviour
{
    public int money;
    // Start is called before the first frame update
    void Start()
    {
        money = 148000;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Substract(int moneysubstract)
    {
        money -= moneysubstract;
    }

    public void AddMoney(int moneytoadd)
    {
        money += moneytoadd;
        
    }

    public int GetMoney()
    {
        return money;
    }
}
