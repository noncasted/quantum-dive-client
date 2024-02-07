namespace GamePlay.Enemies.Updater.Runtime
{
    public class UpdaterTimer
    {
        public UpdaterTimer(float rate)
        {
            _rate = rate;
        }
        
        private readonly float _rate;

        private float _timer;

        public bool IsAvailable(float delta)
        {
            _timer += delta;
            
            if (_timer < _rate)
                return false;

            _timer = 0f;

            return true;
        }
    }
}