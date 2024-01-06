using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UItest : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void show_up()
    {
        Transform objTransform = gameObject.transform;
        if (objTransform != null)
        {
            gameObject.SetActive(true);
            objTransform.localScale = Vector3.one * 0.001f;
            objTransform.DOScale(0.35f, 0.2f);
        }
    } 
    public void hide_up() 
    {
        Transform objTransform = gameObject.transform;
        if (objTransform != null)
        {
            objTransform.DOScale(0.001f, 0.2f).OnComplete(hide);
        }
    }
    void hide()
    {
        gameObject.SetActive(false);
    }

}
