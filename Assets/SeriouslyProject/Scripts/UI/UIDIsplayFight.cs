using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDIsplayFight : MonoBehaviour
{
    [SerializeField] private UIFightData uiFight;
    [SerializeField] private Button[] button;
    [SerializeField] private TextMeshProUGUI[] buttonTMProTextUGUI;

    private void Awake()
    {
        for (int i = 0; i < button.Length; i++)
        {
            button[i].name = uiFight._button[i];
        }

        for (int i = 0; i < buttonTMProTextUGUI.Length; i++)
        {
            buttonTMProTextUGUI[i].text = uiFight._firstString[i];
            buttonTMProTextUGUI[i].name = uiFight._firstString[i];
        }
    }
}
