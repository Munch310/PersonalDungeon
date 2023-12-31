using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("Plaer Info")]
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerDesciotion;
    [SerializeField] private TextMeshProUGUI playerLevel;
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
        playerLevel.text = "LV. " + playerData.level.ToString();
        int gold = playerData.gold;
        string formattedGold = gold.ToString("N0");
        playerGold.text = formattedGold;
    }
}
