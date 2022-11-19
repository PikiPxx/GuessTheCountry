using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlagPieChart : MonoBehaviour
{
    public Image flagImagePrefab;
    SimpleQuizThreeFields sQuizThree;
    public List<Color32> ColorsToFill;
    void Awake()
    {
        sQuizThree=GameObject.Find("SimpleQuiz").GetComponent<SimpleQuizThreeFields>();
    }
    private void Start() {
      
    }
    public void MakeGraph()
    {
        for(int i=0;i<sQuizThree.Colors.Count;i++)
        {
            ColorsToFill[i]=sQuizThree.Colors[i];
        }
        float total = 0f;
        float zRotation=0f;
        for(int i=0;i<ColorsToFill.Count;i++)
        {
            total++;
        }
        for(int i=0;i<ColorsToFill.Count;i++)
        {
            Image newWedge = Instantiate(flagImagePrefab) as Image;
            newWedge.transform.SetParent(transform,false);
            newWedge.color=ColorsToFill[i];
            newWedge.fillAmount=1f/total;
            newWedge.transform.rotation=Quaternion.Euler(new Vector3(0f,0f,zRotation));
            zRotation -= newWedge.fillAmount * 360f;
        }
    }
}
