using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Polygonus
{
    public class LobbyMenu : MonoBehaviour
    {
        [SerializeField] private float _moveDuration = 1.0f;
        private bool menuIsActive = true;

        private void Update()
        {
            // Check if the menu is active and the space key is pressed
            if (menuIsActive && Input.GetKeyDown(KeyCode.Space))
            {
                // Disable the menu to prevent multiple calls
                menuIsActive = false;

                // Move the menu up using LeanTween
                StartCoroutine(MoveMenuCoroutine());
            }
            
        }

        private IEnumerator MoveMenuCoroutine()
        {
            // Wait for the space key to be pressed
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            // Disable the menu to prevent multiple calls
            menuIsActive = false;

            // Move the menu up using LeanTween
            LeanTween.moveY(gameObject, Screen.height, _moveDuration).setOnComplete(OnMoveComplete);
        }

        private void OnMoveComplete()
        {
            // Set the menu to inactive and start the game
            gameObject.SetActive(false);
            GameManager.instance.StartGame();
        }
    }
}
