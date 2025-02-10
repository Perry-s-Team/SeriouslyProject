using FightSystem.Character;
using FightSystem.Enemy;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static FightManager;

[SelectionBase]
public class ContextMenu : MonoBehaviour
{
    [SerializeField] private FightManager fightManager;
    [SerializeField] private ContextText contextText;

    private RectTransform contextMenu;
    [SerializeField] private List<Button> buttons = new();
    private List<TextMeshProUGUI> buttonTexts = new();

    private Character character;
    public Enemy Enemy { get; set; }

    private bool isEnemySelection = false;
    private void Start()
    {
        contextMenu = GetComponent<RectTransform>();
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

    public void FightStateController()
    {
        if (character.IsTurn)
        {
            // ����� ��������� ������ ����� ������� IsTurn �� false
            switch (fightManager.CurrentStateFight)
            {
                case StateFight.None:
                    Debug.Log("None");
                    break;

                case StateFight.Attack:
                    Debug.Log("Attack");
                    Attack();
                    break;

                case StateFight.Heal:
                    Debug.Log("Heal");
                    Heal();
                    break;

                case StateFight.MagicAttack:
                    Debug.Log("MagicAttack");
                    MagicAttack();
                    break;
            }
        }
    }

    public void SetStateAttack()
    {
        fightManager.CurrentStateFight = StateFight.Attack;
    }

    public void SetStateMagicAttack()
    {
        fightManager.CurrentStateFight = StateFight.MagicAttack;
    }

    public void SetStateHeal()
    {
        fightManager.CurrentStateFight = StateFight.Heal;
    }

    private void Attack()
    {
        if (Enemy == null)
        {
            //contextText.ChangeContext("�hoose an enemy to attack", 2f);
            return;
        }
        else
        {
            fightManager.StopEnemyBlinking();
            Enemy.TakeDamage(character.GiveDamage());
            character.IsTurn = false;
            Enemy = null;
        }
    }

    private void Heal()
    {
        Character CharacterToHeal = fightManager.GetCharacterLowestHP();

        Debug.Log("CharacterToHeal " + CharacterToHeal.Name + " " + character.GiveHeal());
        CharacterToHeal.TakeHeal(character.GiveHeal());
        Debug.Log(CharacterToHeal.Name + " " + CharacterToHeal.Health);
        character.IsTurn = false;
    }

    private void MagicAttack()
    {
        if (Enemy == null)
        {
            //contextText.ChangeContext("�hoose an enemy to attack", 2f);
            return;
        }
        else
        {
            fightManager.StopEnemyBlinking();
            Enemy.TakeMagicDamage(character.GiveDamage());
            character.IsTurn = false;
            Enemy = null;
        }
    }

    public void RunOutFight()
    {
        int totalCharacterPriority = fightManager.characters.Sum(character => character.Priority);
        int totalEnemyPriority = fightManager.enemies.Sum(enemy => enemy.Priority);

        if (totalCharacterPriority > totalEnemyPriority)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(--currentScene);
        }
        else if (totalEnemyPriority > totalCharacterPriority)
        {
            character.IsTurn = false;
        }
    }

}