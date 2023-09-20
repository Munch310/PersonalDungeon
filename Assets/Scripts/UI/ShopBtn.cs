using UnityEngine;
using UnityEngine.UI;

public class ShopBtn : MonoBehaviour
{
    public Button shopButton;

    private void Start()
    {
        shopButton.onClick.AddListener(HandleshopButtonClick);
    }

    private void HandleshopButtonClick()
    {
        // StatusBtn 클릭 시 실행할 동작을 여기에 구현합니다.
        // 예: 스탯 창을 열거나 닫거나 다른 UI 동작 수행
        Debug.Log("Shop Button Clicked!");
    }

    private void OnDestroy()
    {
        shopButton.onClick.RemoveListener(HandleshopButtonClick);
    }
}
