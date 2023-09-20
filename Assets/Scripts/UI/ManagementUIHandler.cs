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
        Debug.Log("감지 완료! 이제 ManagementUI.cs로 넘어갑니다!");
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
