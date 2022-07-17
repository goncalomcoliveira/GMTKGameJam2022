using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public Sprite[] guns;
    public SpriteRenderer sr;
    public void ChangeGun(int y)
    {
        sr.sprite = guns[y - 1];
    }

}
