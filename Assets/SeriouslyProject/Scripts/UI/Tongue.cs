using UnityEngine;
using UnityEngine.UI;

public class Tongue : MonoBehaviour
{
    [SerializeField] private GameObject objectToOpen;

    public int index;

    private bool isSelected = false;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected == value) return;

            isSelected = value;
            objectToOpen.SetActive(isSelected);
        }
    }

    public void Init(System.Action<int> onClickCallback)
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => onClickCallback(index));
    }

    public void PlaySelectAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Pressed");
    }
}
