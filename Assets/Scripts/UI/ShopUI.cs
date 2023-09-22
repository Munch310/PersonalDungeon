using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    [SerializeField] private Transform slotRoot;

    private List<Slot> Slots;

    public Action<ItemProperty> OnSlotClick;
    

    void Awake()
    {
        Slots = new List<Slot>();

        int slotCnt = slotRoot.childCount;

        for(int i = 0; i < slotCnt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if(i < itemBuffer.items.Count)
            {
                slot.SetItem(itemBuffer.items[i]);
            }
            else
            {
                slot.GetComponent<Button>().interactable = false;
            }

            Slots.Add(slot);
        }
    }

    public void OnClickSlot(Slot slot)
    {
        if(OnSlotClick != null)
        {
            OnSlotClick(slot.item);
        }
    }
}
