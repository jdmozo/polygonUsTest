using UnityEngine;

namespace Polygonus
{
    public class PlayerShooter : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform shootPoint;
        public float shootForce = 10f;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1")) // Fire1 is the default input for left mouse button
            {
                Shoot();
            }
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
