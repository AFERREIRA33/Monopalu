using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomCard : MonoBehaviour
{
    public GameObject player;
    public GameObject[] allCards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomCard()
    {
        int cardNumber = 5;
        int[] playerCard = player.GetComponent<Movement>().playerCard;
        System.Random random = new System.Random();
        int randomIndex = 0;
        Vector3 cardCoo = transform.position;
        if (playerCard.Length < 5)
        {
            cardNumber = playerCard.Length;
        }
        List<int> indexUse = new List<int>();
        bool notUse = true;
        for (int i = 0; i < cardNumber; i++)
        {
            while (notUse)
            {
                randomIndex = random.Next(0, playerCard.Length);
                if (!(indexUse.Contains(randomIndex)))
                {
                    notUse = false;
                }
            }
            indexUse.Add(randomIndex);
            Instantiate(allCards[playerCard[randomIndex]], cardCoo, Quaternion.identity);
            cardCoo.x += 1;
            notUse = true;
        }
    }




}
