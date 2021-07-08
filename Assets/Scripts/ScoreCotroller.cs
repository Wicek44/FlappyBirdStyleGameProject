using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCotroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValueLabel;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        playerController.OnScoreChanged += DisplayCurrentScore;
    }

    private void DisplayCurrentScore(int score)
    {
        scoreValueLabel.text = score.ToString();
    }


}
