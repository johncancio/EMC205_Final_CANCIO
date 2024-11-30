using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;

    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipText.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false);
    }
}
