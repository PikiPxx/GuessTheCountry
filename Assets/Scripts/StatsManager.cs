using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public CountryDataManager cData;
    public CountryData countryData;
    public Image[] guessBars;
    public int[] array;
    public TextMeshProUGUI[] guessValues;
    public int allGuesses=0;
    public int maxWidth;
    public int maxValue;

    public TextMeshProUGUI euT,naT,saT,asiaT,oceT,afT;
    [HideInInspector] public int euC,naC,saC,asiaC,oceC,afC;
    //public int maxIndex;
    private void Start() 
    {
        array=new int[7];
        CheckGuesses();
        CheckForSolvedCountries();
        euT.text=euC.ToString()+" / 47";
        naT.text=naC.ToString()+" / 23";
        saT.text=saC.ToString()+" / 12";
        asiaT.text=asiaC.ToString()+" / 48";
        afT.text=afC.ToString()+" / 54";
        oceT.text=oceC.ToString()+" / 12";
    }
    public void CheckForSolvedCountries()
    {
        for(int i=0;i<cData.Count;i++)
        {
            countryData=cData.GetCountryDataByID(i);
            if(PlayerPrefs.GetInt(countryData.countryName)==1)
            switch(countryData.continent)
            {
                case "Europe":
                euC++;
                break;
                case "Africa":
                afC++;
                break;
                case "Asia":
                asiaC++;
                break;
                case "North America":
                naC++;
                break;
                case "South America":
                saC++;
                break;
                case "Oceania":
                oceC++;
                break;
            }
        }
    }
    public void CheckGuesses()
    {
        for(int i=0;i<guessBars.Length;i++)
        {
            int j=i+1;
            allGuesses+=PlayerPrefs.GetInt("guess"+j.ToString());
            array[i]=PlayerPrefs.GetInt("guess"+j.ToString());
        }
        maxValue=array.Max();
        for(int i=0;i<guessBars.Length;i++)
        {
            //int j=i+1;
            RectTransform rt =guessBars[i].transform.GetComponent<RectTransform>();
            float value=(float)(array[i]*maxWidth/maxValue);
            if(array[i]==maxValue)
            {
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,maxWidth);
            }
            else if(array[i]!=0)
            {
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,value);
            }
            else
            {
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,0.1f);
            } 
            guessValues[i].text=array[i].ToString();
        }
    }
}
