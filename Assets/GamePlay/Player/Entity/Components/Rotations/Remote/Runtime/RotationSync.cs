using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Network.EntityHandler.Runtime;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using GamePlay.Player.Entity.Components.Rotations.Remote.Logs;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Runtime
{
    public class RotationSync : RagonProperty, IRotationSync, IRemoteRotation
    {
        protected RotationSync(
            IEntityProvider entityProvider,
            RemoteRotationLogger logger) : base(0, false)
        {
            _entityProvider = entityProvider;
            _logger = logger;
            _compressor = new FloatCompressor(0f, 360f, 0.1f);
            SetFixedSize(_compressor.RequiredBits);
        }

        private readonly IEntityProvider _entityProvider;
        private readonly RemoteRotationLogger _logger;

        private readonly FloatCompressor _compressor;

        private float _angle;
        private Horizontal _side;
        private PlayerOrientation _orientation;

        public float Angle => _angle;

        public Horizontal Side => _side;
        public PlayerOrientation Orientation => _orientation;

        public void SetRotation(float value)
        {
            _angle = value;
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            _logger.OnSerialize(_angle);

            var compressedAngle = _compressor.Compress(_angle);

            buffer.Write(compressedAngle, _compressor.RequiredBits);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var compressedAngle = buffer.Read(_compressor.RequiredBits);

            if (_entityProvider.IsMine == true)
                return;

            _angle = _compressor.Decompress(compressedAngle);
            _side = _angle.ToHorizontal();
            _orientation = _angle.ToOrientation();

            _logger.OnDeserialize(_angle);
        }
    }
}