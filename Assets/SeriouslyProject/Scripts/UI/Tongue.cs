using UnityEngine;
using UnityEngine.UI;

public class Tongue : MonoBehaviour
{
    [SerializeField] private GameObject objectToOpen;

    public int index;

    private bool isSelected = false;
    private Animator animator;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (isSelected == value) return;

            isSelected = value;
            objectToOpen.SetActive(isSelected);

            if (isSelected)
                PlaySelectAnimation();
            else
                PlayDeselectAnimation();
        }
    }

    public void Init(System.Action<int> onClickCallback)
    {
        Button button = GetComponent<Button>();
        animator = GetComponent<Animator>();

        button.onClick.AddListener(() => onClickCallback(index));
    }

    public void PlaySelectAnimation()
    {
        animator.SetTrigger("Pressed");
    }

    public void PlayDeselectAnimation()
    {
        animator.SetTrigger("Normal");
    }
}
