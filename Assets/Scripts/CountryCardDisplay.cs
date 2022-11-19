using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountryCardDisplay : MonoBehaviour
{
    public CountryData cData;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI continentText;
    public TextMeshProUGUI popText;
    public TextMeshProUGUI sizeText;
    public TextMeshProUGUI capitalText;
    public Image flagImage;

    public Image bgImage;

    public Image titleImage;

    public Image territoryImage;

    public Sprite bgImageEU;
    public Sprite bgImageNA;
    public Sprite bgImageSA;
    public Sprite bgImageAsia;
    public Sprite bgImageAfrica;
    public Sprite bgImageOceania;

    public Sprite titleImageEU;
    public Sprite titleImageNA;
    public Sprite titleImageSA;
    public Sprite titleImageAsia;
    public Sprite titleImageAfrica;
    public Sprite titleImageOceania;

    public Sprite territoryImageEU;
    public Sprite territoryImageNA;
    public Sprite territoryImageSA;
    public Sprite territoryImageAsia;
    public Sprite territoryImageAfrica;
    public Sprite territoryImageOceania;

    public Image[] labelImage;

    void Start()
    {
        nameText.text = cData.countryName;
        continentText.text= cData.continent;
        popText.text=string.Format("{0:#,0}", cData.population);
        sizeText.text=string.Format("{0:#,0}",cData.size)+" Km2";
        flagImage.sprite=cData.image;
        capitalText.text=cData.capitalCity;
        SetContinentBG();
        SetPopupTitle();
        SetTerritory();
        SetLabels();
    }
    public void SetLabels()
    {
        if(continentText.text=="Europe")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(80,103,168,100);
            }
        }
        if(continentText.text=="North America")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(15,11,11,100);
            }
        }
        if(continentText.text=="South America")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(255,128,0,100);
            }
        }
        if(continentText.text=="Africa")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(18,97,18,100);
            }
        }
        if(continentText.text=="Asia")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(255,0,0,100);
            }
        }
        if(continentText.text=="Oceania")
        {
            for(int i=0;i<labelImage.Length;i++)
            {
                labelImage[i].GetComponent<Image>().color= new Color32(100,0,100,100);
            }
        } 
    }
    public void SetTerritory()
    {
        if(continentText.text=="Europe")
        {
            territoryImage.sprite=territoryImageEU;
        }
        if(continentText.text=="North America")
        {
            territoryImage.sprite=territoryImageNA;
        }
        if(continentText.text=="South America")
        {
            territoryImage.sprite=territoryImageSA;
        }
        if(continentText.text=="Africa")
        {
            territoryImage.sprite=territoryImageAfrica;
        }
        if(continentText.text=="Asia")
        {
            territoryImage.sprite=territoryImageAsia;
        }
        if(continentText.text=="Oceania")
        {
            territoryImage.sprite=territoryImageOceania;
        } 
    }
    public void SetPopupTitle()
    {
        if(continentText.text=="Europe")
        {
            titleImage.sprite=titleImageEU;
        }
        if(continentText.text=="North America")
        {
            titleImage.sprite=titleImageNA;
        }
        if(continentText.text=="South America")
        {
            titleImage.sprite=titleImageSA;
        }
        if(continentText.text=="Africa")
        {
            titleImage.sprite=titleImageAfrica;
        }
        if(continentText.text=="Asia")
        {
            titleImage.sprite=titleImageAsia;
        }
        if(continentText.text=="Oceania")
        {
            titleImage.sprite=titleImageOceania;
        }
    }
    public void SetContinentBG()
    {
        if(continentText.text=="Europe")
        {
            bgImage.sprite=bgImageEU;
        }
        if(continentText.text=="North America")
        {
            bgImage.sprite=bgImageNA;
        }
        if(continentText.text=="South America")
        {
            bgImage.sprite=bgImageSA;
        }
        if(continentText.text=="Africa")
        {
            bgImage.sprite=bgImageAfrica;
        }
        if(continentText.text=="Asia")
        {
            bgImage.sprite=bgImageAsia;
        }
        if(continentText.text=="Oceania")
        {
            bgImage.sprite=bgImageOceania;
        }
    }
    /*public string FormatPopulation(string stringToFormat)
    {
        string formattedString;
        int n;
        int.TryParse(pop,out n);
        if(n>1000000000)
        {
            formattedString=()
        }
    }*/
}
