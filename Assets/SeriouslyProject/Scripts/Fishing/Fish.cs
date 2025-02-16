using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private FishData fishData;

    public int speed;
    public SpriteRenderer sprite;

    public void Initialization()
    {
        sprite = GetComponent<SpriteRenderer>();
        speed = fishData._speed;
        sprite.sprite = fishData._sprite;
    }
}
