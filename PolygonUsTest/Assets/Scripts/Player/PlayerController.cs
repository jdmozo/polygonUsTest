using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polygonus
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float followSpeed = 5f;
        [SerializeField] private float moveSpeed = 10f;

        private bool isMovingToCursor = false;
        private Vector3 targetPosition;

        private void Update()
        {
            // Follow the mouse cursor
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Calculate the direction to rotate towards the mouse cursor
            Vector3 directionToCursor = targetWorldPosition - transform.position;
            float angle = Mathf.Atan2(directionToCursor.y, directionToCursor.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Move to the cursor position on right mouse button press
            if (Input.GetMouseButton(1))
            {
                targetPosition = targetWorldPosition;
                isMovingToCursor = true;
            }

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
