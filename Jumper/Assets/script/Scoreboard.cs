using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scoreboard : MonoBehaviour
{

    [SerializeField] Text scoreText;
    public float score;

    void Update()
    {
        scoreText.text = "Score : " + Mathf.Round(score).ToString();

    }
}
