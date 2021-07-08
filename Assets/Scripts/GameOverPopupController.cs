using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPopupController : MonoBehaviour
{
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button mainMenuReturnButton;
    [SerializeField] private TextMeshProUGUI scoreValueLabel;
    [SerializeField] private TextMeshProUGUI highScoreValueLabel;

    private void Awake()
    {
        restartGameButton.onClick.AddListener(RestartGame);
        mainMenuReturnButton.onClick.AddListener(MenuReturn);
        scoreValueLabel.text = PlayerPrefs.GetInt(PlayerPrefsKeys.LAST_SCORE_KEY).ToString();
        highScoreValueLabel.text =  PlayerPrefs.GetInt(PlayerPrefsKeys.HIGH_SCORE_KEY).ToString();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneNames.GAME_SCENE_NAME); 
    }

    private void MenuReturn()
    {

        SceneManager.LoadScene(SceneNames.MAIN_MENU_SCENE_NAME);
    }

}
