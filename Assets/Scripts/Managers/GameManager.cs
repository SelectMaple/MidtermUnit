using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Playables;

namespace Midterm
{
    public class GameManager : MonoBehaviour
    {
        // - Game States
        public enum GameState
        {
            Paused,
            GameIntro,
            GameStart,
            GamePlaying,
            GameOver,
            GameEnd,
            LevelStart,
            LevelEnd,

        }
        public GameState currentGameState = GameState.GameIntro;

        // - Singleton Pattern
        public static GameManager instance = null;

        // - reference to camera
        public Camera playerCamera = null;

        // - Level Managers
        public LevelManager currentLevel;

        // - Key card
        public bool hasKeyCard = false;

        void Awake()
        {
            // - Singleton Pattern
            if (instance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                instance = this;
            }
        }

        public void ChangeState(GameState newState)
        {
            currentGameState = newState;

            switch (newState)
            {
                case GameState.GameIntro:
                    OnGameIntro();
                    break;
                case GameState.GameStart:
                    OnGameStart();
                    break;
                case GameState.GameOver:
                    OnGameOver();
                    break;
                case GameState.GameEnd:
                    OnGameEnd();
                    break;
                case GameState.LevelStart:
                    OnLevelStart();
                    break;
                case GameState.LevelEnd:
                    OnLevelEnd();
                    break;
                case GameState.Paused:
                    OnPaused();
                    break;
                case GameState.GamePlaying: 
                    OnGamePlaying();
                    break;
            }
        }

        void Start()
        {
            Debug.Log("GameManager Started");
            ChangeState(GameState.GameStart);
        }

        void Update()
        {
            if (PlayerInput.Instance.escPressed)
            {
                if (currentGameState  == GameState.Paused)
                {
                    ChangeState(GameState.GamePlaying);
                }

                else if (currentGameState == GameState.GamePlaying)
                {
                    ChangeState(GameState.Paused);
                }
            }
        }
        
        // - Signals/Events for Cinematic Start/End
        public void CinematicStart()
        {
            Debug.Log("Cinematic Started");
            ChangeState(GameManager.GameState.LevelStart);
        }

        public void CinematicEnded()
        {
            Debug.Log("Cinematic Ended");
            playerCamera.transform.localPosition = new Vector3(0, 0.5f, 0.5f);
            ChangeState(GameManager.GameState.GamePlaying);
        }

        void OnGameIntro()
        {
            Debug.Log("Game Intro State");
        }

        void OnGameStart()
        {
            // - do whatever we need when the game "starts"
            Debug.Log("Game Start State");

            // - Initialize whatever i need to initialize for the game to be playable
          //  playerCamera.enabled = false;
          //  cinematicCamera.enabled = true;

            //- once it is all done, begin playing
            ChangeState(GameState.GamePlaying);
        }
        void OnGameOver()
        {
            Debug.Log("Game Over State");
            Time.timeScale = 0f;
            // - handles logic when players loses/ dies/ runs at a time
        }
        void OnGameEnd()
        {
            Debug.Log("Game End State");
            Time.timeScale = 0f;
            // - when we finish a level / hit ending cutscene
        }
        void OnLevelStart()
        {
            Debug.Log("Level Start State");
            // - Start cinematics/ instructions/ tutorials
            currentLevel.LevelStart();
           
        }
        void OnLevelEnd()
        {
            Debug.Log("Level End State");
            // - logic that pertains to overarching game experience
            // - calculating score, determining if player won or lose
            // - figuring out the next level/ what scene go to next

            currentLevel.LevelEnd();
        }
        void OnPaused()
        {
            Debug.Log("Game Paused");
            Time.timeScale = 0f; // "pause the game"

        }
        void OnGamePlaying()
        {
            Debug.Log("Game is playing");
            Time.timeScale = 1f;
        }


        // -- Scenes/ Levels
        // - Title Screen
        // - Level 1
        // - Level 2
        // - Level 3

        // -- Game States
        // - Pause
        // - Game Over
        // - OnGameStart
        // - OnGameEnd


    }
}
