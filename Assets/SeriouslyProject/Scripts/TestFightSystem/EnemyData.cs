using UnityEngine;

namespace FightSystem.Data
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "ScriptableObjects/TestEnemy")]
    public class EnemyData : ScriptableObject
    {
        public string _name;
        public string _description;

        public Sprite _sprite;

        public int _damage;
        public int _priority;
        public int _health;
        public int _maxHealth;
        public int _heal;
    }
}
