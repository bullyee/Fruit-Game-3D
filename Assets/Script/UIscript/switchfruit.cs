using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class switchfruit : MonoBehaviour, IPointerClickHandler
{
    public Image fruit;
    public List <Sprite> images = new List <Sprite> ();
    public GameObject now_indexer;
    now_index count;
    public void OnPointerClick(PointerEventData e)
    {
        if (count.index <= 8&&gameObject.name=="right")
        {
            count.index++;
            fruit.sprite = images[count.index];
            count.change_num();
        }
        if (count.index >= 1 && gameObject.name == "left")
        {
            count.index--;
            fruit.sprite = images[count.index];
            count.change_num();
        }
    }
    void Start()
    {
        count=now_indexer.GetComponent<now_index> ();
    }
}
