using UnityEngine;

namespace Polygonus
{
    public class Enemy : MonoBehaviour, IDamageable, IPointSystem
    {
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private int enemyHealth = 1;
        private Transform playerTransform;
        public int enemyPoints = 5;

        private void Start() => playerTransform = GameObject.FindGameObjectWithTag("Player").gameObject.transform;

        private void Update()
        {
            if (playerTransform != null)
            {
                // Calculate the direction to the player
                Vector2 directionToPlayer = playerTransform.position - transform.position;
                // Normalize the direction vector to get a unit vector
                directionToPlayer.Normalize();
                // Move the enemy towards the player
                transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, 0) * moveSpeed * Time.deltaTime;

                // Rotate the enemy to face the player
                float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                GameManager.instance.LoseGame();
                Debug.Log("Lose");
            }
        }

        public void TakeDamage(int damageAmount)
        {
            enemyHealth -= damageAmount;
            if (enemyHealth == 0)
                Destroy(gameObject);
        }

        public void SetPoints(int points) => PointsManager.Instance.AddPoints(points);
    }
}
