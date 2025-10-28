using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int leftScore = 0;
    public int rightScore = 0;
    public UIManager uiManager;
    public float goalX = 9.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ScoreLeft()
    {
        leftScore++;
        if (uiManager != null) { 
            uiManager.UpdateScore(leftScore, rightScore); 
        }
        ResetBall();
    }

    public void ScoreRight()
    {
    rightScore++;
    if (uiManager != null)
    {
        uiManager.UpdateScore(leftScore, rightScore);
    }
    ResetBall();
    }

    public void ResetBall()
    {
        Ball ball = FindAnyObjectByType<Ball>();
        if (ball != null) { 
            ball.ResetBall(); 
        }
    }
}
