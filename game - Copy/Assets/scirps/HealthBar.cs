using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI healthText;
    public int maxHealth;
    public Transform respawnPoint;


    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (health <= 0)
        {
            RespawnPlayer();
        
        }    

    }

    void RespawnPlayer()
    {
        SceneManager.LoadScene("Game");
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("healing"))
        {
            UpdateHealth(40);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("damaging"))
        {
            UpdateHealth(-100);
        }
        if (other.CompareTag("EnemyDmg"))
        {
            UpdateHealth(-20);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("big healing"))
        {
            UpdateHealth(100);
            Destroy(other.gameObject);
        }if (other.CompareTag("Boss dmg"))
        {
            UpdateHealth(-40);
            Destroy(other.gameObject);
        }
        
    }

    void UpdateHealth(int adjustment)
    {
        health += adjustment;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthText.text = "Health: " + health.ToString();
     
    }

   
}

