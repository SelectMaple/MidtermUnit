using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Midterm
{
    public class UIManager : MonoBehaviour
    {
        public TMP_Text healthDisplay;
        public GameObject gameOverPanel;

        public Health playerHealth;

        void Awake()
        {
            playerHealth.OnHealthChanged += UpdateHealthDisplay;
            playerHealth.OnDeath += ShowGameOver;
        }

        // - Update health text
        public void UpdateHealthDisplay(float currentHealth)
        {
            healthDisplay.text = "Health: " + currentHealth.ToString("F0");
        }

        // - Show hidden game over panel
        public void ShowGameOver()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
