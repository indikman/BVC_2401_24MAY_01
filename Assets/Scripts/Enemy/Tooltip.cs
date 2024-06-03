using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text toolTipText;

    public void SetTooltipText(string text)
    {
        toolTipText.SetText(text);
    }
}
