using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowEmotion : MonoBehaviour {

    public Life life;

    public Sprite threeLifes;
    public Sprite twoLifes;
    public Sprite oneLife;

    private Image image;

	void Start () {
        image = GetComponent<Image>();

        SetEmotionallyCorrectSprite();
    }
	
	void Update () {
        SetEmotionallyCorrectSprite();
    }

    private void SetEmotionallyCorrectSprite()
    {
        if(life.currentLife == 3)
        {
            image.sprite = threeLifes;
        } else if(life.currentLife == 2)
        {
            image.sprite = twoLifes;
        } else if(life.currentLife == 1)
        {
            image.sprite = oneLife;
        }
    }
}
