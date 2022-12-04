using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
   
    public GameObject Missile;
    public GameObject Missile2;
    public PlayerData Data;
    public GameObject SceneScript;
    public TextMeshProUGUI MissileText;

    public int curLevel;
    public int missileNumber;
    public int enemiesNum;
    public float MissileSpeed;
    public float moveSpeed;
    public int MaxLevels;


    private void Start()
    {
        MissileText = GameObject.FindGameObjectWithTag("RocketText").GetComponent<TextMeshProUGUI>();
        missileNumber = 10;
        MissileText.SetText($"Missile Number: {missileNumber} ");

        MaxLevels = 4;

        //load player data or create it
        if (PlayerPrefs.HasKey("gamedata"))
        {
            string jsondata = PlayerPrefs.GetString("gamedata");
            Debug.Log($"Loading Data: \n{jsondata}");
            Data = JsonUtility.FromJson<PlayerData>(jsondata);
            Debug.Log(jsondata);
            curLevel = Data.currentLevel;
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

    //method to save player data
    public void saveData()
    {
        Data.currentLevel = curLevel;
        string dataAsJSON = JsonUtility.ToJson(Data, true);
        Debug.Log(dataAsJSON);
        PlayerPrefs.SetString("gamedata", dataAsJSON);
    }
 
    void Update()
    {
        //find all enemies in level
        GameObject[] EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesNum = EnemyList.Length;
       
        //check win conditions
        if(enemiesNum > 0 && missileNumber <= 0)
        {
            SceneScript.GetComponent<SceneScript>().RestartLevel();
        } else if(enemiesNum <= 0)
        {
            if(curLevel < MaxLevels)
            {
                curLevel += 1;
            } else
            {
                curLevel = 1;
            }
            
            saveData();
            SceneScript.GetComponent<SceneScript>().changeLevel(curLevel);
            
        }


        //shooting mechanics
        if (Input.GetKeyDown(KeyCode.Space) && missileNumber >= 1)
        {
            GameObject shot = Instantiate(Missile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0,0,-90)));
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(MissileSpeed, 0));
            missileNumber--;
            MissileText.SetText($"Missile Number: {missileNumber} ");

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject shot = Instantiate(Missile2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, -90)));


            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));

        }

        //movement mechanics
        float movementInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(0, movementInput, 0);
    }

}
