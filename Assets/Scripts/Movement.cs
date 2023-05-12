using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] boxs;

    public int[] playerCard;
    public GameObject image;
    public GameObject pos;
    public GameObject jail;

    public int boxIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.FindGameObjectWithTag("ImageCenter");
        boxs = GameObject.FindGameObjectsWithTag("Case");
        transform.position = boxs[boxIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(int rollnumber)
    {
        // Move to the choosen index
        
        if (boxIndex + rollnumber > 39)
        {
            while (boxIndex <= 39)
            {
                boxIndex++;
                rollnumber--;
            }
            boxIndex = 0;
        }
        boxIndex += rollnumber;
        pos = boxs[boxIndex];
        transform.position = boxs[boxIndex].transform.position;
        image.GetComponent<Properties>().SetIsOnCase(false);

        if (pos == jail)
        {
            transform.position = boxs[10].transform.position;
        }

    }
}
