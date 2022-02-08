using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileViewRifle : BaseProjectileView, IProjectileView
    {
        protected override void Start()
        {
            base.Start();
        }
    }
}
