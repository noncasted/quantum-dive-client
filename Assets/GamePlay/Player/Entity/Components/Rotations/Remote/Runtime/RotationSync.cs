using GamePlay.Player.Entity.Components.Network.EntityHandler.Abstract;
using GamePlay.Player.Entity.Components.Rotations.Remote.Abstract;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;

namespace GamePlay.Player.Entity.Components.Rotations.Remote.Runtime
{
    public class RotationSync : RagonProperty, IRotationSync, IRemoteRotation
    {
        protected RotationSync(IEntityProvider entityProvider) : base(0, false)
        {
            _entityProvider = entityProvider;
            _compressor = new FloatCompressor(0f, 360f, 0.1f);
            SetFixedSize(_compressor.RequiredBits);
        }

        private readonly IEntityProvider _entityProvider;

        private readonly FloatCompressor _compressor;

        private float _angle;

        public float Angle => _angle;

        public void SetRotation(float value)
        {
            _angle = value;
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            var compressedAngle = _compressor.Compress(_angle);

            buffer.Write(compressedAngle, _compressor.RequiredBits);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var compressedAngle = buffer.Read(_compressor.RequiredBits);

            if (_entityProvider.IsMine == true)
                return;

            _angle = _compressor.Decompress(compressedAngle);
        }
    }
}