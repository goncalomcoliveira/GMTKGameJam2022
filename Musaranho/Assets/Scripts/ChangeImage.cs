using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite[] im;
    public Image t;
    int n;

    private void Start()
    {
        t.sprite = im[0];
        n++;
    }
    private void Update()
    {
        if (n > im.Length - 1)
        {
            //termina
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            t.sprite = im[n];
            n++;
        }
    }
}
