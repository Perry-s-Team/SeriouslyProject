using Cinemachine;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Start()
    {
        CinemachineVirtualCamera cam = GetComponent<CinemachineVirtualCamera>();
        cam.Follow = FindObjectOfType<TestMovement>().transform;
    }
}
