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
        string Type { get; }
        WeaponType WeaponType { get; }

        void Merge(IWeapon otherWeapon);
    }
}
