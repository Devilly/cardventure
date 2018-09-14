using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillGrid : MonoBehaviour {

    public GameObject cardPrefab;
    
    private System.Random random;

    [ExecuteInEditMode]
	void Start () {
        random = new System.Random();

        for (int x = 0; x < 15; x++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform);
            newCard.GetComponent<CardBehaviour>().random = random;
        }
	}
}
