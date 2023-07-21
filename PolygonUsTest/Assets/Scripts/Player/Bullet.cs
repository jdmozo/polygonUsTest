using UnityEngine;

namespace Polygonus
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 2f;
        public int damage = 10;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the bullet collides with an object that can take damage
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
            }

            // Destroy the bullet on collision with any object
            Destroy(gameObject);
        }
    }
}
