using UnityEngine;

namespace Polygonus
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform shootPoint;
        public float shootForce = 10f;
        public float shootRate = 0.5f; // The time between consecutive shots
        public AudioClip _shoot;


        private float timeSinceLastShot = 0f; // Keep track of the time since the last shot

        private void Update()
        {
            // Check if enough time has passed since the last shot to allow shooting again
            if (timeSinceLastShot >= shootRate)
            {
                if (Input.GetButtonDown("Fire1")) // Fire1 is the default input for left mouse button
                {
                    Shoot();
                    timeSinceLastShot = 0f; // Reset the time since the last shot
                    AudioController.instance.PlaySFX(_shoot);
                }
            }

            // Increment the time since the last shot
            timeSinceLastShot += Time.deltaTime;
        }

        private void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, gameObject.transform.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.gravityScale = 0;
            bulletRigidbody.AddForce(transform.right * shootForce, ForceMode2D.Impulse);
        }
    }
}

