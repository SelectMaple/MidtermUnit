using UnityEngine;
using UnityEngine.Events;

namespace Midterm
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] UnityEvent OnLevelStart;
        [SerializeField] UnityEvent OnLevelEnd;

        public void LevelStart()
        {
            OnLevelStart?.Invoke();
        }

        public void LevelEnd()
        {
            OnLevelEnd?.Invoke();
        }
    }
}
