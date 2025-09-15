using UnityEngine;
using TMPro;

public class PinballManager : MonoBehaviour
{

    [SerializeField]
    TMP_Text scoreText;

    int score = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddScore()
    {
        //add to score
        //do score effects maybe
        score++;
    }
}
