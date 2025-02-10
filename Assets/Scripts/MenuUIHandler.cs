#if UNITY_EDITOR
using TMPro;
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameText;
    public TextMeshProUGUI bestScoreText;
    private void Start()
    {
        //Reset values
        //DataManager.Instance.playerScore = 0;
        //DataManager.Instance.playerName = "";
        //DataManager.Instance.newPlayerName = "";
        //DataManager.Instance.SaveDataToJson();

        if (DataManager.Instance != null)
        {
            playerNameText.text = DataManager.Instance.newPlayerName;
            SetBestScoreValues(DataManager.Instance.playerName, DataManager.Instance.playerScore);
        }
    }
    public void QuitGame()
    {
        DataManager.Instance.SaveDataToJson();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void StartGame()
    {
        DataManager.Instance.newPlayerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void SetBestScoreValues(string playerName, float score)
    {
        if(score > 0) 
        {
            bestScoreText.text = "Best Score: " + playerName + ": " + score;
        }
    }
}
