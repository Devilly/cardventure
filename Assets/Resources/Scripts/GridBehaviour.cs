using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GridBehaviour : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject playerPrefab;

    public Score score;
    public Life life;

    public CardType[] cardTypesToUse;
    List<CardType> weightedList;

    private CardType[,] cards;
    private int playerPositionX;
    private int playerPositionY;

    private System.Random random;
    
	void Start () {
        random = new System.Random();
        cards = new CardType[3,5];

        playerPositionX = 0;
        playerPositionY = 0;

        weightedList = new List<CardType>();
        foreach (CardType cardType in cardTypesToUse)
        {
            for (int x = 0; x < cardType.weight; x++)
            {
                weightedList.Add(cardType);
            }
        }

        for (int y = 0; y < cards.GetLength(0); y++)
        {
            for (int x = 0; x < cards.GetLength(1); x++)
            {
                if (x == playerPositionX && y == playerPositionY) {
                    cards[y, x] = null;
                } else
                {
                    CardType newCardType = weightedList.ElementAt(random.Next(0, weightedList.Count));
                    cards[y, x] = newCardType;
                }
            }
        }

        SetCards();
	}

    private void HandleCardUsage(int y, int x)
    {
        if ((System.Math.Abs(x - playerPositionX) == 1 && System.Math.Abs(y - playerPositionY) == 0) ||
            (System.Math.Abs(x - playerPositionX) == 0 && System.Math.Abs(y - playerPositionY) == 1))
        {
            CardType pressedCard = cards[y, x];

            if (pressedCard.id == CardTypeId.PLUSONE)
            {
                score.value += 1;
            }
            else if (pressedCard.id == CardTypeId.PLUSTWO)
            {
                score.value += 2;
            }
            else if (pressedCard.id == CardTypeId.POISON)
            {
                life.currentLife -= 1;
                if (life.currentLife == 0) SceneManager.LoadScene("Navigational");
            }
            else if (pressedCard.id == CardTypeId.LIFE)
            {
                life.currentLife += 1;
                if (life.currentLife > life.maximumLife) life.currentLife = life.maximumLife;
            }

            CardType newCardType = weightedList.ElementAt(random.Next(0, weightedList.Count));
            cards[playerPositionY, playerPositionX] = newCardType;

            playerPositionY = y;
            playerPositionX = x;
            cards[y, x] = null;

            SetCards();
        }
    }

    void SetCards()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }

        for (int y = 0; y < cards.GetLength(0); y++)
        {
            for (int x = 0; x < cards.GetLength(1); x++)
            {
                if(cards[y, x] == null)
                {
                    Instantiate(playerPrefab, transform);
                } else
                {
                    AddCard(cards[y, x], y, x);
                }
            }
        }
    }

    private void AddCard(CardType cardType, int y, int x)
    {
        GameObject newCard = Instantiate(cardPrefab, transform);
        newCard.GetComponent<CardBehaviour>().callOnUsage = HandleCardUsage;
        newCard.GetComponent<CardBehaviour>().y = y;
        newCard.GetComponent<CardBehaviour>().x = x;
        newCard.GetComponent<Image>().sprite = cardType.sprite;
    }
}
