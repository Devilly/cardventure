using UnityEngine;

[CreateAssetMenu(fileName = "Life", menuName = "cardventure/Life")]
public class Life : ScriptableObject {
    private readonly int defaultLife = 3;

    public int maximumLife = 3;
    public int currentLife = 3;

    public void Reset()
    {
        currentLife = defaultLife;
        maximumLife = defaultLife;
    }
}
