using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Linq;

public class SimpleQuizThreeFields : MonoBehaviour
{
    [HideInInspector]public GameObject instantiatedCard;
    public GameObject CardPrefab;
    public List<Color32> Colors;
    public List<CountryData> SelectedCountries;
    [HideInInspector] public int counter;
    
    public CountryDataManager CData;
    public CountryDataManager EuData;
    public InputField inputField;
    [HideInInspector] public CountryData targetCountry;
    [HideInInspector] public CountryData countryData;
    [HideInInspector] public CountryData inputCountry;
    [HideInInspector] public bool sameColors=false;

   [SerializeField] public TextMeshProUGUI populationText;
   [SerializeField] public TextMeshProUGUI sizeText;
   [SerializeField] public TextMeshProUGUI flagText;

   [SerializeField] GameObject resultGroup;
   [SerializeField] GameObject resultGroup1;
   [SerializeField] GameObject resultGroup2;
   [SerializeField] GameObject resultGroup3;
   [SerializeField] GameObject resultGroup4;
   [SerializeField] GameObject resultGroup5;
   [SerializeField] GameObject resultGroup6;

   [SerializeField] public Image popImage;
   [SerializeField] public Image sizeImage;
   [SerializeField] public Image flagImage;

   [SerializeField] public GameObject guess1;
   [SerializeField] public GameObject guess2;
   [SerializeField] public GameObject guess3;
   [SerializeField] public GameObject guess4;
   [SerializeField] public GameObject guess5;
   [SerializeField] public GameObject guess6;
   [SerializeField] public GameObject guess7;

   [SerializeField] public TextMeshProUGUI solutionText;
   [SerializeField] public GameObject solutionPanel;
   [SerializeField] public Image solutionImage;

