using FightSystem.Character;
using FightSystem.Enemy;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static FightManager;

[SelectionBase]
public class ContextMenu : MonoBehaviour
{
    [SerializeField] private FightManager fightManager;

    [SerializeField] private RectTransform contextMenu;
    [SerializeField] private List<Button> buttons = new();
    private List<TextMeshProUGUI> buttonTexts = new();

    private Character character;
    private Enemy enemy;

    private void Start()
    {
        SetButtonName();
    }

    private void SetButtonName()
    {
        buttons.AddRange(GetComponentsInChildren<Button>());
        buttonTexts.AddRange(GetComponentsInChildren<TextMeshProUGUI>());

        for (int i = 0; i < buttons.Count && i < buttonTexts.Count; i++)
        {
            if (buttons[i] != null && buttonTexts[i] != null)
            {
                buttons[i].name = buttonTexts[i].text;
            }
        }
    }

    public void ChangePosition(Transform _newParent)
    {
        contextMenu.SetParent(_newParent);
        contextMenu.localPosition = Vector3.zero;

        SetCharacter();

        fightManager.CurrentStateFight = StateFight.None;
    }

    public void SetCharacter()
    {
         character = GetComponentInParent<Character>();
    }

    public void SetEnemy()
    {
        enemy = GetComponent<Enemy>();
        Debug.Log(enemy.Name);
    }

    public void FightStateController()
    {
        if (!character.IsTurn)
            return;

        switch (fightManager.CurrentStateFight)
        {
            case StateFight.None:
                Debug.Log("None");
                break;

            case StateFight.Attack:
                Debug.Log("Attack");
                
                break;

            case StateFight.Defence:
                Debug.Log("Defence");
                break;

            case StateFight.Heal:
                Debug.Log("Heal");
                break;
        }
    }

    public void SetStateAttack()
    {
        fightManager.CurrentStateFight = StateFight.Attack;
    }

    public void SetStateDefence()
    {
        fightManager.CurrentStateFight = StateFight.Defence;
    }

    public void SetStateHeal()
    {
        fightManager.CurrentStateFight = StateFight.Heal;
    }
}