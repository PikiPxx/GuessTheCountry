using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CountryData : ScriptableObject
{
    public int countryID;
    public string countryName;
    public string capitalCity;
    public Color[] flagColors;
    public int population;
    public int size;
    public string continent;
    public Sprite image;
}
