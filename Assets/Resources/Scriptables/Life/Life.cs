using UnityEngine;

[CreateAssetMenu(fileName = "Life", menuName = "cardventure/Life")]
public class Life : ScriptableObject {
    public int defaultLife;

    public int maximumLife;
    public int currentLife;

    public void Reset()
    {
        currentLife = defaultLife;
    }
}
