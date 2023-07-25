using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TMP_Text scoreText = default;
    public TMP_Text goldText = default;
    public GameObject grid = default;
    public GameObject gridErrorMsg = default;
    public int type = default;
    public int score = default;
    public int gold = 100;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = score.ToString();
        goldText.text = gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void AddGold(int gold_)
    {
        gold += gold_;
        goldText.text = gold.ToString();
    }
}
