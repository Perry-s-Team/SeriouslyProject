using System.Collections.Generic;
using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    [Header("Fishing")]
    [SerializeField] private HoodMovement fishingHood;
    [SerializeField] private FishLogic fishLogic;
    [SerializeField] private TestPlayer player;
    [SerializeField] private Fish fish;

    [Header("Bobber")]
    [SerializeField] private GameObject bobberObject;
    [SerializeField] private Bobber bobber;

    private void Update()
    {
        if (Input.GetKeyDown(player.keyCode))
        {
            GameObject newBobber = Instantiate(bobberObject, transform);
            bobber = newBobber.GetComponent<Bobber>();
        }
    }

    public void TryGetRandomFish()
    {
        if (fishLogic.IsFishingWin)
        {
            Debug.Log($"Вы поймали рыбу: {bobber.randomFishes.name}");
            fishLogic.IsFishingWin = false;
            bobber.fishingPlace = null;
        }
        else if (fishLogic.IsFishingLose)
        {
            Debug.Log("Вы не поймали рыбу");
            fishLogic.IsFishingLose = false;
            bobber.fishingPlace = null;
        }
    }

    public void StartFishing()
    {
        ResetFishingState();
        fishLogic.StartFishing();
        fish.Initialization(bobber.randomFishes);
        fishingHood.StartFishing();
    }

    public void ResetFishingState()
    {
        fishLogic.IsFishingWin = false;
        fishLogic.IsFishingLose = false;
    }
}
