using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pause : MonoBehaviour,IPointerClickHandler
{
    public GameObject game,sb;
    public Image score01, score02, score03, score00;
    scorecounter sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = sb.GetComponent<scorecounter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (Time.timeScale != 0)
        {
            game.SetActive(true);
            Time.timeScale = 0;
            GameObject.Find("s4").GetComponent<Image>().sprite = sc.score_00.sprite;
            GameObject.Find("s3").GetComponent<Image>().sprite = sc.score_01.sprite;
            GameObject.Find("s2").GetComponent<Image>().sprite = sc.score_02.sprite;
            GameObject.Find("s1").GetComponent<Image>().sprite = sc.score_03.sprite;
        }
        else if(Time.timeScale == 0)
        {
            game.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
