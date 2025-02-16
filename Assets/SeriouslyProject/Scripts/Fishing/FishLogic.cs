using System.Collections;
using UnityEngine;

public class FishLogic : MonoBehaviour
{
    [Header("Fish")]
    [SerializeField] private Fish fish;
    [SerializeField] private RectTransform fishTransform;
    [Header("Fishing")]
    [SerializeField] private Canvas canvas;
    [Header("MovingBorder")]
    [SerializeField] private RectTransform maxY;
    [SerializeField] private RectTransform minY;
    [Header("GetHoodProgress")]
    [SerializeField] private HoodMovement hoodMovement;

    private float randomPosition;

    public void StartFishing()
    {
        Initialization();
        StartCoroutine(MoveFishCoroutine());
    }

    private IEnumerator MoveFishCoroutine()
    {
        while (true)
        {
            SetRandomPosition();

            while (Mathf.Abs(fishTransform.position.y - randomPosition) > 0.01f)
            {
                Vector3 position = fishTransform.position;
                position.y = Mathf.Lerp(position.y, randomPosition, Time.deltaTime * fish.speed);

                position.y = Mathf.Clamp(position.y, minY.position.y, maxY.position.y);

                fishTransform.position = position;

                TryEndFishing();

                yield return null;
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void TryEndFishing()
    {
        var progress = hoodMovement.progress;

        if (progress >= 1 || progress <= 0)
        {
            canvas.gameObject.SetActive(false);
            StopAllCoroutines();
        }
    }

    private void SetRandomPosition()
    {
        float minYValue = minY.position.y;
        float maxYValue = maxY.position.y;

        randomPosition = Random.Range(minYValue, maxYValue);
    }

    private void Initialization()
    {
        canvas.gameObject.SetActive(true);
    }
}