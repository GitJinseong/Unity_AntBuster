using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCancel: MonoBehaviour
{

    public void Run()
    {
        if (GameManager.instance.grid.active)
        {
            GameManager.instance.grid.SetActive(false);
        }
    }
}
