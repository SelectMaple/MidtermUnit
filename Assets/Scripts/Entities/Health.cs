using System;
using UnityEngine;

namespace Midterm
{
    public class Health : MonoBehaviour
    {
        public float currentHealth = 100f;

        public event Action<float> OnHealthChanged;
        public event Action OnDeath;

        void Start()
        {
            bool isSubscribed = (OnHealthChanged != null);

            if (isSubscribed)
            {
                OnHealthChanged.Invoke(currentHealth);
            }

            
        }

        
        public void TakeDamage(float amount)
        {
            // - reduces health by amount
            currentHealth -= amount;

            // - invoke the OnHealthChanged event to notify subscribers of the health change
            OnHealthChanged?.Invoke(currentHealth);

            // - Death 
            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public void Die()
        {
            OnDeath?.Invoke();

            if (gameObject.CompareTag("Player"))
            {
                Debug.Log("Player has died!");
                GameManager.instance.OnGameOver();
            }

            if (gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy has died!");
            }
            
            if (gameObject.CompareTag("Buddy"))
            {
                Debug.Log("Buddy has died!");
            }
        }
    }
}
