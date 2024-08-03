using Photon.Deterministic;

namespace Quantum.Asteroids
{
    public unsafe class AsteroidsWaveSpawnerSystem : SystemSignalsOnly
    {
        public override void OnInit(Frame f)
        {
            SpawnAsteroidWave(f);
        }

        public void SpawnAsteroid(Frame f, AssetRef<EntityPrototype> childPrototype)
        {
            AsteroidsGameConfig config = f.FindAsset(f.RuntimeConfig.GameConfig);
            EntityRef asteroid = f.Create(childPrototype);
            Transform2D* asteroidTransform = f.Unsafe.GetPointer<Transform2D>(asteroid);

            asteroidTransform->Position = GetRandomEdgePointOnCircle(f, config.AsteroidSpawnDistanceToCenter);
            asteroidTransform->Rotation = GetRandomRotation(f);

            if (f.Unsafe.TryGetPointer<PhysicsBody2D>(asteroid, out var body))
            {
                body->Velocity = asteroidTransform->Up * config.AsteroidInitialSpeed;
                body->AddTorque(f.RNG->Next(config.AsteroidInitialTorqueMin, config.AsteroidInitialTorqueMax));
            }
        }

        public static FP GetRandomRotation(Frame f)
        {
            return f.RNG->Next(0, 360);
        }

        public static FPVector2 GetRandomEdgePointOnCircle(Frame f, FP radius)
        {
            return FPVector2.Rotate(FPVector2.Up * radius, f.RNG->Next() * FP.PiTimes2);
        }

        private void SpawnAsteroidWave(Frame f)
        {
            AsteroidsGameConfig config = f.FindAsset(f.RuntimeConfig.GameConfig);
            for (int i = 0; i < f.Global->AsteroidsWaveCount + config.InitialAsteroidsCount; i++)
            {
                SpawnAsteroid(f, config.AsteroidPrototype);
            }

            f.Global->AsteroidsWaveCount++;
        }
    }
}