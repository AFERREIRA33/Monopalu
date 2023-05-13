using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public GameObject TrainHud;
    public GameObject player;

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
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        player.transform.position = boxs[25].transform.position;
        player.GetComponent<Movement>().boxIndex = 25;
        TrainHud.SetActive(false);

    }

    public void South()
    {
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        player.transform.position = boxs[5].transform.position;
        player.GetComponent<Movement>().boxIndex = 5;
        TrainHud.SetActive(false);
    }
    public void East()
    {
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        player.transform.position = boxs[35].transform.position;
        player.GetComponent<Movement>().boxIndex = 35;
        TrainHud.SetActive(false);
    }
    public void West()
    {
        GameObject[] boxs = GameObject.FindGameObjectsWithTag("Case");
        player.transform.position = boxs[15].transform.position;
        player.GetComponent<Movement>().boxIndex = 15;
        TrainHud.SetActive(false);
    }
}