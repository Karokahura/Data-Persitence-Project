using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    public Text bestScoreText;
    private void Start()
    {
        if (DataManager.Instance != null)
        {
            SetBestScoreValues(DataManager.Instance.playerName,DataManager.Instance.playerScore);
        }

    }


    public void SetBestScoreValues(string playerName, float score)
    {
        bestScoreText.text = "Best Score: " + playerName + ": " + score;
    }
}
