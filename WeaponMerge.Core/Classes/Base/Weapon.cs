using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Enums;
using WeaponMerge.Core.Interfaces;

namespace WeaponMerge.Core.Classes.Base
{
    public abstract class Weapon : IWeapon
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

        private WeaponType weaponType;

        public WeaponType WeaponType
        {
            get
            {
                return weaponType;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Type moet nog gekozen worden!");
                }
                weaponType = value;
            }
        }

        public Weapon(string name, int level, WeaponType type)
        {
            Name = name;
            Level = level;
            WeaponType = type;
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
