using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerDesciotion;
    [SerializeField] private TextMeshProUGUI playerGold;

    private PlayerSO playerData;

    private void Awake()
    {
        PlayerStatHandler playerStatHandler = FindObjectOfType<PlayerStatHandler>();

        if (playerStatHandler != null)
        {
            playerData = playerStatHandler.playerData;

            if (playerData != null)
            {
                SetPlayerInfo(playerData);
            }
        }
    }

    public void SetPlayerInfo(PlayerSO playerData)
    {
        playerName.text = playerData.playerName.ToString();
        playerDesciotion.text = playerData.playerDescription.ToString();
        int gold = playerData.gold;
        string formattedGold = gold.ToString("N0"); // 숫자를 세 자리마다 쉼표로 구분하여 포맷
        playerGold.text = formattedGold;
    }
}
