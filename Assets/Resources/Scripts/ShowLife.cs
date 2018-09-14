using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour {

    public Life life;

    public GameObject heartPrefab;
    public Sprite coloredHeart;
    public Sprite greyHeart;

	void Start () {
        GenerateImages();
	}
	
	void Update () {
        GenerateImages();
	}

    private void GenerateImages()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }

        for(int x = 0; x < life.currentLife; x++)
        {
            GameObject newHeart = Instantiate(heartPrefab, transform);
            newHeart.GetComponent<Image>().sprite = coloredHeart;
        }

        for (int x = 0; x < life.maximumLife - life.currentLife; x++)
        {
            GameObject newHeart = Instantiate(heartPrefab, transform);
            newHeart.GetComponent<Image>().sprite = greyHeart;
        }
    }
}
