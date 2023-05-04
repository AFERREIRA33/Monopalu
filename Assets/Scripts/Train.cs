using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public GameObject TrainHud;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void North()
    {
        TrainHud = GameObject.Find("Destination");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        Player.transform.position = boxs[25].transform.position;
        TrainHud.SetActive(false);
    }

    public void South()
    {
        TrainHud = GameObject.Find("Destination");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        Player.transform.position = boxs[5].transform.position;
        TrainHud.SetActive(false);
    }
    public void East()
    {
        TrainHud = GameObject.Find("Destination");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        Player.transform.position = boxs[35].transform.position;
        TrainHud.SetActive(false);
    }
    public void West()
    {
        TrainHud = GameObject.Find("Destination");
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        Player.transform.position = boxs[15].transform.position;
        TrainHud.SetActive(false);
    }
}