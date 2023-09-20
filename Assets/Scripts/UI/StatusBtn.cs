using UnityEngine;
using UnityEngine.UI;

public class StatusBtn : MonoBehaviour
{
    public Button statusButton;

    private void Start()
    {
        statusButton.onClick.AddListener(HandleStatusButtonClick);
    }

    private void HandleStatusButtonClick()
    {
        // StatusBtn 클릭 시 실행할 동작을 여기에 구현합니다.
        // 예: 스탯 창을 열거나 닫거나 다른 UI 동작 수행
        Debug.Log("Status Button Clicked!");
    }

    private void OnDestroy()
    {
        statusButton.onClick.RemoveListener(HandleStatusButtonClick);
    }
}
