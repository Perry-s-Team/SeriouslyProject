using UnityEngine;
using UnityEngine.UI;

public class FishMove: MonoBehaviour
{
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _speed = 2f;

    private int screenHeight;   
    private float targetY;

    private void Awake()
    {
        screenHeight = Screen.height;
        ScreenHeightValue();

        targetY = Random.Range(_minHeight, _maxHeight);
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

    private void ScreenHeightValue()
    {
        switch (screenHeight)
        {
            case 768:
                _minHeight = -0.9f;
                _maxHeight = 0.9f;
                break;
            case 1024:
                _minHeight = -0.7f;
                _maxHeight = 0.7f;
                break;
            case 1080:
                _minHeight = -0.7f;
                _maxHeight = 0.7f;
                break;
            case 1440:
                _minHeight = -0.5f;
                _maxHeight = 0.5f;
                break;
            case 2160:
                _minHeight = -0.35f;
                _maxHeight = 0.35f;
                break;

            //Phone
            case 1920:
                break;

        }
    }
}
