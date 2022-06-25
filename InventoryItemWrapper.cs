using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class InventoryItemWrapper
{
   public InventoryItem item;
    [SerializeField] public int count;

    public InventoryItem GetItem()
    {
        return item;
        
    }

    public int GetItemCount()
    {
        return count;
    }

    
}
