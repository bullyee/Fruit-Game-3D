using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class now_index : MonoBehaviour
{
    public int index=0;
    public Image num,num2;
    public List<Sprite> sprites = new List<Sprite>();
    public void change_num()
    {
        if (index <= 8)
        {
            num.sprite = sprites[index];
            num2.enabled = false;
        }
        else
        {
            num.sprite = sprites[0];
            num2.enabled=true;
        }
    }
    void Start()
    {
        num2.enabled = false;
    }
}
