using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBarLogic : MonoBehaviour
{
    public Sprite[] energyPossibilities = new Sprite[11];
    public Inventory player;
    private int currentEnergy = 100;
    public SpriteRenderer energyBar;

    public void Start()
    {
        energyBar = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void useEnergy()
    {
        currentEnergy = player.getEnergy();
        int temp = currentEnergy / 10;
        energyBar.sprite = energyPossibilities[temp];
    }

    public void reset()
    {
        currentEnergy = 100;
        int temp = currentEnergy / 10;
        energyBar.sprite = energyPossibilities[temp];
    }
}
