using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{

    private int[] testtable = {1,3,5,6,8,10,12};

    private bool[] cisp = { true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true };

    private int index1=0;

    public Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("r"))
        {
            int index = index1;
            int pos = 0;
            if (index >=39)
            {
                index = 0;
            }
            for (; index < 12;)
            {
                if (cisp[index] != true)
                {
                    pos = testtable[index];
                    index1=index;
                    break;
                    
                }
                index++;
            }
            Debug.Log(index1);
            movement.Move(pos);
        }
    }
}
