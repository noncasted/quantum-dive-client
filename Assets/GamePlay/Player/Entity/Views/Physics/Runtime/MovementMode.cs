namespace GamePlay.Player.Entity.Views.Physics.Runtime
{
    public enum MovementMode
    {
        /// <summary>
        /// Disables movement clearing velocity and any pending forces / impulsed on Character.
        /// </summary>
        None,

        /// <summary>
        /// Walking on a surface, under the effects of friction, and able to "step up" barriers. Vertical velocity is zero.
        /// </summary>
        Walking,

        /// <summary>
        /// Falling under the effects of gravity, after jumping or walking off the edge of a surface.
        /// </summary>
        Falling,

        /// <summary>
        /// Flying, ignoring the effects of gravity.
        /// </summary>
        Flying,

        /// <summary>
        /// Swimming through a fluid volume, under the effects of gravity and buoyancy.
        /// </summary>
        Swimming,

        /// <summary>
        /// User-defined custom movement mode, including many possible sub-modes.
        /// </summary>
        Custom
    }
}