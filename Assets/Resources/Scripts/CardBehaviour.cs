using UnityEngine;
using System;

public class CardBehaviour : MonoBehaviour {

    public Action<int, int> callOnUsage;

    public int x;
    public int y;

    public void UseCard()
    {
        callOnUsage(y, x);
    }
}
