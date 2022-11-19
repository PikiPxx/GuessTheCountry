using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShowCard : MonoBehaviour, IPointerDownHandler
{
    public GameObject shownCard;
    public GameObject zoomPanel;
    public int counter=0;
    private void Awake() 
    {
        zoomPanel=FindObjectOfType<Canvas>().transform.GetChild(4).gameObject;
    }
   public void OnPointerDown(PointerEventData eventData)
   {
    Debug.Log("Click detected");
    shownCard = Instantiate<GameObject>(this.gameObject,new Vector3(0,0,0),Quaternion.identity);
    shownCard.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).transform, false);
    shownCard.transform.localScale = new Vector3(1,1,0);
    zoomPanel.SetActive(true);
    shownCard.SetActive(true);
   }
}