   [HideInInspector] public int guessCounter;
   public GameObject winPanel;
    string guess;
    //PieChart for 3
    public Image wedgePrefab;
    public void MakeGraph(List<Color32> newList, GameObject parentObject)
    {
        if(newList!=null)
        {
        if(newList.Count>0)
        {
            resultGroup.transform.GetChild(2).transform.GetChild(0).gameObject.SetActive(false);
            float total=0f;
            float zRotation=0f;
            for(int i=0;i<newList.Count;i++)
            {
            total++;
            }
            for(int i=0;i<newList.Count;i++)
            {
                Image newWedge=Instantiate(wedgePrefab,new Vector3(0,0,0),Quaternion.identity) as Image;
                newWedge.transform.SetParent(parentObject.transform.GetChild(2).transform, false);
                newWedge.color = newList[i];
                var tempColor = newWedge.color;
                tempColor.a=1f;
                newWedge.color=tempColor;
                newWedge.fillAmount = 1/total;
                newWedge.transform.rotation = Quaternion.Euler(new Vector3(0,0,zRotation));
                zRotation -= newWedge.fillAmount * 360f;
            }
        }
        else
        {
            resultGroup.transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text="N/A";
            resultGroup.transform.GetChild(2).gameObject.GetComponent<Image>().color=new Color32(161,173,167,100);
        }
        }
    }
    private void Awake() 
    {
        if(PlayerPrefs.GetInt("Europe")==1)
        {
            FillList(SelectedCountries,"Europe");
        }
        if(PlayerPrefs.GetInt("North America")==1)
        {
            FillList(SelectedCountries,"North America");
        }
        if(PlayerPrefs.GetInt("South America")==1)
        {
            FillList(SelectedCountries,"South America");
        }
        if(PlayerPrefs.GetInt("Africa")==1)
        {
            FillList(SelectedCountries,"Africa");
        }
        if(PlayerPrefs.GetInt("Asia")==1)
        {
            FillList(SelectedCountries,"Asia");
        }
        if(PlayerPrefs.GetInt("Oceania")==1)
        {
            FillList(SelectedCountries,"Oceania");
        }
    }
    //Populate SelectedCountries list
    private void FillList(List<CountryData> newList,string contName)
    {
        for(int i=0;i<CData.Count;i++)
            {
                countryData = CData.GetCountryDataByID(i);
                if(string.Equals(countryData.continent,contName))
                {
                    newList.Add(countryData);
                }
            }
    }
    private void Start() 
    {
        guessCounter=0;
        for(int i=0;i<CData.Count;i++)
        {
            countryData=CData.GetCountryDataByID(i);
        }
        solutionPanel.SetActive(false);
        counter=0;
        populationText.text="?";
        sizeText.text="?";
            int randomCountryID = Random.Range(0, SelectedCountries.Count);
            Debug.Log($"Country ID {randomCountryID}");
            countryData = SelectedCountries[randomCountryID];
            if (countryData != null)
            {
                targetCountry = SelectedCountries[randomCountryID];
                CardPrefab.gameObject.GetComponent<CountryCardDisplay>().cData=targetCountry;
                Debug.Log($"Country Name {countryData.countryName} Country Population {countryData.population}");
            }
    }
    //Returns country by name
    public CountryData GetCountryDataByName(List<CountryData> cList,string cName)
    {
        if (cList != null)
        {
            CountryData cData = cList.Find(x => x.countryName == cName);
            if (cData)
            {
                return cData;
            }
        }
        return null;
    }
    //Convert firstLetter
    string ToTitleCase(string stringToConvert)
    {
        string firstChar= stringToConvert[0].ToString();
        return (stringToConvert.Length>0 ? firstChar.ToUpper()+stringToConvert.Substring(1) : stringToConvert);
       
    }
    private void Update()
    {
        string inputGuess = inputField.text;
        if(inputGuess!="")
        {
            guess = Regex.Replace(inputGuess, @"(^\w)|(\s\w)", m => m.Value.ToUpper());
            Debug.Log(guess);
        }
    }
    //Show results when input is confirmed
    public void CheckButtonPressed()
    {
        CheckForInputCountry();
        switch(counter)
        {
            case 0:
                StartCoroutine(WaitPleaseCo(resultGroup,0.000001f,1.0f));
                CompareCountries(resultGroup);
                SetTextAndImage(guess1);
                guessCounter++;
            break;
            case 1:
                StartCoroutine(WaitPleaseCo(resultGroup1,0.000001f,1.0f));
                CompareCountries(resultGroup1);
                SetTextAndImage(guess2);
                guessCounter++;
            break;
            case 2:
                StartCoroutine(WaitPleaseCo(resultGroup2,0.000001f,1.0f));
                CompareCountries(resultGroup2);
                SetTextAndImage(guess3);
                guessCounter++;
            break;
            case 3:
                StartCoroutine(WaitPleaseCo(resultGroup3,0.000001f,1.0f));
                CompareCountries(resultGroup3);
                SetTextAndImage(guess4);
                guessCounter++;
            break;
            case 4:
                StartCoroutine(WaitPleaseCo(resultGroup4,0.000001f,1.0f));
                CompareCountries(resultGroup4);
                SetTextAndImage(guess5);
                guessCounter++;
            break;
            case 5:
                StartCoroutine(WaitPleaseCo(resultGroup5,0.000001f,1.0f));
                CompareCountries(resultGroup5);
                SetTextAndImage(guess6);
                guessCounter++;
            break;
            case 6:
                StartCoroutine(WaitPleaseCo(resultGroup6,0.000001f,1.0f));
                CompareCountries(resultGroup6);
                SetTextAndImage(guess7);
                solutionText.text=targetCountry.countryName;
                solutionImage.sprite=targetCountry.image;
                solutionPanel.SetActive(true);
                guessCounter++;
            break;
        }
        counter++;
    }
    //Find data about input country
    public void CheckForInputCountry()
    {
        Debug.Log("Count: "+SelectedCountries.Count);
        for(int i=0;i<SelectedCountries.Count;i++)
            {
              countryData=SelectedCountries[i];
                if(string.Equals(countryData.countryName,guess))
                    {
                        Debug.Log("Found it! "+$"Country Name {countryData.countryName} Country Population {countryData.population}");
                        inputCountry = GetCountryDataByName(SelectedCountries,guess);
                    }
            }
    }
    private void CompareCountries(GameObject resultGroup)
    {
        Debug.Log("Target Country:"+targetCountry.countryName);
        //Debug.Log("Input Country:"+inputCountry.countryName);
        if(inputCountry!=null)
        {
        //-------------------------------------POPULATION---------------------------------
        if(inputCountry.population > targetCountry.population)
        {
            resultGroup.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(inputCountry.population,'<');
            resultGroup.transform.GetChild(0).GetComponent<Image>().color = new Color32(161,173,167,100);
        }
        else if(inputCountry.population < targetCountry.population)
        {
            resultGroup.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(inputCountry.population,'>');
            resultGroup.transform.GetChild(0).GetComponent<Image>().color = new Color32(161,173,167,100);
        }
        else
        {
            resultGroup.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(targetCountry.population,' ');
            resultGroup.transform.GetChild(0).GetComponent<Image>().color = new Color32(0,255,0,100);
            //Instatiating card
            winPanel.SetActive(true);
            instantiatedCard= Instantiate<GameObject>(CardPrefab, new Vector3(0,0,0), Quaternion.identity);
            instantiatedCard.transform.localScale=new Vector3(1,1,0);
            instantiatedCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(15).transform, false);
            PlayerPrefs.SetInt(targetCountry.countryName,1);
        }
        //-------------------------------------size---------------------------------
        if(inputCountry.size > targetCountry.size)
        {
            resultGroup.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(inputCountry.size,'<');
            resultGroup.transform.GetChild(1).GetComponent<Image>().color = new Color32(161,173,167,100);
        }
        else if(inputCountry.size<targetCountry.size)
        {
             resultGroup.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(inputCountry.size,'>');
             resultGroup.transform.GetChild(1).GetComponent<Image>().color = new Color32(161,173,167,100);
        }
        else
        {
             resultGroup.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text=FormatString(inputCountry.size,' ');
             resultGroup.transform.GetChild(1).GetComponent<Image>().color=new Color32(0,255,0,100);
        }
        //-------------------------------------FLAGS---------------------------------
        CheckFlagColors();
        MakeGraph(Colors,resultGroup);
        Colors.Clear();
        }
    }
    //Compare flag colors function
    private void CheckFlagColors()
    {
        for(int i=0;i<targetCountry.flagColors.Length;i++)
        {
            for(int j=0;j<inputCountry.flagColors.Length;j++)
            {
                if(inputCountry.flagColors[j]==targetCountry.flagColors[i])
                {
                    Colors.Add(inputCountry.flagColors[j]);
                    sameColors=true;
                }
            }
        }
        Colors.Distinct();
    }
    //Format population and size to look nice
    private string FormatString(int n,char c)
    {
        string s;
           if(n>1000000000)
            {
                s = c+((float)n/1000000000).ToString("0.00")+"B";
            }else if(n>1000000)
            {
                s=c+((float)n/1000000).ToString("0.00")+"M";
            }else if(n>100000)
            {
                s=c+(n/1000).ToString()+"K";
            }
            else if(n>10000)
            {
                s=c+(n/1000).ToString()+"K";
            }
            else if(n>1000)
            {
                s=c+((float)n/1000).ToString("0.00")+"K";
            }
            else
            {
                s=c+n.ToString();
            }
            return s;
    }
    //Set up and show guessed countries
    public void SetTextAndImage(GameObject guess)
    {
        guess.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text=(guessCounter+1).ToString()+". "+inputCountry.countryName;
        guess.transform.GetChild(1).GetComponent<Image>().sprite = inputCountry.image;
        guess.SetActive(true);
    }
    IEnumerator WaitPleaseCo(GameObject whatToFlip,float duration, float size)
    {
        while(size > 0.1)
        {
            size=size - 0.07f;
            whatToFlip.transform.GetChild(0).transform.localScale = new Vector3(1,size,1);
            whatToFlip.transform.GetChild(1).transform.localScale = new Vector3(1,size,1);
            whatToFlip.transform.GetChild(2).transform.localScale = new Vector3(1,size,1);
            
            yield return new WaitForSeconds(duration);
        }
        while(size<0.99)
        {
            size=size+0.07f;
            whatToFlip.transform.GetChild(0).transform.localScale = new Vector3(1,size,size);
            whatToFlip.transform.GetChild(1).transform.localScale = new Vector3(1,size,size);
            whatToFlip.transform.GetChild(2).transform.localScale = new Vector3(1,size,size);
            
            yield return new WaitForSeconds(duration);
        }
    }
}
