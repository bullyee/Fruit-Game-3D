using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class cancel : MonoBehaviour, IPointerClickHandler
{
    public Image fruit;
    public Sprite stb;
    public GameObject target;
    public GameObject count;
    Transform targetTransform;
    now_index now;
    void Start()
    {
        targetTransform=target.transform;
        now=count.GetComponent<now_index>();
    }
    public void OnPointerClick(PointerEventData e)
    {
        targetTransform.DOScale(0.001f, 0.2f).SetEase(Ease.InBack).OnComplete(canceler);
    }
    public void canceler()
    { 
        target.SetActive(false);
        now.index = 0;
        now.change_num();
        fruit.sprite =stb;
    }
}
