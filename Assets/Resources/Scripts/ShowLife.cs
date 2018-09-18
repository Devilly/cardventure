using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour {

    public Life life;
    
    public Sprite coloredHeart;
    public Sprite greyHeart;

    private Image image;

    [Range(1, 3)]
    public int onFromHowManyLifes;

	void Start () {
        image = GetComponent<Image>();

        SetImage();
	}
	
	void Update () {
        SetImage();
	}

    private void SetImage()
    {
        if(life.currentLife >= onFromHowManyLifes)
        {
            image.sprite = coloredHeart;
        } else
        {
            image.sprite = greyHeart;
        }
    }
}
