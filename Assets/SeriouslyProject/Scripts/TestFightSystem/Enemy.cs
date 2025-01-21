using FightSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem.Enemy
{
    public class Enemy : Base
    {
        [SerializeField] private EnemyData enemyData;

        private void Awake()
        {
            Sprite = GetComponent<Image>();

            Inizialize();
            StartCoroutine(Blinking());
        }

        private void Inizialize()
        {
            Name = gameObject.name = enemyData._name;
            Sprite.sprite = enemyData._sprite;
            Description = enemyData._description;
            Damage = enemyData._damage;
            MaxHealth = enemyData._maxHealth;
            Health = enemyData._health;
            Priority = enemyData._priority;
        }
    }
}
