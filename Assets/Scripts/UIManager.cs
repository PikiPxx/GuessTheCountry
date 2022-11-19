using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject answerPanel;
    public GameObject winPanel;
    public void closeWinPanel()
    {
        winPanel.SetActive(false);
    }
    public void AchievementButtonPressed()
    {
        SceneManager.LoadScene("AchievementScene");
    }
    public void AlbumButtonPressed()
    {
        SceneManager.LoadScene("AlbumScene");
    }
    public void ReloadScene() 
    {
        Debug.Log("Click detected");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ClosePanel()
    {
        Debug.Log("Click detected");
        answerPanel.SetActive(false);
    }
    public void OnHomeButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
}
