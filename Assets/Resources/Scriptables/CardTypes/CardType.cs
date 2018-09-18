using UnityEngine;

[CreateAssetMenu(fileName = "CardType", menuName = "cardventure/CardType")]
public class CardType : ScriptableObject {
    public Sprite sprite;
    public int weight;
    public CardTypeId id;
}

public enum CardTypeId
{
    PLUSONE, PLUSTWO, POISON, LIFE, GOLD_LIFE, BOMB, BOMB_LIFES
}