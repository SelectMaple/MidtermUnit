using System.Collections.Generic;
using UnityEngine;

namespace Midterm
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance; 

        // - Two lists for Object Pooling: 1 in use, 1 available
        public List<PooledObject> bulletPool = new List<PooledObject> ();
        public List<PooledObject> usedBulletPool = new List<PooledObject> ();

        public List<PooledObject> rocketPool = new List<PooledObject> ();
        public List<PooledObject> usedRocketPool = new List<PooledObject> ();

        // - OBJECT POOLING CHALLENGE:
        // - Create a two object pools specifically for rockets and bullets.  Modify your GetPooledObjects method to grab from either using a parameter.

        // - Object Pool Count
        [SerializeField] int numberOfObjects = 5;

        // - reference object to create
        public GameObject bulletPrefab;
        public GameObject rocketPrefab;


        void Awake()
        {
            // - Singleton pattern
            if (Instance != null)
            {
                Destroy(this.gameObject);
            }
            else if (Instance == null)
            {
                Instance = this;
            }

            // - initialize our object pool
            Initialize();
            
        }

        public void Initialize()
        {
            // - create X objects and add them to the pool
            for (int i = 0; i < numberOfObjects; i++)
            {
                AddNewObject(PoolType.Bullet);
                AddNewObject(PoolType.Rocket);

            }
        }

        public void AddNewObject(PoolType poolType)
        {

            GameObject projectilePrefab; 

            if (poolType == PoolType.Bullet)
            {
                projectilePrefab = bulletPrefab;
            }
            else
            {
                projectilePrefab = rocketPrefab;
            }

            GameObject newObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // - Set object pool reference in the pooled object so it can return itself when "destroyed"
            PooledObject pooledObject = newObject.GetComponent<PooledObject>();

            pooledObject.SetObjectPool(this);

            // set the object pool
            newObject.SetActive(false);

            if (poolType == PoolType.Bullet)
            {
                bulletPool.Add(pooledObject);
            }
            else
            {
                rocketPool.Add(pooledObject);
            }


            
        }

        public PooledObject GetPooledObject(PoolType poolType)
        {
            List<PooledObject> availablePool;
            List<PooledObject> usedPool;

            if (poolType == PoolType.Bullet)
            {
                availablePool = bulletPool;
                usedPool = usedBulletPool;
            }
            else
            {
                availablePool = rocketPool;
                usedPool = usedRocketPool;
            }

            // if there are any objects that we can grab from out available pool
            if (availablePool.Count > 0)
            {
                PooledObject pooledObject = availablePool[0];

                availablePool.RemoveAt(0);
                usedPool.Add(pooledObject);

                pooledObject.gameObject.SetActive(true);

                return pooledObject;
            }

            else
            {
                Debug.Log("NO POOLED OBJECT");
                return null;
            }
        }

        public void RestoreObject(PooledObject pooledObject)
        {
            if (usedBulletPool.Contains(pooledObject))
            {
                usedBulletPool.Remove(pooledObject);
                bulletPool.Add(pooledObject);
            }
            else if (usedRocketPool.Contains(pooledObject))
            {
                usedRocketPool.Remove(pooledObject);
                rocketPool.Add(pooledObject);
            }

            // - set the object back to inactive
            pooledObject.gameObject.SetActive(false);
        }

        public enum PoolType
        {
            Bullet,
            Rocket,
        }
    }
}
