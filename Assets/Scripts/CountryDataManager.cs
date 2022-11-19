using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu]
public class CountryDataManager : ScriptableObject {
    public List<CountryData> Data;

    public int Count => Data != null ? Data.Count : 0;

    public CountryData GetCountryDataByID(int _countryID)
    {
        if (Data != null)
        {
            CountryData cData = Data.Find(x => x.countryID == _countryID);
            if (cData)
            {
                return cData;
            }
        }
        return null;
    }
}
