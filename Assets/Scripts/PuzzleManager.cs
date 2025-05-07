using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public int placed=0;
    public int totalPeices=16;

    public GameObject firstPage;
    public GameObject gameObjects;
    public GameObject inGameUi;
    public GameObject nextSceneUi;


    void Start()
    {
        firstPage?.SetActive(true);
        gameObjects?.SetActive(false);
        inGameUi?.SetActive(false);
        nextSceneUi?.SetActive(false);
    }

    public void GetStarted()
    {
        firstPage?.SetActive(false);
        gameObjects?.SetActive(true);
        inGameUi?.SetActive(true);
        
    }

    public void GoToMiddle()
    {

    }

    public void GoToLastUi()
    {
        gameObjects?.SetActive(false);
        inGameUi?.SetActive(false);
        nextSceneUi?.SetActive(true);
    }


    void Update()
    {
        if(placed>= totalPeices)
        {
            GoToLastUi();
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
