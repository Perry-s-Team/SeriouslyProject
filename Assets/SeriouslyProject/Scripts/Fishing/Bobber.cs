using System.Collections.Generic;
using UnityEngine;

public class Bobber : MonoBehaviour
{
    [SerializeField] private FishingSystem fishingSystem;

    [HideInInspector] public FishingPlace fishingPlace;
    [HideInInspector] public List<FishData> fishes;
    [HideInInspector] public FishData randomFishes;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fishingSystem = GetComponentInParent<FishingSystem>();

        if (collision.gameObject.TryGetComponent(out FishingPlace _fishingPlace))
        {
            fishes = _fishingPlace.fishes;

            randomFishes = GetRandomFish(fishes);

            //Debug.Log(randomFishes.name);
            //Debug.Log(randomFishes._sprite);
            //Debug.Log(randomFishes._speed);
            fishingSystem.StartFishing();
        }
    }

    private FishData GetRandomFish(List<FishData> _fishes)
    {
        int rndFish = Random.Range(0, _fishes.Count);
        return _fishes[rndFish];
    }
}
