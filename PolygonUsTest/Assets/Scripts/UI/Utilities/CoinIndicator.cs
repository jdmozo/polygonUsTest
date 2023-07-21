using UnityEngine;
using UnityEngine.UI;

namespace Polygonus
{
    public class CoinIndicator : MonoBehaviour
    {
        public static CoinIndicator Instance;
        [SerializeField] private Image indicatorImage;
        public Transform targetObject;

        private void Awake() => Instance = this;

        private void Update()
        {
            if (targetObject == null) return;

            // Check if the target object is outside of the screen
            Vector3 targetPositionViewport = Camera.main.WorldToViewportPoint(targetObject.position);
            bool isOutsideScreen = targetPositionViewport.x < 0 || targetPositionViewport.x > 1 || targetPositionViewport.y < 0 || targetPositionViewport.y > 1;

            // Show or hide the indicator based on the target object's position
            indicatorImage.gameObject.SetActive(isOutsideScreen);

            if (isOutsideScreen)
            {
                // Get the position of the target object in world space
                Vector3 targetPosition = targetObject.position;

                // Convert the target position to viewport coordinates
                targetPositionViewport = Camera.main.WorldToViewportPoint(targetPosition);

                // Clamp the viewport coordinates to the screen edges
                float clampedX = Mathf.Clamp(targetPositionViewport.x, 0.05f, 0.95f);
                float clampedY = Mathf.Clamp(targetPositionViewport.y, 0.05f, 0.95f);
                targetPositionViewport = new Vector3(clampedX, clampedY, targetPositionViewport.z);

                // Convert the viewport coordinates back to world space
                Vector3 indicatorPosition = Camera.main.ViewportToWorldPoint(targetPositionViewport);

                // Set the position of the indicator to the clamped world position
                indicatorImage.transform.position = indicatorPosition;

                // Calculate the rotation angle to make the indicator point towards the target
                Vector3 directionToTarget = targetPosition - Camera.main.transform.position;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                indicatorImage.transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
