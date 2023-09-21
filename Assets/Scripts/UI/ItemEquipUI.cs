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
                UpdatePlayerData(); // playerData�� ������ �� ������Ʈ
            }
        }
    }


    // ������ ���� ��ư�� ������ �� ȣ��Ǵ� �޼���
    public void EquipItem()
    {
        if (selectedItem != null)
        {
            // �������� ���ʽ��� �÷��̾� �����Ϳ� ����
            playerData.atkValue += selectedItem.atkBonus;
            playerData.defValue += selectedItem.defBonus;
            playerData.health += selectedItem.healthBonus;
            playerData.criticalValue += selectedItem.criticalBonus;

            // ������ ������ ��忡�� ����
            playerData.gold -= selectedItem.gold;

            // �÷��̾� �����͸� ������Ʈ
            UpdatePlayerData();

            Debug.Log("������ ������: " + selectedItem.name);
        }
        else
        {
            Debug.Log("�ƹ� �����۵� ���õ��� �ʾҽ��ϴ�.");
        }
    }

    // �ٸ� ��ũ��Ʈ���� ������ �������� �����ϴ� �޼���
    public void SetSelectedItem(ItemProperty item)
    {
        selectedItem = item;
        UpdateUI();
    }

    // UI�� ������Ʈ�ϴ� �޼���
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
        // �÷��̾� �����͸� ������Ʈ�� ��, StatusUI�� PlayerUI�� ����� �����͸� �����Ͽ� UI�� ������Ʈ�մϴ�.
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
