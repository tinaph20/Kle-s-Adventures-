using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    private string saveLocation;

    // Start is called before the first frame update
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
          playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
          platformPosition = GameObject.FindGameObjectWithTag("Spawn").transform.position
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
          SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));

          GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
          GameObject.FindGameObjectWithTag("Spawn").transform.position = saveData.platformPosition;
        }
        else
        {
          SaveGame();
        }
    }
}
