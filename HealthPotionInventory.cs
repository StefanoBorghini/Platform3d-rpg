using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Items/Health Potion")]

public class HealthPotionInventory : InventoryItem
{
    [SerializeField] private int healthPoints;
    private int newHealthPoints;


    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        var playerHealth = GameObject.Find("Player").GetComponent<Health>();

        if(playerHealth.CurrentHealth == playerHealth.maxHealth)
        {
            return;
        }


        playerEquipment.AssignHealthPotionItem(this);
        RestoreHim();

    }

  

    public void RestoreHim()
    {   
             

              var playerHealth = GameObject.Find("Player").GetComponent<Health>();

            
                   playerHealth.Restore(healthPoints, newHealthPoints); 
        
    }

   


    public int GetHealthPoints()
    {
        return healthPoints;
    }
}
