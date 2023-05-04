using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGenerator : MonoBehaviour
{
    public Sprite[] Cards;
    public Image oldImage;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("r"))
        {
            ImageChange();
        }
    }

    public void ImageChange()
    {
        
        int rnd = Random.Range(0, 12);
        Debug.Log(Cards[rnd]);
        Sprite newSprite = Cards[rnd];
        oldImage.sprite = newSprite;
    }
}
