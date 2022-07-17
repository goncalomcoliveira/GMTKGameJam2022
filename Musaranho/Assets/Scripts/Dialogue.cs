using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] dialogo;
    public TMP_Text t;
    int n;

    private void Start()
    {
        t.text = dialogo[0];
    }
    private void Update()
    {
        Debug.Log(n);
        if (n > dialogo.Length - 1)
        {
            //termina
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            t.text = dialogo[n];
            n++;
        }
    }
}
