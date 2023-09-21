using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform rootSlot;
    public ShopUI shopUI;
    public ItemEquipUI itemEquipUI;

    public GameObject itemEqupUIGO;

    private List<Slot> slots;

    void Awake()
    {
        slots = new List<Slot>();

        int slotCnt = rootSlot.childCount;

        for (int i = 0; i < slotCnt; i++)
        {
            var slot = rootSlot.GetChild(i).GetComponent<Slot>();

            slots.Add(slot);
        }

        shopUI.OnSlotClick += BuyItem;
    }

    void BuyItem(ItemProperty item)
    {
        var emptySlot = slots.FirstOrDefault(t => t.item == null || t.item.name == string.Empty);

        emptySlot?.SetItem(item);
    }

    public void SendSelectedItemToItemEquipUI(ItemProperty item)
    {
        itemEquipUI.SetSelectedItem(item);
        if(UIManager.instance != null)
        {
            UIManager.instance.SetGameObjectActive(itemEqupUIGO, true);
        }
    }
}
