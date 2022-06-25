using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour  // monobehaviour che chiama a sè l'inventory(scr.obj) e instanzia gli oggetti
{
    [SerializeField] public Inventory inventory;
    [SerializeField] private Transform inventoryUIParent;

    [Header("Anchors")]

    [SerializeField] private Transform swordAnchor;
    [SerializeField] private Transform shieldAnchor;

    private GameObject currentSwordObj;
    private GameObject currentShieldObj;
   
    private int playerHealth = 0;
    private int playerStamina = 0;

    private InventoryItem inventoryItem;


    public void Start()
    {
        inventory.InitInventory(this);
        inventory.OpenInventory();
    }


    public void AssignSwordItem(SwordInventory item)
    {
        DestroyIfNotNull(currentSwordObj);
        currentSwordObj = CreateNewitemInstance(item, swordAnchor);
     
    }


    public void AssignShieldItem(ShieldInventory item)
    {
        DestroyIfNotNull(currentShieldObj);
        currentShieldObj = CreateNewitemInstance(item, shieldAnchor);
    
    }


    public void AssignHealthPotionItem(HealthPotionInventory item)
    {   
        inventory.RemoveItem(item, 1);
        playerHealth += item.GetHealthPoints();
       
    }

    public void AssignStaminaPotionItem(StaminaPotionInventory item)
    {   
        inventory.RemoveItem(item, 1);
        playerStamina += item.GetStaminaPoints();
       
    }


    private GameObject CreateNewitemInstance(InventoryItem item, Transform anchor)
    {
        var itemInstance = Instantiate(item.GetPrefab(), anchor);
        itemInstance.transform.localPosition = item.GetLocalPosition();
        itemInstance.transform.localRotation = item.GetLocalRotation();
        return itemInstance;
        
    }

  

    private void DestroyIfNotNull(GameObject obj)
    {
        if(obj)
        {
            Destroy(obj);
        }
    }

    public Transform GetUIParent()
    {
        return inventoryUIParent;
    }
    
}
