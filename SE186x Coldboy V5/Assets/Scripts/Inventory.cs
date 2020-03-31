using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private static int currentEnergy, currentHealth;
    private static int totalEnergy, totalHealth;
    private static int batteries, healthPacks;

    public GameObject SpawnPoint;
    public void Start()
    {
        //SpawnPoint = GetComponent<Transform>();
       // Coldboy = GetComponent<Transform>();
        totalEnergy = 100;
        currentEnergy = totalEnergy;
        totalHealth = 4;
        currentHealth = totalHealth;
        batteries = 0;
        healthPacks = 0;
    }

    private void Die()
    {
        Debug.Log("Killed! TE = " + totalEnergy + " TH = " + totalHealth);
        this.transform.position = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, 1f);
        currentHealth = totalHealth;
        currentEnergy = totalEnergy;
        batteries = 0;
        healthPacks = 0;
        
    }
    public void Damage(int hpTaken)
    {
        
        currentHealth -= hpTaken;
        Debug.Log("Damaged! HP: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int hpHealed)
    {
        currentHealth += hpHealed;
        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
    }

    public void PermanentlyBoostHealth(int hpBoost)
    {
        totalHealth += hpBoost;
        currentHealth = totalHealth;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void UseEnergy(int energyUsed)
    {
        currentEnergy -= energyUsed;
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }

    public void Recharge(int energyGained)
    {
        currentEnergy += energyGained;
        if (currentEnergy > totalEnergy)
        {
            currentEnergy = totalEnergy;
        }
    }

    public void PermanentlyBoostEnergy(int energyBoost)
    {
        totalEnergy += energyBoost;
        currentEnergy = totalEnergy;
    }

    public int getEnergy()
    {
        return currentEnergy;
    }



}
