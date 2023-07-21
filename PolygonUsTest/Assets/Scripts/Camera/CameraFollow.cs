using UnityEngine;
using UnityEngine.UI;

namespace Polygonus
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Image stars;

        private void LateUpdate()
        {
            if (playerTransform == null)
            {
                Debug.LogWarning("Player Transform is not set in CameraFollow script!");
                return;
            }

            // Camera follow logic
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);

            // Material offset logic
            stars.material.SetVector("_Offset", transform.position);
        }
    }
}
