using System;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance;

    public event Action OnStatusBtnClicked;
    public event Action OnInventoryBtnClicked;
    public event Action OnShopBtnClicked;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
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
