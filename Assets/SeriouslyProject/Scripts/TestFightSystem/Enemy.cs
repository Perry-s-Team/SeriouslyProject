using FightSystem.Data;
using UnityEditor.U2D.Animation;
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
            MaxMana = enemyData._maxMana;
            Mana = enemyData._mana;
            Heal = enemyData._heal;
            Priority = enemyData._priority;

            healthText.text = Health.ToString() + " /" + MaxHealth;
            manaText.text = Mana.ToString() + " /" + MaxMana;
            healthBar.minValue = 0;
            healthBar.maxValue = MaxHealth;
            healthBar.value = Health;

            SetGradient(1f);
        }

        private void SetComponent()
        {
            contextMenu.Enemy = GetComponent<Enemy>();
        }
    }
}
