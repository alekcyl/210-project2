using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public PlayerData Data;

    private void Start()
    {
        //load player data or create it
        if (PlayerPrefs.HasKey("gamedata"))
        {
            string jsondata = PlayerPrefs.GetString("gamedata");
            Debug.Log($"Loading Data: \n{jsondata}");
            Data = JsonUtility.FromJson<PlayerData>(jsondata);
            Debug.Log(jsondata);

        }
        else
        {
            Debug.Log("No saved data at 'gamedata'");
            Data.currentLevel = 1;
            string dataAsJSON = JsonUtility.ToJson(Data, true);
            Debug.Log(dataAsJSON);
            PlayerPrefs.SetString("gamedata", dataAsJSON);
        }
    }

    //call if player loses level
    public void RestartLevel()
    {
        SceneManager.LoadScene($"Level{Data.currentLevel}");
    }

    //call if level must be changed. Must give level number
    public void changeLevel(int num)
    {
        SceneManager.LoadScene($"Level{num}");
    }

    //main menu play button
    public void playButton()
    {
        //Data.currentLevel = 1;
        //string dataAsJSON = JsonUtility.ToJson(Data, true);
        //Debug.Log(dataAsJSON);
        //PlayerPrefs.SetString("gamedata", dataAsJSON);

        SceneManager.LoadScene($"Level{Data.currentLevel}");
    }

}
