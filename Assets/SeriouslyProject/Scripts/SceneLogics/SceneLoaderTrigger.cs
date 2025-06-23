using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTrigger : MonoBehaviour
{
    [SerializeField] string nextSceneToLoad;
    [SerializeField] Vector3 nextPositionToLoad;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ISceneLoader>(out var sceneLoader))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GlobalLoader.Instance.LoadToScene(nextSceneToLoad, collision.gameObject, nextPositionToLoad);
            }
        }
    }
}
