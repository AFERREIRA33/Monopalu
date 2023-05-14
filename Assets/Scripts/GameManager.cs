using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;


public class GameManager : MonoBehaviour
{
    public int PlayerLocation = 0;
    private GameObject[] Player;
    public GameObject[] boxs;
    public GameObject dataBase;
    public GameObject spawnCard;
    public GameObject button;
    public GameObject button1;
    public GameObject button2;
    public int userId;
    public int prisontime = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectsWithTag("Player");
        Deck();

    }

    public void Deck()
    {
        string[][] playerDeck = dataBase.GetComponent<SqliteTest>().Select(new string[] { "card_id" }, "UserCard", " WHERE user_id = 1");
        List<int> playerDeckList = new List<int>() { };
        foreach (var card in playerDeck)
        {
            playerDeckList.Add(int.Parse(card[0]));
        }
        Player[0].GetComponent<Movement>().playerCard = playerDeckList.ToArray();
        spawnCard.GetComponent<RandomCard>().GetRandomCard();
    }

    public void ChangeAction()
    {
        button.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        Debug.Log(userId);
        if (Player[0].GetComponent<Movement>().isjail && userId == 1)
        {
            Debug.Log("Oh non je suis en prison");
            userId = 2;
            prisontime++;
            if (prisontime == 3)
            {
                prisontime = 0;
                Player[0].GetComponent<Movement>().isjail = false;
            }
        }
        if (Player[0].GetComponent<Movement>().isjail && userId == 2)
        {
            Debug.Log("L'IA 2 est en prison");
            userId = 3;
            prisontime++;
            if (prisontime == 3)
            {
                prisontime = 0;
                Player[0].GetComponent<Movement>().isjail = false;
            }
        }
        if (Player[0].GetComponent<Movement>().isjail && userId == 3)
        {
            Debug.Log("L'IA 3 est en prison");
            userId = 4;
            prisontime++;
            if (prisontime == 3)
            {
                prisontime = 0;
                Player[0].GetComponent<Movement>().isjail = false;
            }
        }
        if (Player[0].GetComponent<Movement>().isjail && userId == 4)
        {
            Debug.Log("L'IA 4 est en prison");
            userId = 1;
            prisontime++;
            if (prisontime == 3)
            {
                prisontime = 0;
                Player[0].GetComponent<Movement>().isjail = false;
            }
        }
        if (userId > 3)
        {
            GameObject.FindGameObjectWithTag("random").GetComponent<RandomCard>().GetRandomCard();
        }
        else
        {
            Player[userId].GetComponent<IA>().Play();
        }
    }
}
