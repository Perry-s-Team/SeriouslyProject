using System.Collections.Generic;
using FightSystem.Character;
using System.Collections;
using FightSystem.Enemy;
using UnityEngine;
using System.Linq;
using TMPro;

public class FightManager : MonoBehaviour
{
    public StateFight CurrentStateFight = StateFight.None;

    [SerializeField] private TextMeshProUGUI fightTurn;
    [SerializeField] private ContextMenu contextMenu;

    [SerializeField] private List<Enemy> enemies = new();
    public List<Character> characters = new();

    [SerializeField] private List<Base> bases = new();

    private void Start()
    {
        InitializationLists();

        StartCoroutine(StartFight());
    }

    private IEnumerator StartFight()
    {
        for (int i = 0; i < bases.Count; i++)
        {
            Debug.Log($"{bases[i].Name} {bases[i].Health}");

            if (bases[i] is Enemy enemy && enemy.Health > 0)
            {
                GetCharacterLowestHP().TakeDamage(enemy.Damage);

                Debug.Log($"{GetCharacterLowestHP().Name} After Damage {GetCharacterLowestHP().Health}");

                DeleteCharacterOnList(GetCharacterLowestHP());
            }
            else if (bases[i] is Character character && character.Health > 0)
            {
                Debug.Log($"{character.Name} character.isTurn {character.IsTurn}");

                yield return StartCoroutine(WaitCharacterTurn(character));
            }
        }
        yield return StartCoroutine(EndFight());
    }

    private IEnumerator EndFight()
    {
        if (characters.All(c => c.Health > 0) && enemies.All(e => e.Health == 0))
        {
            Debug.Log("You are WiN!");
        }
        else if (enemies.All(e => e.Health > 0) && characters.All(c => c.Health == 0))
        {
            Debug.Log("You are LOSE!");
        }
        else if (enemies.All(e => e.Health > 0) && characters.All(c => c.Health > 0))
        {
            yield return StartCoroutine(StartFight());
        }
    }

    private void ContinueFight()
    {

    }

    private void InitializationLists()
    {
        enemies.AddRange(GetComponentsInChildren<Enemy>());
        characters.AddRange(GetComponentsInChildren<Character>());

        enemies = enemies.OrderByDescending(enemy => enemy.Priority).ToList();
        characters = characters.OrderByDescending(character => character.Priority).ToList();

        bases = enemies
            .Cast<Base>()
            .Concat(characters.Cast<Base>())
            .OrderByDescending(item => item.Priority)
            .ToList();
    }

    private IEnumerator WaitCharacterTurn(Character _character)
    {
        _character.IsTurn = true;
        while (_character.IsTurn)
        {
            StartEnemyBlinking();//�������� �� bool Enemy
            yield return null;
        }
    }
    public Character GetCharacterLowestHP()
    {
        return characters.OrderBy(character => character.Health).FirstOrDefault(); ;
    }

    private Enemy GetEnemyHighestPriority()
    {
        return enemies.OrderByDescending(enemy => enemy.Priority).FirstOrDefault();
    }

    public void StopEnemyBlinking()
    {
        enemies.ForEach(enemy => enemy.IsBlinking = false);
    }

    public void StartEnemyBlinking()
    {
        enemies.ForEach(enemy => enemy.IsBlinking = true);
    }

    private void DeleteCharacterOnList(Character character)
    {
        if (character.Health <= 0)
        {
            bases.Remove(character);
            characters.Remove(character);
        }
    }

    public enum StateFight
    {
        None,
        Attack,
        Heal
    }
}