using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class AlbumManager : MonoBehaviour
{
    public int cardsCounter=0;
    public GameObject CardSlotPrefab;
    [HideInInspector]public GameObject instantiatedCardSlot;
    public List<GameObject> CardList;
    public CountryDataManager dataMGR;
    public GameObject[] slots;
    public TextMeshProUGUI cardsNumberText;
    public TextMeshProUGUI pageText;
    public int page;
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PageTurnedRight()
    {
        if(page<17)
        {
            page++;
            pageText.text=page.ToString()+"/17" ; 
            CheckForCards();
        }
    }
    public void PageTurnedLeft()
    {
        if(page>1)
        {
            page--;
            pageText.text=page.ToString()+"/17";
            CheckForCards();
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    private void Update() 
    {
       // CheckForCards();
    }
    public void SetCardSlots(int x)
    {
        for(int i=0;i<slots.Length;i++)
        {
            slots[i].SetActive(true);
            slots[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (i+1+x).ToString();
        }
    }
    public void SetCards(int x)
    {
            for(int i=0;i<CardList.Count;i++)
            {
                CardList[i].SetActive(false);
                if(PlayerPrefs.GetInt(dataMGR.GetCountryDataByID(i+x).countryName)==1)
                {
                    CardList[i].gameObject.GetComponent<CountryCardDisplay>().cData=dataMGR.GetCountryDataByID(i+x);
                    CardList[i]=Instantiate(CardList[i],new Vector3(0,0,0),Quaternion.identity);
                    CardList[i].transform.SetParent(slots[i].transform, false);
                    CardList[i].SetActive(true);
                }
            }
    }
    private void Start() 
    {
        page=1;
        SetCardSlots(0);
        pageText.text=page.ToString()+"/17";
        for(int i=0;i<CardList.Count;i++)
        {
            CardList[i].gameObject.GetComponent<CountryCardDisplay>().cData=dataMGR.GetCountryDataByID(i);
        }
        for(int i=0;i<195;i++)
        {
            if(PlayerPrefs.GetInt(dataMGR.GetCountryDataByID(i).countryName)==1)
            {
                cardsCounter++;
            }
        }
        CheckForCards();
        cardsNumberText.text=cardsCounter.ToString();
    }
    public void CheckForCards()
    {
        switch(page)
        {
            case 1:
            SetCardSlots(0);
            SetCards(0);
            break;
           case 2:
            SetCardSlots(12);
            SetCards(12);
           break;
           case 3:
            SetCardSlots(24);
            SetCards(24);
           break;
           case 4:
            SetCardSlots(36);
            SetCards(36);
           break;
           case 5:
            SetCardSlots(48);
            SetCards(48);
           break;
           case 6:
            SetCardSlots(60);
            SetCards(60);
           break;
           case 7:
            SetCardSlots(72);
            SetCards(72);
           break;
           case 8:
            SetCardSlots(84);
            SetCards(84);
           break;
           case 9:
            SetCardSlots(96);
            SetCards(96);
           break;
           case 10:
            SetCardSlots(108);
            SetCards(108);
           break;
           case 11:
            SetCardSlots(120);
            SetCards(120);
           break;
           case 12:
            SetCardSlots(132);
            SetCards(132);
           break;
           case 13:
            SetCardSlots(144);
            SetCards(144);
           break;
           case 14:
            SetCardSlots(156);
            SetCards(156);
           break;
           case 15:
            SetCardSlots(168);
            SetCards(168);
           break;
           case 16:
            SetCardSlots(180);
            SetCards(180);
           break;
            case 17:
            for(int i=0;i<12;i++)
            {
                if(i<4)
                {
                    slots[i].transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (i+193).ToString();
                    CardList[i].SetActive(false);
                    if(PlayerPrefs.GetInt(dataMGR.GetCountryDataByID(i+192).countryName)==1)
                    {
                    
                    CardList[i].gameObject.GetComponent<CountryCardDisplay>().cData=dataMGR.GetCountryDataByID(i+193);
                    CardList[i]=Instantiate(CardList[i],new Vector3(0,0,0),Quaternion.identity);
                    CardList[i].transform.SetParent(slots[i].transform, false);
                    CardList[i].SetActive(true);
                    }
                }
                else
                {
                    slots[i].SetActive(false);
                    CardList[i].SetActive(false);
                }
            }
            break;
        }
    }
}
