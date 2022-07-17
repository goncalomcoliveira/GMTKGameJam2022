using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public SpriteRenderer t;
    public Color[] list;
    int n = 0;
    private void Start()
    {
        t.color = list[n];
        n++;
    }
    private void Update()
    {
        if (n > list.Length - 1)
        {
            //termina
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            t.color = list[n];
            n++;
        }
    }
}
