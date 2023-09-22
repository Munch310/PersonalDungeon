using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject statusUI;

    [Header("Buttons")]
    [SerializeField] private GameObject StatusBtn;
    [SerializeField] private GameObject InventoryBtn;
    [SerializeField] private GameObject ShopBtn;

    public void OnClickedExitBtn()
    {
        if (UIManager.instance != null)
        {
            UIManager.instance.SetGameObjectActive(statusUI, false);
            UIManager.instance.SetGameObjectActive(StatusBtn, true);
            UIManager.instance.SetGameObjectActive(InventoryBtn, true);
            UIManager.instance.SetGameObjectActive(ShopBtn, true);
        }
    }
}
