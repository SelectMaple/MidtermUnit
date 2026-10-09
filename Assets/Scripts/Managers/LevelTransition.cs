using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Midterm
{
    public class LevelTransition : MonoBehaviour
    {
        [SerializeField] string currentLevelName;
        [SerializeField] GameManager.GameState levelState;
        public PlayableDirector director;
        public LevelManager levelManager;
        public UIManager uiManager;

        void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Player"))
            {

                GameManager.instance.currentLevel = levelManager;

                if (uiManager != null && levelState == GameManager.GameState.LevelStart)
                {
                    uiManager.ShowLevel(currentLevelName);
                }

                if (uiManager != null && levelState == GameManager.GameState.LevelEnd)
                {
                    uiManager.EndLevel();
                }

                if (uiManager != null && levelState == GameManager.GameState.GameEnd)
                {
                    uiManager.ShowGameEnd();
                    GameManager.instance.OnGameEnd();
                }

                Debug.Log("Level is transitioning");
                Debug.Log("Loading Level: " + currentLevelName);

                if (director != null)
                {
                    director.Play();
                }
        
                // - any other behaviour for level transition

                gameObject.SetActive(false);

                
            }
        }
    }
}
