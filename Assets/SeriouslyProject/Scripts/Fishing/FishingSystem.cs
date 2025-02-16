using UnityEngine;

public class FishingSystem : MonoBehaviour
{
    [SerializeField] private HoodMovement fishingHood;
    [SerializeField] private FishLogic fishLogic;
    [SerializeField] private Fish fish;

    private void Start()
    {
        fish.Initialization();
        fishingHood.StartFishing();
        fishLogic.StartFishing();
    }
}
