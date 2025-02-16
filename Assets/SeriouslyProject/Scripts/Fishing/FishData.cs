using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "ScriptableObjects/Fishes")]
public class FishData : ScriptableObject
{
    public Sprite _sprite;
    public int _speed;
}
