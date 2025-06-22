using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

[DisallowMultipleComponent]
public class GlobalLoader : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    private GameObject player;

    private string SavePath => Path.Combine(Application.persistentDataPath, $"playerSave_{SceneManager.GetActiveScene().name}.json");

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // �������� �� ������� �������� �����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // ������� �� ������� ��� ����������� �������
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    // ���������� ������� �������� �����
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindWithTag(playerTag);
        if (player != null)
        {
            DontDestroyOnLoad(player);
            Load(); // ��������� ������ ������ ����� �������� ����� � ��������� ������
        }
    }

    private void Save()
    {
        if (player == null) return;

        var data = new PlayerData
        {
            Position = player.transform.position,
            Rotation = player.transform.rotation
        };

        File.WriteAllText(SavePath, JsonUtility.ToJson(data, true));
    }

    private void Load()
    {
        if (!File.Exists(SavePath)) return;

        var json = File.ReadAllText(SavePath);
        var data = JsonUtility.FromJson<PlayerData>(json);

        if (player != null)
        {
            player.transform.SetPositionAndRotation(data.Position, data.Rotation);
        }
    }

    [System.Serializable]
    private class PlayerData
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
}
