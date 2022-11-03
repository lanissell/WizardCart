using Enemy;

namespace Weapons
{
    public interface IWeapon
    {
        public void Accept(IWeaponVisitor visitor);
    }
}
