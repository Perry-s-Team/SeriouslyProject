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

            TryGetRandomFish();
        }
    }



    private ScriptableObject TryGetRandomFish()
    {
        var fishes = fishingPlace.fishes;

        if (fishLogic.IsFishingWin)
        {
            int randomIndex = Random.Range(0, fishes.Count);
            Debug.Log($"Вы поймали рыбу: {fishes[randomIndex].name}");
            return fishes[randomIndex];
        }
        else if (fishLogic.IsFishingLose)
        {
            Debug.Log("Not Cath Fish");
            return null;
        }
        else return null;
    }

    public void StartFishing()
    {
        fishLogic.StartFishing();
        fish.Initialization();
        fishingHood.StartFishing();
    }
}
