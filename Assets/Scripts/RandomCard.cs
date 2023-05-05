using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomCard : MonoBehaviour
{
    public int[] playerCard;
    public GameObject[] allCards;
    // Start is called before the first frame update
    void Start()
    {
        playerCard = new int[] {5, 4 , 2,3,1,4,6,7,9,1,10,11,1,6,7,6};
        playerCard = GetRandomCard();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] GetRandomCard()
    {
        System.Random random = new System.Random();
        int randomIndex;
        Vector3 cardCoo = transform.position;
        for (int i = 0; i < 5; i++)
        {
            randomIndex = random.Next(0, playerCard.Length);
            Instantiate(allCards[playerCard[randomIndex]], cardCoo, Quaternion.identity);
            cardCoo.x += 1;
        }
        return playerCard;
    }




}
