using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetState : MonoBehaviour {

    public Life life;
    public Life goldLife;
    public Score score;

	void Start () {
        life.Reset();
        goldLife.Reset();
        score.Reset();
	}
}
