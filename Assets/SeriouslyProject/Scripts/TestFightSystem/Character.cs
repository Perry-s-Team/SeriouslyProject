using FightSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem.Character
{
    public class Character : Base
    {
        public bool IsTurn { get; set; } = false;

        [Header("DataCharacter")]
        [SerializeField] private CharacterData characterData;
        [Header("ContextMenu")]
        [SerializeField] private ContextMenu contextMenu;

        private Button button;

        private void Awake()
        {   
            Sprite = GetComponent<Image>();

            Inizialize();

            button = GetComponent<Button>();
            button.onClick.AddListener(SetComponent);
        }

        private void Inizialize()
        {
            Name = gameObject.name = characterData._name;
            Sprite.sprite = characterData._sprite;
            Description = characterData._description;
            Damage = characterData._damage;
            MaxHealth = characterData._maxHealth;
            Health = characterData._health;
            Mana = characterData._mana;
            Priority = characterData._priority;

            healthBar.minValue = 0;
            healthBar.maxValue = MaxHealth;
            healthBar.value = Health;

            SetGradient(1f);
        }

        private void SetComponent()
        {
            contextMenu.CharacterToHeal = GetComponent<Character>();
        }
    }
}
