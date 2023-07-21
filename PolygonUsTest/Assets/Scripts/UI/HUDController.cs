using TMPro;
using UnityEngine;

namespace Polygonus
{
    public class HUDController : MonoBehaviour
    {
        public static HUDController instance;

        [SerializeField] private TMP_Text _pointsText;

        private void Awake() => instance = this;

        public void UpdatePoints()
        {
            _pointsText.text = $"Points: {PointsManager.Instance.GlobalPoints}";
        }
    }
}
