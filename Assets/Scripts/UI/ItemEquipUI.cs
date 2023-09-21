using System.Collections;
using System.Collections.Generic;
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
                UpdatePlayerData(); // playerData를 설정한 후 업데이트
            }
        }
    }


    // 아이템 장착 버튼을 눌렀을 때 호출되는 메서드
    public void EquipItem()
    {
        if (selectedItem != null)
        {
            // 아이템의 보너스를 플레이어 데이터에 적용
            playerData.atkValue += selectedItem.atkBonus;
            playerData.defValue += selectedItem.defBonus;
            playerData.health += selectedItem.healthBonus;
            playerData.criticalValue += selectedItem.criticalBonus;

            // 아이템 가격을 골드에서 차감
            playerData.gold -= selectedItem.gold;

            // 플레이어 데이터를 업데이트
            UpdatePlayerData();

            Debug.Log("장착된 아이템: " + selectedItem.name);
        }
        else
        {
            Debug.Log("아무 아이템도 선택되지 않았습니다.");
        }
    }

    // 다른 스크립트에서 선택한 아이템을 설정하는 메서드
    public void SetSelectedItem(ItemProperty item)
    {
        selectedItem = item;
        UpdateUI();
    }

    // UI를 업데이트하는 메서드
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
        // 플레이어 데이터를 업데이트한 후, StatusUI와 PlayerUI에 변경된 데이터를 전달하여 UI를 업데이트합니다.
        StatusUI statusUI = FindObjectOfType<StatusUI>();
        if (statusUI != null)
        {
            statusUI.SetStatusValues(playerData);
        }

        PlayerUI playerUI = FindObjectOfType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.SetPlayerInfo(playerData);
        }
    }
}
