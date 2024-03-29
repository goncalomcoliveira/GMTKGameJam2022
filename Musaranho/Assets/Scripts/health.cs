
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public float invincibilityTime = 1f;
    public SpriteRenderer sr;
    public float isInvincible;

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
        if (Time.time >= isInvincible && sr.enabled) sr.enabled = false;

        if (maxHealth > maxHearts)
            maxHealth = maxHearts;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (maxHealth < 0)
            maxHealth = 0;

        if (currentHealth < 0)
            currentHealth = 0;

        for (int i = 0; i < maxHearts; i++)
        {

            if (i < currentHealth)
            {
                heartContainers[i].sprite = fullHeart;
            }
            else
            {
                heartContainers[i].sprite = emptyHeart;
            }

            if (i < maxHearts)
            {
                heartContainers[i].enabled = true;
            }
            else
            {
                heartContainers[i].enabled = false;
            }
        }
    }

    public void AddHeart()
    {
        maxHealth++;
    }

    public void AddHealth()
    {
        currentHealth++;
    }

    public bool TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0) {
            SceneManager.LoadScene("Derrota", LoadSceneMode.Single);
            return true;
        }
        else
            return false;
    }
}