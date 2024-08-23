using UnityEngine;

public class HoodMovement : MonoBehaviour, IService
{
    [SerializeField] private float _progress = 0;
    [SerializeField] private float _speedOfProgress;
    [SerializeField] private float _tabForce = 10f;

    private Rigidbody2D rb;
    private bool progressIsGo;
    private bool buttonIsDown;

    public bool fishInTrigger = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FihingMovement();
    }

    private void FihingMovement()
    {
        if (progressIsGo == false && _progress > 0)
        {
            _progress -= _speedOfProgress * 0.7f * Time.deltaTime;
            //Debug.Log("-= progress");
        }
        //if (buttonIsDown == true) rb.Sleep();
        if (buttonIsDown == true)
        {
            rb.AddForce(Vector2.up * _tabForce, ForceMode2D.Force);
            //Debug.Log("Hood up");
        }
        if (Input.GetMouseButtonDown(0))
        {
            buttonIsDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            buttonIsDown = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            fishInTrigger = true;
        }
        else fishInTrigger = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            fishInTrigger = false;
        }

    }

}
