using FightSystem.Data;
using UnityEngine;
using UnityEngine.UI;

namespace FightSystem.Character
{
    public class Character : Base
    {
        [SerializeField] private CharacterData characterData;

        private void Awake()
        {   
            Sprite = GetComponent<Image>();

            Inizialize();
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



    }
}
