using UnityEngine;

namespace Polygonus
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private AudioClip _audioStart;

        private bool isMovingToCursor = false;
        private Vector3 targetPosition;
        public ShipData currentShip;


        private void Start()
        {
            AudioController.instance.PlaySFX(_audioStart);
        }

        private void Update() => MouseFollower();

        private void MouseFollower()
        {
            // Follow the mouse cursor
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 targetWorldToScreen = Camera.main.WorldToScreenPoint(transform.position);

            // Calculate the direction to rotate towards the mouse cursor
            Vector3 directionToCursor = mousePosition - targetWorldToScreen;
            float angle = Mathf.Atan2(directionToCursor.y, directionToCursor.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Move to the cursor position on right mouse button press
            if (Input.GetMouseButton(1))
            {
                targetPosition = targetWorldPosition;
                isMovingToCursor = true;
            }

            if (Input.GetMouseButtonUp(1))
                isMovingToCursor = false;

            // Move towards the cursor position using MoveTowards
            if (isMovingToCursor)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                // Check if close enough to the target position
                if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
                {
                    isMovingToCursor = false;
                }
            }
        }
    }
}
