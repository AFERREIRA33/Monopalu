using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] allPlayer;
    public bool turn = true;
    // Start is called before the first frame update
    void Start()
    {
        allPlayer = GameObject.FindGameObjectsWithTag("Player").OrderBy(go => go.name).ToArray();
        allPlayer[0].GetComponent<playerTurn>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach(GameObject player in allPlayer)
        {
            if(player.name == "player")
            {
                player.GetComponent<playerTurn>().enabled = true;
            } else if(!turn)
            {
                Debug.Log(count);
                count++;
            }
        }
        if (!turn)
        {
            turn = true;
            allPlayer[0].GetComponent<playerTurn>().enabled = false;
        }
    }
}
