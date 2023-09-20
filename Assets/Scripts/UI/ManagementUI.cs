using UnityEngine;
using UnityEngine.UI;

public class ManagementUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject StatusUI;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private GameObject ShopUI;

    [Header("Buttons")]
    [SerializeField] private GameObject StatusBtn;
    [SerializeField] private GameObject InventoryBtn;
    [SerializeField] private GameObject ShopBtn;

    private void Start()
    {
        if (ManagementUIHandler.instance != null)
        {
            ManagementUIHandler.instance.OnStatusBtnClicked += HandleStatusBtnClick;
            ManagementUIHandler.instance.OnInventoryBtnClicked += HandleInventoryBtnClick;
            ManagementUIHandler.instance.OnShopBtnClicked += HandleShopBtnClick;
        }
        else
        {
            Debug.LogError("ManagementUIHandler가 null입니다.");
        }
    }

    private void HandleStatusBtnClick()
    {
        if(UIManager.instance != null)
        {
            UIManager.instance.SetGameObjectActive(StatusUI, true);
            UIManager.instance.SetGameObjectActive(StatusBtn, false);
            UIManager.instance.SetGameObjectActive(InventoryBtn, false);
            UIManager.instance.SetGameObjectActive(ShopBtn, false);
        }
    }

    private void HandleInventoryBtnClick()
    {
        if(UIManager.instance != null)
        {
            UIManager.instance.SetGameObjectActive(InventoryUI, true);
            UIManager.instance.SetGameObjectActive(StatusBtn, false);
            UIManager.instance.SetGameObjectActive(InventoryBtn, false);
            UIManager.instance.SetGameObjectActive(ShopBtn, false);
        }
    }

    private void HandleShopBtnClick()
    {
        Debug.Log("Shop Button Clicked!");
    }

    private void OnDestroy()
    {
        ManagementUIHandler.instance.OnStatusBtnClicked -= HandleStatusBtnClick;
        ManagementUIHandler.instance.OnInventoryBtnClicked -= HandleInventoryBtnClick;
        ManagementUIHandler.instance.OnShopBtnClicked -= HandleShopBtnClick;
    }
}
