using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTopBtn_0 : MonoBehaviour
{
    public int price = 100;
    
    public void CreateForTop()
    {
        GameManager.instance.type = 0;
        if (GameManager.instance.gold >= price)
        {
            GameManager.instance.grid.SetActive(true);
        }
    }
}
