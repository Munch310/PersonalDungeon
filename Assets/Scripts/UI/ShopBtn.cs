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
        // StatusBtn Ŭ�� �� ������ ������ ���⿡ �����մϴ�.
        // ��: ���� â�� ���ų� �ݰų� �ٸ� UI ���� ����
        Debug.Log("Shop Button Clicked!");
    }

    private void OnDestroy()
    {
        shopButton.onClick.RemoveListener(HandleshopButtonClick);
    }
}
