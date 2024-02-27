namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    public enum RotationMode
    {
        /// <summary>
        /// Disable Character's rotation.
        /// </summary>
            
        None = 0,
            
        /// <summary>
        /// Smoothly rotate the Character toward the direction of acceleration, using rotationRate as the rate of rotation change.
        /// </summary>
            
        OrientRotationToMovement = 1,

        /// <summary>
        /// Let root motion handle Character rotation.
        /// </summary>
            
        OrientWithRootMotion = 2,
            
        /// <summary>
        /// User-defined custom rotation mode.
        /// </summary>
            
        Custom = 3
    }
}