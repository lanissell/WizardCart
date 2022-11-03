using Enemy;
using UnityEngine;

namespace Weapons
{
    public class Sharp: MonoBehaviour, IWeapon
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out IWeaponVisitor visitor)) Accept(visitor);
        }

        public void Accept(IWeaponVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
