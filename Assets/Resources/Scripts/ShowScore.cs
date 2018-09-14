using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

    public Score score;

    private Text text;
    
	void Start () {
        text = GetComponent<Text>();

        SetText();
	}
	
	void Update () {
        SetText();
	}

    private void SetText()
    {
        text.text = "Score: " + score.value.ToString();
    }
}
