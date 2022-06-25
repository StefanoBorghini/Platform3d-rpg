using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] public Image emptySlot;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemCountText;
    public Button slotButton;

    public void InitSlotVisualization(Sprite itemSprite, string itemName, int itemCount)
    {
        itemImage.sprite = itemSprite;
        itemNameText.text = itemName;
        UpdateSlotCount(itemCount);
    }

    public void UpdateSlotCount(int itemCount)
    {
        itemCountText.text = itemCount.ToString();
    }


    public void AssignSlotButtonCallBack(System.Action onClickCallBack)
    {
        slotButton.onClick.AddListener(() => onClickCallBack());
    }
}
