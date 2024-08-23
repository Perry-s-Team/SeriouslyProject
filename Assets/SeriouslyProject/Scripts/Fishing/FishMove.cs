using UnityEngine;
using UnityEngine.UI;

public class FishMove: MonoBehaviour
{
    [SerializeField] private float _minHeight/* = -1f*/;
    [SerializeField] private float _maxHeight/* = 1f*/;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private RectTransform _hoodMovement;

    private float targetY;

    private void Awake()
    {
        targetY = Random.Range(_minHeight, _maxHeight);
        _hoodMovement = GetComponent<RectTransform>();

        HeightSize();
    }

    private void HeightSize()
    {
        float minSizeDelta = -_hoodMovement.localScale.y;
        Debug.Log(minSizeDelta);
        float maxSizeDelta = _hoodMovement.localScale.y;
        Debug.Log(maxSizeDelta);

        _minHeight = (minSizeDelta / 10) / 2.5f;
        Debug.Log(_minHeight);
        _maxHeight = (maxSizeDelta / 10) / 2.5f;
        Debug.Log(_maxHeight);
    }

    private void Update()
    {
        FishRandomAxis();
    }

    private void FishRandomAxis()
    {
        Vector3 position = transform.position;
        position.y = Mathf.MoveTowards(position.y, targetY, _speed * Time.deltaTime);
        transform.position = position;

        if (Mathf.Abs(position.y - targetY) < 0.01f)
        {
            targetY = Random.Range(_minHeight, _maxHeight);
        }
    }

}
