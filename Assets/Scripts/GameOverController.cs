using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI scoreValueLabel;

    private void Awake()
    {
        playerController.OnGameOver += HandleGameOver;
    }

    private void HandleGameOver()
    {
        CheckAndSaveHighScore();

        scoreLabel.gameObject.SetActive(false);
        scoreValueLabel.gameObject.SetActive(false);


        SceneManager.LoadScene(SceneNames.GAME_OVER_SCENE_NAME, LoadSceneMode.Additive);
        
    }

    private void CheckAndSaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt(PlayerPrefsKeys.HIGH_SCORE_KEY);

        if (highScore < playerController.Score)
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.HIGH_SCORE_KEY, playerController.Score);
        }

        PlayerPrefs.SetInt(PlayerPrefsKeys.LAST_SCORE_KEY, playerController.Score);
    }
}
