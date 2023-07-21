using UnityEngine;

namespace Polygonus
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int points = 5;
        [SerializeField] private AudioClip _audioCoin;
        private void Start()
        {
            CoinIndicator.Instance.targetObject = gameObject.transform;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                IPointSystem pointSystem = other.GetComponent<IPointSystem>();
                if (pointSystem != null)
                    pointSystem.SetPoints(points);

                PointsManager.Instance.AddPoints(points);
                CoinSpawn.instance.CreateNewCoin();
                AudioController.instance.PlaySFX(_audioCoin);

                Destroy(gameObject);
            }
        }
    }
}
