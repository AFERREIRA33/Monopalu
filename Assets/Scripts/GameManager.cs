using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject text;
    public Image oldImage;
    public int userId;
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
        oldImage.enabled = false;
        text.SetActive(false);
        Debug.Log("user id : "+userId);
        if (userId > 3)
        {
            GameObject.FindGameObjectWithTag("random").GetComponent<RandomCard>().GetRandomCard();
        }
        else
        {
            Player[userId].GetComponent<IA>().Play();
        }
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
