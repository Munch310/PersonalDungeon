using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemEquipUI : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;
    [SerializeField] private TextMeshProUGUI itemAtkBonusText;
    [SerializeField] private TextMeshProUGUI itemDefBonusText;
    [SerializeField] private TextMeshProUGUI itemHealthBonusText;
    [SerializeField] private TextMeshProUGUI itemCriticalBonusText;
    [SerializeField] private TextMeshProUGUI itemGoldText;

    private PlayerSO playerData;

    private ItemProperty selectedItem;

    private void Start()
    {
        PlayerStatHandler playerStatHandler = FindObjectOfType<PlayerStatHandler>();

        if (playerStatHandler != null)
        {
            playerData = playerStatHandler.playerData;

            if (playerData != null)
            {
                UpdatePlayerData();
            }
        }
    }

    public void EquipItem()
    {
        if (selectedItem != null)
        {
            playerData.atkValue += selectedItem.atkBonus;
            playerData.defValue += selectedItem.defBonus;
            playerData.health += selectedItem.healthBonus;
            playerData.criticalValue += selectedItem.criticalBonus;

            UpdatePlayerData();
        }
        else
        {
            Debug.Log("�ƹ� �����۵� ���õ��� �ʾҽ��ϴ�.");
        }
    }
    public void SetSelectedItem(ItemProperty item)
    {
        selectedItem = item;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (selectedItem != null)
        {
            itemImage.sprite = selectedItem.sprite;
            itemNameText.text = selectedItem.name;
            itemDescriptionText.text = selectedItem.description;
            itemAtkBonusText.text = "���ݷ� + " + selectedItem.atkBonus.ToString();
            itemDefBonusText.text = "�濩�� + " + selectedItem.defBonus.ToString();
            itemHealthBonusText.text = "ü�� + " + selectedItem.healthBonus.ToString();
            itemCriticalBonusText.text = "ġ��Ÿ + " + (selectedItem.criticalBonus * 10).ToString();
            itemGoldText.text = "���� : " + selectedItem.gold.ToString();
        }
        else
        {
            itemImage.sprite = null;
            itemNameText.text = "���õ� ������ ����";
            itemDescriptionText.text = "";
            itemAtkBonusText.text = "";
            itemDefBonusText.text = "";
            itemHealthBonusText.text = "";
            itemCriticalBonusText.text = "";
            itemGoldText.text = "";
        }
    }

    private void UpdatePlayerData()
    {
        PlayerUI playerUI = FindObjectOfType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.SetPlayerInfo(playerData);
        }
    }
}
