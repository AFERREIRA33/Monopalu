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
    public void AddCard(GameObject a)
    {

        Button btn = GameObject.Instantiate(buttonDeck);
        btn.name = a.name;
        btn.GetComponentInChildren<TextMeshProUGUI>().text = a.GetComponentInChildren<TextMeshProUGUI>().text;
        btn.transform.SetParent(deck.transform, false);
        btn.transform.localPosition = buttonPos;
        buttonPos.y += -30;
        Debug.Log(a.name);
        Debug.Log(btn.name);
    }
    public void DeleteCard(GameObject a)
    {

    }
}
