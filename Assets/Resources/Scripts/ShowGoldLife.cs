using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGoldLife : MonoBehaviour {

    public Life goldLife;

    public Sprite coloredHeart;
    public Sprite greyHeart;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        SetImage();
    }

    void Update()
    {
        SetImage();
    }

    private void SetImage()
    {
        if (goldLife.currentLife == 1)
        {
            image.sprite = coloredHeart;
        }
        else
        {
            image.sprite = greyHeart;
        }
    }
}
