using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private static int currentEnergy, currentHealth;
    private static int totalEnergy, totalHealth;
    private static int batteries, healthPacks;
    private bool hasGun;
    private bool hasJet;
    private string[] inventoryProper = new string[20]; //arbitrarily 20
    private int inventoryIndex; //used to keep track of the index of the inventory

    public GameObject SpawnPoint;
    public EnergyBarLogic energyBar;
    public HealthBarLogic healthBar;

    public void Start()
    {
        //SpawnPoint = GetComponent<Transform>();
        // Coldboy = GetComponent<Transform>();
        hasGun = false;
        hasJet = false;
        totalEnergy = 100;
        currentEnergy = totalEnergy;
        totalHealth = 4;
        currentHealth = totalHealth;
        batteries = 0;
        healthPacks = 0;
    }

    public void addToInventory(string s)
    {
        inventoryProper[inventoryIndex] = s;
        inventoryIndex++;
    }

    public bool checkInvetoryFor(string s)
    {
        for(int i = 0; i < inventoryProper.Length; i++)
        {
            if (s.Equals(inventoryProper[i]))
            {
                return true;
            }
        }
        return false;
    }

    private void Die()
    {
        Debug.Log("Killed! TE = " + totalEnergy + " TH = " + totalHealth);
        this.transform.position = new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, 1f);
        currentHealth = totalHealth;
        currentEnergy = totalEnergy;
        energyBar.reset();
        healthBar.reset();
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
        healthBar.useHealth();
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
        energyBar.useEnergy();
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

    public bool checkGun()
    {
        return hasGun;
    } 

    public bool checkJet()
    {
        return hasJet;
    }

    public void gunCollect()
    {
        hasGun = true;
    }

    public void jetCollect()
    {
        hasJet = true;
    }
}
