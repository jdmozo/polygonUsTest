using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polygonus
{
    public class CameraColorChanger : MonoBehaviour
    {
        [SerializeField] private float animationDuration = 1f;
        [SerializeField] private int colorSteps = 10;
        [SerializeField] private bool loopable = true;
        [SerializeField] private bool customColors = true;
        private Camera cameraComponent;
        private int currentIndex = 0;
        [SerializeField] private Color[] rainbowColors;

        private void Start()
        {
            cameraComponent = GetComponent<Camera>();
            GenerateColors();
            StartCoroutine(ChangeCameraColorCoroutine());
        }

        // Coroutine for changing the camera background color
        private IEnumerator ChangeCameraColorCoroutine()
        {
            while (true)
            {
                int nextIndex = (currentIndex + 1) % rainbowColors.Length;
                Color nextColor = rainbowColors[nextIndex];

                // Use LeanTween to animate the color change
                LeanTween.value(gameObject, cameraComponent.backgroundColor, nextColor, animationDuration)
                    .setOnUpdate((Color color) =>
                    {
                        cameraComponent.backgroundColor = color;
                    })
                    .setOnComplete(() =>
                    {
                        currentIndex = nextIndex;
                    });

                yield return new WaitForSeconds(animationDuration);
            }
        }

        // Generates the rainbow colors based on the number of steps
        private void GenerateRainbowColors()
        {
            rainbowColors = new Color[colorSteps];
            float stepSize = 1f / colorSteps;

            for (int i = 0; i < colorSteps; i++)
            {
                float hue = i * stepSize;
                rainbowColors[i] = Color.HSVToRGB(hue, 1f, 1f);
            }
        }

        /// <summary>
        /// Generate With the custom Colors the 
        /// </summary>
        private void GenerateColors()
        {
            if (!customColors)
                GenerateRainbowColors();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        // Custom structure to hold a list of colors
        public struct ColorList
        {
            public List<Color> colors;
        }
    }
}
