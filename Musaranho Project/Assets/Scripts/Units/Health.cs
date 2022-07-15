using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] heartContainers;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int maxHearts;

    void Start()
    {
        maxHearts = heartContainers.Length;
    }

    void Update()
    {
        if(maxHealth > maxHearts)
            maxHealth = maxHearts;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        if(maxHealth < 0)
            maxHealth = 0;

        if(currentHealth < 0)
            currentHealth = 0;
  
        for (int i = 0; i < maxHearts; i++){

            if(i < currentHealth){
                heartContainers[i].sprite = fullHeart;
            }
            else{
                heartContainers[i].sprite = emptyHeart;
            }

            if(i < maxHearts){
                heartContainers[i].enabled = true;
            }
            else{
                heartContainers[i].enabled = false;
            }
        }
    }

    public void AddHeart(){
        maxHealth++;
    }

    public void AddHealth(){
        currentHealth++;
    }

    public bool TakeDamage(int dmg){
        currentHealth -= dmg;
        
        if(currentHealth <= 0)
            return true;
        else
            return false;
    }
}
