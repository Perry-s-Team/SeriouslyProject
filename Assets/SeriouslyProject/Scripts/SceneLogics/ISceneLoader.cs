using UnityEngine.SceneManagement;

public interface ISceneLoader
{
    public void LoadToScene(string sceneToLoad)
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
