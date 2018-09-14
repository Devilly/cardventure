using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "cardventure/Score")]
public class Score : ScriptableObject
{
    public int value;

    public void Reset()
    {
        value = 0;
    }
}
