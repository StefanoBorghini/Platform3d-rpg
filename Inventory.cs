using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Scriptable Objects/Inventory System/Inventory")]



public class Inventory : ScriptableObject
{
    // pickup item

    public static Inventory inventory;

   [SerializeField] private InventoryUI inventoryUIPrefab;



   private InventoryUI _inventoryUI;
   private InventoryUI inventoryUI
   {
       get
       {
           if(!_inventoryUI)
           {
               _inventoryUI = Instantiate(inventoryUIPrefab, playerEquipment.GetUIParent());
           }
           return _inventoryUI;
       }
   }



    public Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();
    public List<InventoryItemWrapper> items = new List<InventoryItemWrapper>(); // pickup item here
    private PlayerEquipmentController playerEquipment;

  
    
  
    // Partire da qui per aggiungere item alla lista

    

   public void InitInventory(PlayerEquipmentController playerEquipment)
   {    
      
       this.playerEquipment = playerEquipment;
       for(int i = 0; i < items.Count; i++)
       {
           itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
            
       }
   }


 
   public void OpenInventory()
   {
       inventoryUI.gameObject.SetActive(true);
       inventoryUI.InitInventoryUI(this);
   }

   public void AssignItem(InventoryItem item)
   {

       item.AssignItemToPlayer(playerEquipment);
       
       
   }

   public Dictionary<InventoryItem, int> GetAllItemsMap()
   {
       return itemToCountMap;
  
   }

 

   public void RemoveItem(InventoryItem item, int count)
   {
       int currentItemCount;
       
       if(itemToCountMap.TryGetValue(item, out currentItemCount))
       {
           itemToCountMap[item] = currentItemCount - count;

           if(currentItemCount - count <= 0)
           {
               inventoryUI.DestroySlot(item);
           }
           else
           {
               inventoryUI.UpdateSlot(item, currentItemCount - count);
           }
       }
      
   }

}
