using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public string music;
    public GameObject am;
    private AudioSystem s;

    private void Start()
    {
        s = am.GetComponent<AudioSystem>();
        s.Play(music);
    }
}
