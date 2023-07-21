using UnityEngine;

namespace Polygonus
{
    public class PointsManager : MonoBehaviour
    {
        public static PointsManager Instance { get; private set; }
        public int GlobalPoints { get; private set; }

        private void Awake() => Instance = this;

        public void AddPoints(int points)
        {
            GlobalPoints += points;
            HUDController.instance.UpdatePoints();
        }
    }
}
