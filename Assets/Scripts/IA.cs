using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class IA : MonoBehaviour
{

    private int[] deckAI;
    private GameObject[] boxs;
    public GameObject dataBase;
    public GameObject image;
    public int userId;
    public int pos = 0;
    private int before = 0;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        transform.position = boxs[0].transform.position;
        CreateDeck();
        string[][] whoIAm = dataBase.GetComponent<SqliteTest>().Select(new string[] {"user_name", "user_id"}, "User");
        foreach (var user in whoIAm)
        {
            if (user[0] == gameObject.name)
            {
                userId = int.Parse(user[1]);
            }
        }
    }

    private void Update()
    {
    }
    public void Play()
    {
        int[] cardRoll = GetRandomCard();
        int theIndex = pos;
        int best = 0;
        int oldBest = 0;
        string[][] dbInfo;
        int newPos;
        int roll;
        gameManager.userId = userId;
     
        foreach (var card in cardRoll)
        {
            roll = card;
            if (pos + roll > 39)
            {
                before = pos - roll;
                while (pos <= 39)
                {
                    pos++;
                    roll--;
                }
                pos = 0;
            }
            newPos = pos + roll;
            dbInfo = dataBase.GetComponent<SqliteTest>().Select(new string[] { "box_owner", "box_desc", "box_build", "box_id", "box_value" }, "Box", $"WHERE box_id = {newPos} ");
            if (dbInfo[0][1].Contains("Property"))
            {
                best = IsProperty(dbInfo);
            } else if(dbInfo[0][1].Contains("Lucky") || dbInfo[0][1].Contains("Chest"))
            {
                best = 2;
            } else if (dbInfo[0][1].Contains("Train") || dbInfo[0][1].Contains("Light") || dbInfo[0][1].Contains("Start") || dbInfo[0][1].Contains("Jail") || dbInfo[0][1].Contains("Wait"))
            {
                best = 1;
            } else
            {
                best = 0;
            }
            if (oldBest <= best)
            {
                oldBest = best;
                theIndex = newPos;
            }
        }
        GetComponent<Movement>().Move(theIndex - pos);
        pos = theIndex;
    }
    private void CreateDeck()
    {
        System.Random random = new System.Random();
        List<int>  deck = new List<int>();
        for (int i = 0; i < 30; i++)
        {
            deck.Add(random.Next(1, 3));
        }
        deckAI = deck.ToArray();
    }

    private int[] GetRandomCard()
    {
        int cardNumber = 5;
        System.Random random = new System.Random();
        int randomIndex = 0;
        if (deckAI.Length < 5)
        {
            cardNumber = deckAI.Length;
        }
        List<int> indexUse = new List<int>();
        List<int> res = new List<int>();
        bool notUse = true;
        for (int i = 0; i < cardNumber; i++)
        {
            while (notUse)
            {
                randomIndex = random.Next(0, deckAI.Length);
                if (!(indexUse.Contains(randomIndex)))
                {
                    notUse = false;
                }
            }
            indexUse.Add(randomIndex);
            res.Add(deckAI[randomIndex]);
            notUse = true;
        }
        return res.ToArray();
    }

    private int IsProperty(string[][] dbInfo)
    {
        int money = gameObject.GetComponent<Money>().money;
        int owner = int.Parse(dbInfo[0][0]);
        int build = int.Parse(dbInfo[0][2]);
        int box = int.Parse(dbInfo[0][3]);
        string value = dbInfo[0][4];
        int index = 0;
        foreach (var item in image.GetComponent<Properties>().boxs)
        {
            if (item == boxs[box])
            {
                break;
            }
            index++;
        }
        if (owner == userId)
        {
            if (money >= image.GetComponent<Properties>().dlc[index])
            {
                return 4;
            } else
            {
                return 1;
            }
        } else if (owner == 0)
        {
            if (HaveAnother(value) && money >= image.GetComponent<Properties>().price[index])
            {
                return 4;
            } else if(money >= image.GetComponent<Properties>().price[index])
            {
                return 3;
            } else
            {
                return 1;
            }
        } else
        {
            return 0;
        }
    }
    private bool HaveAnother(string value)
    {
        string[][] dbInfo = dataBase.GetComponent<SqliteTest>().Select(new string[] { "box_value" }, "Box", $"WHERE box_owner = {userId} ");
        foreach (var val in dbInfo)
        {
            if(val[0] == value)
            {
                return true;
            }
        }
        return false;
    }
}
