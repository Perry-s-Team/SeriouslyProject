using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour, IService
{
    [SerializeField] private HoodMovement _hoodMovement;
    [SerializeField] private float _fillAmount;
    [SerializeField, Range(1f, 0.001f)] private float _fillSpeed = 0.001f;

    private Image image;

    private void Awake()
    {
        Register();
        Init();
    }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (_hoodMovement.fishInTrigger == true)
        {
            FillBar();
        }
        else if (_hoodMovement.fishInTrigger == false && _fillAmount > 0)
            UnFillBar();

        WinOrLose();

    }

    private void FillBar() 
    {
        _fillAmount += _fillSpeed;
        image.fillAmount = _fillAmount;
        //Debug.Log(_fillAmount);
    }

    private void UnFillBar()
    {
        _fillAmount -= _fillSpeed;
        image.fillAmount = _fillAmount;
        //Debug.Log(_fillAmount);
    }

    private void WinOrLose()
    {
        if (_fillAmount >= 1.01f)
        {
            _fillAmount = 1f;
            _fillSpeed = 0f;
            Debug.Log("Гойда");
        }
        else if (_fillAmount <= 0f) 
        {
        _fillAmount = 0f;
        _fillSpeed = 0f;
        Debug.Log("YouAreLose");
        }
    }

    private void Register()
    {
        ServiceLocator.Initialize();
        ServiceLocator.Current.Register<HoodMovement>(_hoodMovement);
    }

    private void Init()
    {
        HoodMovement hoodMovement = ServiceLocator.Current.Get<HoodMovement>();

    }
}
