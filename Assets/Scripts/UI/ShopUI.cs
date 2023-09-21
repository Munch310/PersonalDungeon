using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public ItemBuffer itemBuffer;
    public Transform slotRoot;

    private List<Slot> Slots;

    public Action<ItemProperty> OnSlotClick;

    void Start()
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
        // 구매 팝업 창 띄우기.(가격, 정보, 효과)
        if(OnSlotClick != null)
        {
            OnSlotClick(slot.item);
        }
    }
}
