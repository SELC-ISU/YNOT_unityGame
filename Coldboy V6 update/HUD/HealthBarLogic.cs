using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarLogic : MonoBehaviour
{
    public Sprite[] healthPossibilities = new Sprite[5];
    public Inventory player;
    private int currentHealth = 4;
    public SpriteRenderer healthBar;

    public void Start()
    {
        healthBar = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void useHealth()
    {
        currentHealth = player.getHealth();
        int temp = currentHealth;
        healthBar.sprite = healthPossibilities[temp];
    }

    public void reset()
    {
        currentHealth = 4;
        int temp = currentHealth;
        healthBar.sprite = healthPossibilities[temp];
    }
}