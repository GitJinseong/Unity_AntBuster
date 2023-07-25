using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTopBtn_2 : MonoBehaviour
{
    public int price = 1000;
    
    public void CreateForTop()
    {
        GameManager.instance.type = 2;
        if (GameManager.instance.gold >= price)
        {
            GameManager.instance.grid.SetActive(true);
        }
    }
}
