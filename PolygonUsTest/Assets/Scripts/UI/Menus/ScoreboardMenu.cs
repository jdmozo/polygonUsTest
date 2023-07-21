using TMPro;
using UnityEngine;

namespace Polygonus
{
    public class ScoreboardMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text pointsText;

        private void OnEnable()
        {
            pointsText.text = $"{PointsManager.Instance.GlobalPoints}";
        }
    }
}
