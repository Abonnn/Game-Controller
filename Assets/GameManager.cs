using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Komponen UI")]
    public TextMeshProUGUI killCountText; 
    public TextMeshProUGUI timerText; 
    private int enemiesKilled = 0;
    private float survivalTime = 0f;
    private bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        enemiesKilled = 0;
        survivalTime = 0f;
        UpdateUI();
    }

    void Update()
    {
        if (!isGameOver)
        {
            survivalTime += Time.deltaTime;
            UpdateUI();
        }
    }
    public void AddKill()
    {
        enemiesKilled++;
    }

    public void StopGame()
    {
        isGameOver = true;
    }
    private void UpdateUI()
    {
        if (killCountText != null)
    {
        killCountText.text = "Destroy: " + enemiesKilled;
    }

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(survivalTime / 60);
            int seconds = Mathf.FloorToInt(survivalTime % 60);
        
            timerText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}