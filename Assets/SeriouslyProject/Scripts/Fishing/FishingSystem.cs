using System.Collections.Generic;
using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    [SerializeField] private HoodMovement fishingHood;
    [SerializeField] private FishLogic fishLogic;
    [SerializeField] private Fish fish;
    private FishingPlace fishingPlace;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FishingPlace _fishingPlace))
        {
            fishingPlace = _fishingPlace;

            StartFishing();
        }
    }

    public void TryGetRandomFish()
    {
        var fishes = fishingPlace.fishes;

        if (fishLogic.IsFishingWin)
        {
            Debug.Log($"Вы поймали рыбу: {fishes[GetRandomFish(fishes)].name}");
            fishLogic.IsFishingWin = false;
            fishingPlace = null;
        }
        else if (fishLogic.IsFishingLose)
        {
            Debug.Log("Вы не поймали рыбу");
            fishLogic.IsFishingLose = false;
            fishingPlace = null;
        }
    }

    public void StartFishing()
    {
        ResetFishingState();
        fishLogic.StartFishing();
        fish.Initialization();
        fishingHood.StartFishing();
    }

    private int GetRandomFish(List<ScriptableObject> _fishes)
    {
        return Random.Range(0, _fishes.Count);
    }

    public void ResetFishingState()
    {
        fishLogic.IsFishingWin = false;
        fishLogic.IsFishingLose = false;
    }
}
