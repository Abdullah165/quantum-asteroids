using Photon.Deterministic;
using UnityEngine;

namespace Quantum
{
    public unsafe class AsteroidsShipConfig : AssetObject
    {
        [Tooltip("The speed that the ship turns with added as torque")]
        public FP ShipTurnSpeed = 8;

        [Tooltip("The speed that the ship accelerates using add force")]
        public FP ShipAceleration = 6;

        [Tooltip("Time interval between ship shots")]
        public FP FireInterval = FP._0_10;

        [Tooltip("Displacement of the projectile spawn position related to the ship position")]
        public FP ShotOffset = 1;

        public FP InitialMaxHealth = 100;
        public FP DamageAmount = 10;

        [Tooltip("Prototype reference to spawn ship projectiles")]
        public AssetRef<EntityPrototype> ProjectilePrototype;

        public void TakeDamage(Frame f, EntityRef entity, FP damage)
        {
            var ship = f.Unsafe.GetPointer<AsteroidsShip>(entity);
            ship->CurrentHealth -= damage;

            if (ship->CurrentHealth <= 0)
            {
                f.Destroy(entity);
            }
        }
    }
}