using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class nofenemies : MonoBehaviour
{
    int n;
    private void numberof()
    {
        n++;
    }
    private void Update()
    {
        if (n == 0)
        {
            //win
        }
    }
    public int Getn()
    {
        return n;
    }

}
