using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Enums;

namespace WeaponMerge.Core.Interfaces
{
    public interface IWeapon
    {
        string Name { get; }
        int Level { get; }
        WeaponType Type { get; }

        void Merge(IWeapon otherWeapon);
    }
}
