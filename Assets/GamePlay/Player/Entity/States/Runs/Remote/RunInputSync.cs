using Common.DataTypes.Structs;
using GamePlay.Player.Entity.Components.Rotations.Orientation;
using Ragon.Client;
using Ragon.Client.Compressor;
using Ragon.Protocol;
using UnityEngine;

namespace GamePlay.Player.Entity.States.Runs.Remote
{
    public class RunInputSync : RagonProperty, IRunInputSync
    {
        public RunInputSync() : base(0, false)
        {
            SetFixedSize(_compressor.RequiredBits);
        }

        private readonly FloatCompressor _compressor = new(0f, 360f);
        
        private float _angle;
        private PlayerOrientation _orientation;

        public float Angle => _angle;
        public PlayerOrientation Orientation => _orientation;   

        public void OnInput(Vector2 input)
        {
            _angle = input.ToAngle();
            
            MarkAsChanged();
        }

        public override void Serialize(RagonBuffer buffer)
        {
            var compressed = _compressor.Compress(_angle);
            buffer.Write(compressed, _compressor.RequiredBits);
        }

        public override void Deserialize(RagonBuffer buffer)
        {
            var compressed = buffer.Read(_compressor.RequiredBits);
            _angle = _compressor.Decompress(compressed);
            _orientation = _angle.ToOrientation();
        }
    }
}