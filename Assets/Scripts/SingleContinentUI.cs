using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SingleContinentUI : MonoBehaviour
{
    public Image territoryImage;

    public Sprite territoryImageEU;
    public Sprite territoryImageNA;
    public Sprite territoryImageSA;
    public Sprite territoryImageAsia;
    public Sprite territoryImageAfrica;
    public Sprite territoryImageOceania;

    public void SetTerritory()
    {
        if(PlayerPrefs.GetInt("Europe")==1)
        {
            territoryImage.sprite=territoryImageEU;
        }
        if(PlayerPrefs.GetInt("North America")==1)
        {
            territoryImage.sprite=territoryImageNA;
        }
        if(PlayerPrefs.GetInt("South America")==1)
        {
            territoryImage.sprite=territoryImageSA;
        }
        if(PlayerPrefs.GetInt("Asia")==1)
        {
            territoryImage.sprite=territoryImageAsia;
        }
        if(PlayerPrefs.GetInt("Africa")==1)
        {
            territoryImage.sprite=territoryImageAfrica;
        }
        if(PlayerPrefs.GetInt("Oceania")==1)
        {
            territoryImage.sprite=territoryImageOceania;
        } 
    }
    void Start()
    {
        SetTerritory();
    }
}
