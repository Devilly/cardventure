﻿using UnityEngine;
using UnityEngine.UI;

public class ShowHighscore : MonoBehaviour {

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

        SetText();
    }

    private void SetText()
    {
        text.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);
    }
}
