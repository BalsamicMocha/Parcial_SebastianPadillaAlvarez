using UnityEngine;
using Managers;

    public class GameManager : MonoBehaviour
    {
    public static GameManager Instance { get; private set; }
    [Header("Tiempo")]
    [Tooltip("Tiempo inicial")]
    public float timeRemaining = 10f;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        UIManager.Instance.UpdateTimer(timeRemaining);
        
        if (timeRemaining <= 0)
        {
            RestartGame();
        }
    }
    
    public void AddTime(float t)
    {
        timeRemaining += t;
    }
    
    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Parcial");
    }
}