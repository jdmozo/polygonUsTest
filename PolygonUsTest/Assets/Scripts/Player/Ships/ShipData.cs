using UnityEngine;

namespace Polygonus
{
    /// <summary>
    /// 
    /// </summary>
    [CreateAssetMenu(fileName = "ShipData", menuName = "Custom/ShipData")]
    public class ShipData : ScriptableObject
    {
        public Sprite weaponSprite;
        public float shootingRate = 0.5f;
        public float shootingForce = 10f;
        public float speed = 5f;
        public float bulletDamage = 1f;
    }
}
