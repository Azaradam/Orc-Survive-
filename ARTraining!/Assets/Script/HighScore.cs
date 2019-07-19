using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public Text highScore;

    void Start()
    {
        var HS = PlayerPrefs.GetInt("HS", 0);
        highScore.text = "High Score = " + HS;
    }
}
