using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour {

    public Score score;
    public Life life;

    public CardType[] cardTypesToUse;
    private CardType currentCardType;

    public System.Random random;

    void Start()
    {
        SetCard();
    }

    private void SetCard()
    {
        CardType newCardType = cardTypesToUse[random.Next(0, cardTypesToUse.Length)];
        currentCardType = newCardType;

        GetComponent<Image>().sprite = newCardType.sprite;
    }

    public void UseCard()
    {
        if(currentCardType.id == CardTypeId.PLUSONE)
        {
            score.value += 1;
        } else if(currentCardType.id == CardTypeId.PLUSTWO)
        {
            score.value += 2;
        } else if(currentCardType.id == CardTypeId.POISON)
        {
            life.currentLife -= 1;
            if (life.currentLife == 0) SceneManager.LoadScene("Navigational");
        } else if(currentCardType.id == CardTypeId.LIFE)
        {
            life.currentLife += 1;
            if (life.currentLife > life.maximumLife) life.currentLife = life.maximumLife;
        }

        SetCard();
    }
}
