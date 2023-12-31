using System.Collections;
using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI atkText;
    [SerializeField] private TextMeshProUGUI defText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI criticalText;

    private PlayerSO playerData;

    private void OnEnable()
    {
        StartCoroutine(UpdateStatusUI());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateStatusUI()
    {
        while (true)
        {
            yield return null;

            PlayerStatHandler playerStatHandler = FindObjectOfType<PlayerStatHandler>();

            if (playerStatHandler != null)
            {
                playerData = playerStatHandler.playerData;

                if (playerData != null)
                {
                    SetStatusValues(playerData);
                }
            }
        }
    }

    public void SetStatusValues(PlayerSO playerData)
    {
        atkText.text = playerData.atkValue.ToString();
        defText.text = playerData.defValue.ToString();
        healthText.text = playerData.health.ToString();
        criticalText.text = (playerData.criticalValue * 10.0f).ToString("F1") + "%";
    }
}
