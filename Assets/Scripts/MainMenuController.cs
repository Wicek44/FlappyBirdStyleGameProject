using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Button startGameButton;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGame);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(SceneNames.GAME_SCENE_NAME); 
    }

    private void ExitGame()
    {
       
        Application.Quit();
    }

}
