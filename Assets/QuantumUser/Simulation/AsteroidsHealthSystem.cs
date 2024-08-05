using Photon.Deterministic;

namespace Quantum.Asteroids
{
    public unsafe class AsteroidsHealthSystem : SystemSignalsOnly
    {
        //public struct Filter
        //{
        //    public EntityRef Entity;
        //    public AsteroidHealth* Health;
        //}

        public void TakeDamaged(Frame f, EntityRef entityRef,FP currentHealth, FP damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die(f, entityRef);
            }
        }

        private void Die(Frame f, EntityRef entityRef)
        {
            f.Destroy(entityRef);
        }

    }
}
