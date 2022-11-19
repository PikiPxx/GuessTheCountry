using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public GameObject selectPanel;
    public GameObject worldToggle;
    public GameObject euToggle;
    public GameObject naToggle;
    public GameObject saToggle;
    public GameObject africaToggle;
    public GameObject asiaToggle;
    public GameObject oceaniaToggle;

    public GameObject playAnimation;
    private void Awake() {
        playAnimation.gameObject.GetComponent<Animator>().enabled = true;
    }
    void Start()
    {
        PlayerPrefs.SetInt("Europe",0);
        PlayerPrefs.SetInt("North America",0);
        PlayerPrefs.SetInt("South America",0);
        PlayerPrefs.SetInt("Africa",0);
        PlayerPrefs.SetInt("Asia",0);
        PlayerPrefs.SetInt("Oceania",0);

        selectPanel.SetActive(false);
    }
    public void StatsButtonPressed()
    {
        SceneManager.LoadScene("StatsScene");
    }
    public void AlbumButtonPressed()
    {
        SceneManager.LoadScene("AlbumScene");
    }
    public void AchievementButtonPressed()
    {
        SceneManager.LoadScene("AchievementScene");
    }
    public void PlayButtonPressed()
    {
        playAnimation.gameObject.GetComponent<Animator>().enabled = false;
        selectPanel.SetActive(true);
    }
    public void EUToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void NAToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void SAToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void AfricaToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void AsiaToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void OceaniaToggleChanged()
    {
        worldToggle.GetComponent<Toggle>().isOn = false;
    }
    public void OnConfirmButton()
    {
        if(worldToggle.GetComponent<Toggle>().isOn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else
        {
            if(euToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("Europe",1);
                SceneManager.LoadScene("EUScene");
            }
            if(naToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("North America",1);
                SceneManager.LoadScene("NAScene");
            }
            if(saToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("South America",1);
                SceneManager.LoadScene("SouthAmericaScene");
            }
            if(africaToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("Africa",1);
                SceneManager.LoadScene("AfricaScene");
            }
            if(asiaToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("Asia",1);
                SceneManager.LoadScene("AsiaScene");
            }
            if(oceaniaToggle.GetComponent<Toggle>().isOn)
            {
                PlayerPrefs.SetInt("Oceania",1);
                SceneManager.LoadScene("OceaniaScene");
            }
        }
    }
    public void OnClosePanel()
    {
        playAnimation.gameObject.GetComponent<Animator>().enabled = true;
        selectPanel.SetActive(false);
            worldToggle.GetComponent<Toggle>().isOn = true;
            euToggle.GetComponent<Toggle>().isOn = true;
            naToggle.GetComponent<Toggle>().isOn = true;
            saToggle.GetComponent<Toggle>().isOn = true;
            africaToggle.GetComponent<Toggle>().isOn = true;
            asiaToggle.GetComponent<Toggle>().isOn=true;
            oceaniaToggle.GetComponent<Toggle>().isOn=true;
    }
}
