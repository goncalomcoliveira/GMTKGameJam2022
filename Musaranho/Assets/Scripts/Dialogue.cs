using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public string place = "aPutaQueTePariu";
    public string[] dialogo;
    public TMP_Text t;
    int n;

    private void Start()
    {
        t.text = dialogo[0];
        n++;
    }
    private void Update()
    {
        if (n > dialogo.Length-1)
        {
            if (place != "aPutaQueTePariu")
            {
                SceneManager.LoadScene(place, LoadSceneMode.Single);
            }
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            t.text = dialogo[n];
            n++;
        }
    }
}
