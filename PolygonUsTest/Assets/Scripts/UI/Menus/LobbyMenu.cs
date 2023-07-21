using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Polygonus
{
    public class LobbyMenu : MonoBehaviour
    {
        [SerializeField] private float _moveDuration = 1.0f;
        [SerializeField] private AudioClip _startLobby;
        private bool menuIsActive = true;

        private void Start()
        {
            AudioController.instance.PlayMusic(_startLobby);
            StartCoroutine(MoveMenuCoroutine());
        }

        private IEnumerator MoveMenuCoroutine()
        {
            // Wait for the space key to be pressed
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            // Disable the menu to prevent multiple calls
            menuIsActive = false;

            // Move the menu up using LeanTween
            LeanTween.moveY(gameObject, Screen.height, _moveDuration).setOnComplete(OnMoveComplete);
            GameManager.instance.StartGame();

        }

        private void OnMoveComplete()
        {
            // Set the menu to inactive and start the game
            gameObject.SetActive(false);
        }
    }
}
