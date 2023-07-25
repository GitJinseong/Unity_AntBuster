using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTopBtn_1 : MonoBehaviour
{
    public int price = 500;
    
    public void CreateForTop()
    {
        GameManager.instance.type = 1;
        if (GameManager.instance.gold >= price)
        {
            GameManager.instance.grid.SetActive(true);
        }
    }
}
