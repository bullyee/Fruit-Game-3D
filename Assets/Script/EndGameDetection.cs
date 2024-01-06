using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class EndGameDetection : MonoBehaviour
{
    GameObject game;
    hideObject hide;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("EndGameTrigger");
        hide = game.GetComponent<hideObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "End" && enabled)
        {
            Physics.simulationMode = SimulationMode.Script;
            //add scene transform here
            scorecounter sc= GameObject.Find("scoreboard").GetComponent<scorecounter>();
            GameObject.Find("EndGameTrigger").GetComponent<endgame>().isend = true;
            hide.show_up();
            if (sc.score >= sc.higest)
            {
                sc.higest = sc.score;
                GameObject.Find("record1").GetComponent<Image>().sprite=sc.score_03.sprite;
                GameObject.Find("record4").GetComponent<Image>().sprite = sc.score_00.sprite;
                GameObject.Find("record3").GetComponent<Image>().sprite = sc.score_01.sprite;
                GameObject.Find("record2").GetComponent<Image>().sprite = sc.score_02.sprite;
                GameObject.Find("s1").GetComponent<Image>().sprite = sc.score_03.sprite;
                GameObject.Find("s4").GetComponent<Image>().sprite = sc.score_00.sprite;
                GameObject.Find("s3").GetComponent<Image>().sprite = sc.score_01.sprite;
                GameObject.Find("s2").GetComponent<Image>().sprite = sc.score_02.sprite;

            }
        }
    }
}
