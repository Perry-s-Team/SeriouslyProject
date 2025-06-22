using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderTrigger : MonoBehaviour
{
    [SerializeField] string nextSceneToLoad;
    [SerializeField] Vector3 nextPositionToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<ISceneLoader>(out var sceneLoader))
        {
            GlobalLoader.Instance.LoadToScene(nextSceneToLoad, collision.gameObject, nextPositionToLoad);
        }
    }
}
