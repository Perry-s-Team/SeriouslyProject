using TMPro;
using UnityEngine;

public class ContextText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro { get; set; }

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeContext(string _text, float _waiting)
    {
        textMeshPro.text = _text;
        Invoke(nameof(ClearText), _waiting);
    }

    private void ClearText()
    {
        textMeshPro.text = null;
    }
}
