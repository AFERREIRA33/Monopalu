using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using TMPro;


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
    public TextMeshProUGUI moneyplayer1;
    public TextMeshProUGUI moneyplayer2;
    public TextMeshProUGUI moneyplayer3;
    public TextMeshProUGUI moneyplayer4;
    public GameObject text;
    public Image oldImage;
    public int userId;
    public int prisontime = 0;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectsWithTag("Player");
        Deck();

    }

    private void Update()
    {
        moneyplayer1.text = "Money player 1: " + Player[0].GetComponent<Money>().money.ToString();
        moneyplayer2.text = "Money player 2: " + Player[1].GetComponent<Money>().money.ToString();
        moneyplayer3.text = "Money player 3: " + Player[2].GetComponent<Money>().money.ToString();
        moneyplayer4.text = "Money player 4: " + Player[3].GetComponent<Money>().money.ToString();
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
        if (userId > 3)
        {
            Debug.Log(prisontime);
            if (Player[0].GetComponent<Movement>().injail)
            {
                userId = 2;
                prisontime++;
                if (prisontime == 3)
                {
                    prisontime = 0;
                    Player[0].GetComponent<Movement>().injail = false;
                }
                ChangeAction();
            } else
            {
                GameObject.FindGameObjectWithTag("random").GetComponent<RandomCard>().GetRandomCard();
            }
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
