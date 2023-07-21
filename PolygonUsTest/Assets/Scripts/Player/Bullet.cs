using UnityEngine;

namespace Polygonus
{
    public class Bullet : MonoBehaviour
    {
        public float lifeTime = 2f;
        public int damage = 1;
        public AudioClip _explotion;

        private void Start() => Destroy(gameObject, lifeTime);

        private void OnTriggerEnter2D(Collider2D other)
        {

            // Check if the bullet collides with an object that can take damage
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
                damageable.TakeDamage(damage);

            // Check if the bullet collided with an enemy
            if (other.CompareTag("Enemy"))
            {
                // Get the PointSystem component from the enemy and add points
                IPointSystem pointSystem = other.GetComponent<IPointSystem>();
                if (pointSystem != null)
                    pointSystem.SetPoints(other.GetComponent<Enemy>().enemyPoints);

                AudioController.instance.PlaySFX(_explotion);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }

            // Destroy the bullet on collision with any object
            Destroy(gameObject);
        }
    }
}
