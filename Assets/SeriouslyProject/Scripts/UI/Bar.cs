using FightSystem.Character;
using FightSystem.Enemy;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public Image imageToHealth;
    public Image imageToMana;

    internal Character character;
    internal Enemy enemy;

    internal void GetCharacterComponent()
    {
        character = GetComponentInParent<Character>();
    }

    internal void GetEnemyComponent()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    internal void GetImageHealthComponent()
    {
        imageToHealth = GetComponentInChildren<Image>();
    }

    internal void GetImageManaComponent()
    {
        imageToMana = GetComponentInChildren<Image>();
    }
}