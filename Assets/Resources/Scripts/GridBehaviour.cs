using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GridBehaviour : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject playerPrefab;

    public Score score;
    public Life life;
    public Life goldLife;

    public int goldLifeRequiredPoints;

    public CardType[] cardTypesToUse;
    List<CardType> weightedList;

    private CardType[,] cards;
    private int playerPositionX;
    private int playerPositionY;

    private System.Random random;
    
	void Start () {
        random = new System.Random();
        cards = new CardType[3,5];

        playerPositionX = 2;
        playerPositionY = 1;

        weightedList = new List<CardType>();
        foreach (CardType cardType in cardTypesToUse)
        {
            for (int x = 0; x < cardType.weight; x++)
            {
                weightedList.Add(cardType);
            }
        }

        SetCards(null);
        PlaceCards();
	}

    private void HandleCardUsage(int y, int x)
    {
        int scoreBeforeCardUsage = score.value;

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
                if (life.currentLife == 0)
                {
                    if(goldLife.currentLife == 1)
                    {
                        goldLife.currentLife = 0;
                        life.currentLife = 3;
                    } else
                    {
                        int highscore = PlayerPrefs.GetInt("highscore", 0);
                        if (score.value > highscore)
                        {
                            PlayerPrefs.SetInt("highscore", score.value);
                        }

                        SceneManager.LoadScene("RestartOrExit");
                    }
                }
            }
            else if (pressedCard.id == CardTypeId.LIFE)
            {
                life.currentLife += 1;
                if (life.currentLife > life.maximumLife) life.currentLife = life.maximumLife;
            }
            else if(pressedCard.id == CardTypeId.GOLD_LIFE)
            {
                goldLife.currentLife += 1;
                if(goldLife.currentLife > goldLife.maximumLife) goldLife.currentLife = goldLife.maximumLife;
            }

            if (pressedCard.id == CardTypeId.BOMB)
            {
                playerPositionY = y;
                playerPositionX = x;
                SetCards(null);
            }
            else if (pressedCard.id == CardTypeId.BOMB_LIFES)
            {
                playerPositionY = y;
                playerPositionX = x;
                SetCards(CardTypeId.LIFE);
            } else
            {
                CardType newCardType;
                if (score.value % goldLifeRequiredPoints < scoreBeforeCardUsage % goldLifeRequiredPoints)
                {
                    newCardType = FindCardTypeById(CardTypeId.GOLD_LIFE);
                } else
                {
                    newCardType = weightedList.ElementAt(random.Next(0, weightedList.Count));
                }

                
                cards[playerPositionY, playerPositionX] = newCardType;

                playerPositionY = y;
                playerPositionX = x;
                cards[y, x] = null;
            }

            PlaceCards();
        }
    }

    void SetCards(CardTypeId? cardTypeId)
    {
        for (int y = 0; y < cards.GetLength(0); y++)
        {
            for (int x = 0; x < cards.GetLength(1); x++)
            {
                if (x == playerPositionX && y == playerPositionY)
                {
                    cards[y, x] = null;
                }
                else
                {
                    CardType newCardType;
                    if(cardTypeId == null)
                    {
                        newCardType = weightedList.ElementAt(random.Next(0, weightedList.Count));
                    } else
                    {
                        newCardType = FindCardTypeById((CardTypeId) cardTypeId);
                    }

                    cards[y, x] = newCardType;
                }
            }
        }
    }

    private CardType FindCardTypeById(CardTypeId id)
    {
        return Array.Find(cardTypesToUse, entry =>
        {
            return entry.id == id;
        });
    }

    void PlaceCards()
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
