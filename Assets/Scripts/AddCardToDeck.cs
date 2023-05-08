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

        Button btn = GameObject.Instantiate(buttonDeck);
        btn.name = clickedButton.name;
        btn.GetComponentInChildren<TextMeshProUGUI>().text = clickedButton.GetComponentInChildren<TextMeshProUGUI>().text;
        btn.transform.SetParent(deck.transform, false);
        btn.transform.localPosition = buttonPos;
        buttonPos.y += -30;
        buttonOfDeck.Add(btn);
        RefreshDeck();
    }
    public void DeleteCard(GameObject a)
    {
        Destroy(a);
    }
    private void RefreshDeck()
    {
        List<Button> newList = new List<Button>();
        buttonPos = new Vector3(90f, -20f, 0f);
        foreach (Button b in buttonOfDeck)
        {
            if (b.IsDestroyed())
            {
            }
            else
            {
                b.transform.localPosition = buttonPos;
                buttonPos.y += -30;
                newList.Add(b);
            }
        }
        buttonOfDeck = newList;
    }
}
