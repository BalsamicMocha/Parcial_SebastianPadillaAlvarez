using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        [Header("Contadores")]
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI timerText;

        private int puntos = 0;

        void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddScore(int amount)
        {
            puntos += amount;
            scoreText.text = $"Puntaje: {puntos}";
        }

        public void UpdateTimer(float time)
        {
            timerText.text = $"Tiempo restante: {Mathf.CeilToInt(time)}";
        }
    }
}