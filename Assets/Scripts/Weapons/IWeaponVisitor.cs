using Projectile_and_particle;
using Weapons;

namespace Enemy
{
    public interface IWeaponVisitor
    {
        public void Visit(Sharp sharp);

        public void Visit(FireBall fireBall);
    }
}
