using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementCard : MonoBehaviour
{

    public int number;

    private GameObject Player;

    private Vector2 startposition;

    private bool up = false;


    void Start()
    {
        startposition = transform.position;
    }

    private void OnMouseDown()
    {
        // call Movement function
        MoveNumber();
    }
    public void MoveNumber()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
        Player.GetComponent<Movement>().Move(number);
        Destroy(gameObject);
    }

    public void OnMouseOver()
    {
        // get the object to move up

        if (!up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y+0.5f);
            up = true;
        }
    }

    private void OnMouseExit()
    {
        // get the object to return to it start position
        if (up)
        {
            Debug.Log(startposition);
            transform.position = startposition;
            up = false;
        }
    }


}

