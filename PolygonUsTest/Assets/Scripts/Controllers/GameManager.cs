using UnityEngine;

namespace Polygonus
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Awake() => instance = this;

        public void StartGame()
        {
            GetComponent<EnemySpawner>().enabled = true;
        }


        public void LoseGame()
        {
            GetComponent<EnemySpawner>().enabled = true;
        }

    }
}
