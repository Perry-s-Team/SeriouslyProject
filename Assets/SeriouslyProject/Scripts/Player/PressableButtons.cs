using UnityEngine;

public class ClickbleButtons : MonoBehaviour
{
    [SerializeField] private PlayerUI playerUI;

    private void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
    }

    private void Update()
    {
        OpenPlayerIU();
    }

    private void OpenPlayerIU()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject playerUIbackGround = playerUI.transform.GetChild(0).gameObject;
            playerUIbackGround.SetActive(!playerUIbackGround.activeInHierarchy);
            playerUI.OpenPlayerUI();
        }
    }
}
