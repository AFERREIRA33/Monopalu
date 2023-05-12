using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerLocation = 0;
    private GameObject Player;
    public GameObject[] boxs;
    public GameObject dataBase;
    public GameObject spawnCard;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectWithTag("Player");
        Deck();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Deck()
    {
        string[][] playerDeck = dataBase.GetComponent<SqliteTest>().Select(new string[] { "card_id" }, "UserCard", " WHERE user_id = 1");
        List<int> playerDeckList = new List<int>() { };  
        foreach (var card in playerDeck)
        {
            playerDeckList.Add(int.Parse(card[0]));
        }
        Player.GetComponent<Movement>().playerCard = playerDeckList.ToArray();
        spawnCard.GetComponent<RandomCard>().GetRandomCard();
    }
}
