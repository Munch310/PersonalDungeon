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
            Debug.Log("아무 아이템도 선택되지 않았습니다.");
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
            itemAtkBonusText.text = "공격력 + " + selectedItem.atkBonus.ToString();
            itemDefBonusText.text = "방여력 + " + selectedItem.defBonus.ToString();
            itemHealthBonusText.text = "체력 + " + selectedItem.healthBonus.ToString();
            itemCriticalBonusText.text = "치명타 + " + (selectedItem.criticalBonus * 10).ToString();
            itemGoldText.text = "가격 : " + selectedItem.gold.ToString();
        }
        else
        {
            itemImage.sprite = null;
            itemNameText.text = "선택된 아이템 없음";
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
