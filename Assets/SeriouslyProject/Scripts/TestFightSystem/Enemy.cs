using FightSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem.Enemy
{
    public class Enemy : Base
    {
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private ContextMenu contextMenu;

        private Button button;

        private void Awake()
        {
            Sprite = GetComponent<Image>();

            Inizialize();
            StartCoroutine(Blinking());

            button = GetComponent<Button>();
            button.onClick.AddListener(SetComponent);
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

        private void SetComponent()
        {
            contextMenu.Enemy = GetComponent<Enemy>();
        }
    }
}
