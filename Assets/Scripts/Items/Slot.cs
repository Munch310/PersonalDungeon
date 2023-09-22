using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public ItemProperty item;

    [SerializeField] private Image image;
    [SerializeField] private Button sellBtn;

    private InventoryUI inventoryUI;

    private void Awake()
    {
        SetSellBtnInteractable(false);
        inventoryUI = GetComponentInParent<InventoryUI>();

        if (sellBtn != null)
        {
            sellBtn.onClick.AddListener(OnClickSellBtn);
        }
    }

    void SetSellBtnInteractable(bool b)
    {
        if (sellBtn != null)
        {
            sellBtn.interactable = b;
        }
    }

    public void SetItem(ItemProperty item)
    {
        this.item = item;

        if (item == null)
        {
            image.enabled = false;
            SetSellBtnInteractable(false);
            gameObject.name = "Empty";
        }
        else
        {
            image.enabled = true;

            gameObject.name = item.name;
            image.sprite = item.sprite;
            SetSellBtnInteractable(true);
        }
    }

    public void OnClickSellBtn()
    {
        SetItem(null);
    }

    public void OnClickSlot()
    {
        if (item != null)
        {
            inventoryUI.SendSelectedItemToItemEquipUI(item);
        }
    }
}
