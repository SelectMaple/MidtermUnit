using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace Midterm
{
    public class UIManager : MonoBehaviour
    {
        // - Health text and Game Over Panel
        [Header("Health and Game Over")]
        [SerializeField] TMP_Text healthDisplay;
        [SerializeField] GameObject healthObject;
        [SerializeField] GameObject gameOverPanel;

        // - Level Text
        [Header("Level")]
        [SerializeField] TMP_Text levelPanel;
        [SerializeField] TMP_Text levelEnd;

        [Header("Menu")]
        [SerializeField] GameObject restart;
        [SerializeField] GameObject tryAgain;

        [Header("Game End")]
        [SerializeField] GameObject gameEnd;
  

        [Header("Player Health")]
        // - reference to health script
        public Health playerHealth;

        void Awake()
        {
            // - subscribed to the health script on HealthChange and death events
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
            restart.SetActive(true);
            healthObject.SetActive(false);

        }

        public void ShowLevel(string levelName)
        {
            levelPanel.gameObject.SetActive(true);
            levelPanel.text = levelName;

            StopAllCoroutines();
            StartCoroutine(HideLevelUI());
        }

        public void ShowGameEnd()
        {
            gameEnd.SetActive(true);
            tryAgain.SetActive(true);
            healthObject.SetActive(false);
        }


        public void EndLevel()
        {
            levelEnd.gameObject.SetActive(true);
            levelEnd.text = "Level Completed!";

            StopAllCoroutines();
            StartCoroutine(HideEndLevel());
        }

        IEnumerator HideLevelUI()
        {
            yield return new WaitForSeconds(5f);
            levelPanel.gameObject.SetActive(false);
            
        }

        IEnumerator HideEndLevel()
        {
            yield return new WaitForSeconds(2f);
            levelEnd.gameObject.SetActive(false);
        }

    }
}
