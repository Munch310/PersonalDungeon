using System;
using UnityEngine;

public class ManagementUIHandler : MonoBehaviour
{
    public static ManagementUIHandler instance;

    public event Action OnStatusBtnClicked;
    public event Action OnInventoryBtnClicked;
    public event Action OnShopBtnClicked;

    private void Awake()
    {
        instance = this;
    }

    public void HandleStatusBtnClick()
    {
        OnStatusBtnClicked?.Invoke();
    }

    public void HandleInventoryBtnClick()
    {
        OnInventoryBtnClicked?.Invoke();
    }

    public void HandleShopBtnClick()
    {
        OnShopBtnClicked?.Invoke();
    }
}
