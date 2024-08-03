
namespace Quantum.Asteroids
{
    public class ShipSpawnSystem : SystemSignalsOnly, ISignalOnPlayerAdded
    {
        public void OnPlayerAdded(Frame frame,PlayerRef player, bool firstTime)
        {
            {
                RuntimePlayer data = frame.GetPlayerData(player);

                var entityPtototypeAsset = frame.FindAsset<EntityPrototype>(data.PlayerAvatar);

                var shipEntity = frame.Create(entityPtototypeAsset);

                frame.Add(shipEntity, new PlayerLink { PlayerRef = player });  
            }
        }
    }
}
