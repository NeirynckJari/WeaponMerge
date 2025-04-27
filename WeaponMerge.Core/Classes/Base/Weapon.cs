using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Enums;
using WeaponMerge.Core.Interfaces;

namespace WeaponMerge.Core.Classes.Base
{
    public class Weapon : IWeapon // Removed abstract for JSON working...
    {
        private string name;
        private int level;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Naam mag niet leeg zijn van het wapen!");
                }
                name = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("", "Level kan niet 0 zijn!");
                }
                level = value;
            }
        }

        public string Type { get; set; } //Pure JSON usage


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
                else
                {
                    throw new ArgumentException("Wrong type was entered!");
                }
            }
        }


        public Weapon(string name, int level, string type)
        {
            Name = name;
            Level = level;
            Type = type;
        }

        public virtual void Merge(IWeapon otherWeapon)
        {
            otherWeapon = null;
            this.Level++;
        }

        public override string ToString()
        {
            return $"{Name}(lvl{Level})";
        }
    }
}
