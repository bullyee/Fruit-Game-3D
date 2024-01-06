using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Show_list : MonoBehaviour,IPointerClickHandler
{
    public Image target;
    UItest uItest;
    // Start is called before the first frame update
    void Start()
    {
        uItest=target.GetComponent<UItest>();
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (!target.IsActive())
        {
            uItest.show_up();
        }
        else if(target.IsActive()) 
        {
            uItest.hide_up();
        }
    }

}
