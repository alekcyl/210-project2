using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript: MonoBehaviour
{
    //reference to player data class
    public PlayerData Data;

    public void Start()
    {
        //load player data or create it
        if(PlayerPrefs.HasKey("gamedata"))
        {
            string jsondata = PlayerPrefs.GetString("gamedata");
            Data = JsonUtility.FromJson<PlayerData>(jsondata);
        }
        else
        {
            Data.currentLevel = 1;
            string dataAsJSON = JsonUtility.ToJson(Data, true);
            PlayerPrefs.SetString("gamedata", dataAsJSON);
        }
    }
    //call if player loses level
    public void RestartLevel()
    {
        SceneManager.LoadScene($"Level{Data.currentLevel}");
    }
    //call if level must be changed. Give level number
    public void changeLevel(int num)
    {
        SceneManager.LoadScene($"Level{num}");
    }
    //main menu button
    public void playButton()
    {
        SceneManager.LoadScene($"Level{Data.currentLevel}");
    }

    //quit to menu button
    public void quitButton()
    {
        Debug.Log("main menu");
        SceneManager.LoadScene("Main_Menu");
    }

    //quit applicatiomn
    public void closeApp()
    {
        Application.Quit();
    }
}