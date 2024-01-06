using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scorecounter : MonoBehaviour
{
    public int higest=0,score = 0;
    public Image score_02,score_01,score_00,score_03;
    public Sprite[] numberSprites;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scoreadd(int s)
    {
        score+=s;
        int d = score / 1000;
        int a = (score-d*1000) / 100;
        int b = (score-d*1000 - a * 100) / 10;
        int c = score -d*1000 -a * 100 - b * 10;
        score_03.sprite = numberSprites[d];
        score_02.sprite = numberSprites[a];
        score_01.sprite = numberSprites[b];
        score_00.sprite = numberSprites[c];        
    }
}
