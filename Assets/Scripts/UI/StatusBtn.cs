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
        // StatusBtn Ŭ�� �� ������ ������ ���⿡ �����մϴ�.
        // ��: ���� â�� ���ų� �ݰų� �ٸ� UI ���� ����
        Debug.Log("Status Button Clicked!");
    }

    private void OnDestroy()
    {
        statusButton.onClick.RemoveListener(HandleStatusButtonClick);
    }
}
