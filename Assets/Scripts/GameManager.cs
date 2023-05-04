using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerLocation = 0;
    private GameObject Player;
    public GameObject[] boxs;
    // Start is called before the first frame update
    void Start()
    {
        boxs = GameObject.FindGameObjectsWithTag("Case");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
