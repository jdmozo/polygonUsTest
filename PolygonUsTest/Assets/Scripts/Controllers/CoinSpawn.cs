using UnityEngine;
using System.Collections;

namespace Polygonus
{
    public class CoinSpawn : MonoBehaviour
    {
        public static CoinSpawn instance;
        [SerializeField] private GameObject coinPrefab;

        private void Awake() => instance = this;

        private void Start() => StartCoroutine(SpawnCoins());

        public void CreateNewCoin() => StartCoroutine(SpawnCoins());

        private IEnumerator SpawnCoins()
        {
            // Generate a random position within the screen bounds
            Vector3 randomPosition = new Vector3(Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x),
                                                    Random.Range(Camera.main.ScreenToWorldPoint(Vector3.zero).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y),
                                                    0f);

            // Instantiate the coin prefab at the random position
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next coin
            yield return null;
        }
    }
}
