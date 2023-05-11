using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddCardToDeck : MonoBehaviour
{
    public GameObject deck;
    public Button buttonDeck;
    private Vector3 buttonPos;
    public List<Button> buttonOfDeck;
    public GameObject database;
    public TextMeshProUGUI counterCard;
    private string[] nameForButton= new string[] { "Card1", "Card2", "Card3", "Card4", "Card5", "Card6", "Card7", "Card8", "Card9", "Card10", "Card11", "Card12", };
    // Start is called before the first frame update
    void Start()
    {
        buttonPos = new Vector3(90f, -20f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create the Button for delete the card from the deck
    public void AddCard(GameObject clickedButton)
    {
        if (buttonOfDeck.Count <= 30)
        {
            counterCard.text = buttonOfDeck.Count + "/30";
            Button btn = GameObject.Instantiate(buttonDeck);
            btn.name = clickedButton.name;
            btn.GetComponentInChildren<TextMeshProUGUI>().text = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
            btn.transform.SetParent(deck.transform, false);
            btn.transform.localPosition = buttonPos;
            buttonPos.y += -30;
            buttonOfDeck.Add(btn);
            RefreshDeck();
        }
    }

    //Delete the selected button 
    public void DeleteCard(GameObject a)
    {
        Destroy(a);
        RefreshDeck();
    }

    // center the button after a modification
    public void RefreshDeck()
    {
        List<Button> newList = new List<Button>();
        buttonPos = new Vector3(90f, -20f, 0f);
        foreach (Button b in buttonOfDeck)
        {
            if (!b.IsDestroyed())
            {
                b.transform.localPosition = buttonPos;
                buttonPos.y += -30;
                newList.Add(b);
            }
        }
        buttonOfDeck = newList;
        counterCard.text = buttonOfDeck.Count + "/30";
    }


    public void SaveData()
    {
        database.GetComponent<SqliteTest>().DeleteElement("UserCard", "WHERE user_id = 1");
        List<string> btnName = new List<string>();
        List<string[]> respond = new List<string[]>();
        foreach (var btn in buttonOfDeck)
        {
            btnName.Add("1");
            btnName.Add(btn.name);
            respond.Add(btnName.ToArray());
            btnName.RemoveRange(0, 2);
        }
        database.GetComponent<SqliteTest>().InsertInto("UserCard", new string[] { "user_id", "card_id" }, respond.ToArray());
    }

    public void GetDeck()
    {
        RefreshDeck();
        string[][] playerDeck = database.GetComponent<SqliteTest>().Select(new string[] {"card_id"}, "UserCard", " WHERE user_id = 1");
        buttonPos = new Vector3(90f, -20f, 0f);
        foreach (var card in playerDeck)
        {
            Button btn = GameObject.Instantiate(buttonDeck);
            btn.name = card[0];
            int val = int.Parse(card[0])+1;
            btn.GetComponentInChildren<TextMeshProUGUI>().text = val.ToString();
            btn.transform.SetParent(deck.transform, false);
            btn.transform.localPosition = buttonPos;
            buttonPos.y += -30;
            buttonOfDeck.Add(btn);
        }
    }

    public void DestroyDeck()
    {
        RefreshDeck();
        foreach (var b in buttonOfDeck)
        {
            Destroy(b.gameObject);
        }
        buttonOfDeck.RemoveRange(0, buttonOfDeck.Count);

    }
}
