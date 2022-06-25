using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// il problema sembra essere alla riga 61 di inventory e di conseguenza l'errore si trasmette alla riga 30 di inventory slot
// teniamo in considerazione la riga 10 dell'inventoryUI

public class PlayerPIckUp : MonoBehaviour // raccoglie un oggetto lo instanzia nella UI ma poi rimane inutilizzabile per il mancato callback
{
    public InventoryItem item;// guardare l'ultimo prototipo scaricato | InventorySO - PickUpSystem - Item -ItemSO
 

    public int itemCount;

    private InventoryUI inventoryUI;
    private Inventory inventory;
    private InventorySlot inventorySlot;

    private PlayerEquipmentController playerEquipment;

  //  private Sprite itemSprite; 
   // private string itemName;   
   // private Button slotButton; 

    void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
        inventory = FindObjectOfType<Inventory>();
        playerEquipment = FindObjectOfType<PlayerEquipmentController>();
        inventorySlot = FindObjectOfType<InventorySlot>();
        
     //   slotButton = FindObjectOfType<InventorySlot>().GetComponent<Button>(); 
    }

    void Update()
    {
       // itemSprite = item.GetSprite();
       // itemName = item.GetName();       
    }

    public void OnTriggerStay(Collider other)
    {
        var player = CompareTag("Player");

          if(player = true && Input.GetButtonDown("Fire2"))
        {
            
                inventoryUI.AddNewItem(inventory, item, itemCount);
               

              //  playerEquipment.Start();
              //  inventoryUI.UpdateSlot(item, itemCount);
              //  inventorySlot.UpdateSlotCount(+itemCount);
              //  impossibile passare le informazioni a Inventory Scriptable Object
         

              // trovare il modo di aggiungere item direttamente alla lista
              // partire con pickupsystem e item
                this.gameObject.SetActive(false);   
           
        }
    }


}

