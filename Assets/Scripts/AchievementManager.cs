using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementManager : MonoBehaviour
{
    public GameObject detailsPanel;
    private bool colorfull=false;
    public CountryDataManager cData;
    private CountryData countryData;
    [HideInInspector] public int euC,naC,saC,asiaC,oceC,afC;
    public GameObject clover,rainbow,world;
    public GameObject eu,na,sa,oce,asia,af;

    public TextMeshProUGUI trophiesCount;
    public int counter;
    void Start()
    {
        CheckForSolvedCountries();
        SetTrophies(euC,eu);
        SetTrophies(afC,af);
        SetTrophies(asiaC,asia);
        SetTrophiesSmall(oceC,oce);
        SetTrophiesSmall(naC,na);
        SetTrophiesSmall(saC,sa);
        SetRareTrophies();
        trophiesCount.text=counter.ToString()+"/21";
    }
    public void SetRareTrophies()
    {
        if(colorfull==true)
        {
            rainbow.SetActive(true);
            counter++;
        }
        int sum;
        sum=euC+asiaC+oceC+naC+saC+afC;
        if(sum>=100)
        {
            world.SetActive(true);
            counter++;
        }
        if(PlayerPrefs.GetInt("guess1")>=1)
        {
            clover.SetActive(true);
            counter++;
        }
    }
    public void SetTrophies(int n,GameObject GO)
    {
        if(n>=20)
        {
            GO.transform.GetChild(4).gameObject.SetActive(true);
            GO.transform.GetChild(5).gameObject.SetActive(true);
            GO.transform.GetChild(6).gameObject.SetActive(true);
            counter=counter+3;
        }
        else if(n>=10)
        {
            GO.transform.GetChild(4).gameObject.SetActive(true);
            GO.transform.GetChild(5).gameObject.SetActive(true);
            counter=counter+2;
        }
        else if(n>=5)
        {
             GO.transform.GetChild(4).gameObject.SetActive(true);
             counter++;
        }
    }
    public void SetTrophiesSmall(int n,GameObject GO)
    {
        if(n>=10)
        {
            GO.transform.GetChild(4).gameObject.SetActive(true);
            GO.transform.GetChild(5).gameObject.SetActive(true);
            GO.transform.GetChild(6).gameObject.SetActive(true);
            counter=counter+3;
        }
        else if(n>=5)
        {
            GO.transform.GetChild(4).gameObject.SetActive(true);
            GO.transform.GetChild(5).gameObject.SetActive(true);
            counter=counter+2;
        }
        else if(n>=1)
        {
            GO.transform.GetChild(4).gameObject.SetActive(true);
            counter++;
        }
    }
    public void CheckForSolvedCountries()
    {
        for(int i=0;i<cData.Count;i++)
        {
            countryData=cData.GetCountryDataByID(i);
            if(PlayerPrefs.GetInt(countryData.countryName)==1)
            {
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
            if(countryData.flagColors.Length>=5)
            {
                colorfull=true;
            }
            }
        }
    }
    public void OpenDetailsPanel()
    {
        detailsPanel.SetActive(true);
    }
    public void CloseDetailsPanel()
    {
        detailsPanel.SetActive(false);
    }
}
