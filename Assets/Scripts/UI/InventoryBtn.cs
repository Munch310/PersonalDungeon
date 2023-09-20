using UnityEngine;
using UnityEngine.UI;

public class InventoryBtn : MonoBehaviour
{
    public Button InventoryButton;

    private void Start()
    {
        InventoryButton.onClick.AddListener(HandleInventoryButtonClick);
    }

    private void HandleInventoryButtonClick()
    {
        // StatusBtn Ŭ�� �� ������ ������ ���⿡ �����մϴ�.
        // ��: ���� â�� ���ų� �ݰų� �ٸ� UI ���� ����
        Debug.Log("Inventory Button Clicked!");
    }

    private void OnDestroy()
    {
        InventoryButton.onClick.RemoveListener(HandleInventoryButtonClick);
    }
}
