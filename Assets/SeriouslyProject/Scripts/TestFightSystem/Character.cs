using FightSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem.Character
{
    public class Character : Base
    {
        public bool IsTurn { get; set; } = true;

        [SerializeField] private CharacterData characterData;
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
            Priority = characterData._priority;
        }

        private void SetComponent()
        {
            contextMenu.CharacterToHeal = GetComponent<Character>();
        }
    }
}
