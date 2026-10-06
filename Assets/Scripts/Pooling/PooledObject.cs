using UnityEngine;

namespace Midterm
{
    public class PooledObject : MonoBehaviour
    {
        // - reference to the object pool that created this object
        ObjectPool poolReference;

        public void SetObjectPool(ObjectPool _pool)
        {
            // sets our reference to the object pool
            poolReference = _pool;
        }

        public void DestroyWithTime(float time)
        {
            // - calls our reset object method after a certain amount of time
            Invoke("ResetObject", time);
        }

        public void ResetObject()
        {
            // - returns the object to the object pool and sets it inactive
            poolReference.RestoreObject(this);
        }
    }
}
