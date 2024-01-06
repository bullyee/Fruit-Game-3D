using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideObject : MonoBehaviour
{
    public GameObject getUI;
    void Start()
    {
        getUI.SetActive(false);
    }
    public void show_up()
    {
        Transform objTransform = getUI.transform;
        if (objTransform != null)
        {
            getUI.SetActive(true);
        }
    }
}
