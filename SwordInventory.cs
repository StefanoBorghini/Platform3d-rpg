using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Inventory System/Items/Sword")]

public class SwordInventory : InventoryItem
{
    [SerializeField] private int attackPoints;
   

    public override void AssignItemToPlayer(PlayerEquipmentController playerEquipment)
    {
        playerEquipment.AssignSwordItem(this);
        AddAttackPoints();
        
    }

    private void AddAttackPoints()
    {
        var playerAttack = GameObject.Find("Player").GetComponent<Stats>();

        playerAttack.IncreaseWeaponPointsAttack(attackPoints);
       
    }
}
