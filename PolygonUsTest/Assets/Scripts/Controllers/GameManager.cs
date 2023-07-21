using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polygonus
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private ScoreboardMenu scoreboardMenu;
        [SerializeField] private GameObject player;
        [SerializeField] private AudioClip _startGame;

        public static GameManager instance;

        private void Awake() => instance = this;

        private void Start() => Time.timeScale = 1;

        public void StartGame()
        {
            AudioController.instance.PlayMusic(_startGame);
            player.gameObject.SetActive(true);
            GetComponent<EnemySpawner>().enabled = true;
            GetComponent<CoinSpawn>().enabled = true;
        }

        public void LoseGame()
        {
            scoreboardMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }
}
