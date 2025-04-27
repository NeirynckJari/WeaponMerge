using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Enums;

namespace WeaponMerge.Core.Classes.Base
{
    public class JSONWeapons
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public string Type { get; set; }

        public WeaponType WeaponType
        {
            get
            {
                if (Type == "Melee")
                {
                    return WeaponType.Melee;
                }
                else if (Type == "Ranged")
                {
                    return WeaponType.Ranged;
                }
                else if (Type == "Magic")
                {
                    return WeaponType.Magic;
                }
                else throw new ArgumentException("Unknown type was used!");
            }
        }

    }
}
