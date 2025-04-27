using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Classes.Base;
using WeaponMerge.Core.Enums;
using WeaponMerge.Core.Interfaces;

namespace WeaponMerge.Core.Classes.Entities
{
    public class MagicWeapon : Weapon
    {
        public MagicWeapon(string name, int level) : base(name, level, WeaponType.Magic)
        {
        }
    }
}
