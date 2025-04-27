using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaponMerge.Core.Classes.Entities;
using WeaponMerge.Core.Enums;
using WeaponMerge.Core.Interfaces;

namespace WeaponMerge.Core.Services
{
    public class WeaponService
    {
        public WeaponCatalog weaponCatalog = new WeaponCatalog();

        private List<IWeapon> weapons;

        public IEnumerable<IWeapon> Weapons { get { return weapons.AsReadOnly(); } }

        public WeaponService()
        {
            weapons = new List<IWeapon>()
            {

            };
        }

        public void AddWeapon(WeaponType type)
        {
            weapons.Add(weaponCatalog.GetWeapon(type, 1));
        }

        public void MergeWeapons(IWeapon weapon1, IWeapon weapon2)
        {
            if (weapon1 == null || weapon2 == null)
            {
                throw new ArgumentException("Een of twee wapens waren niet gekozen!");
            }
            if (weapon1.Type == weapon2.Type && weapon1.Level == weapon2.Level)
            {
                IWeapon newWeapon = weaponCatalog.GetWeapon(weapon1.WeaponType, weapon1.Level + 1);

                if (newWeapon != null)
                {
                    weapons.Add(newWeapon);
                    weapons.Remove(weapon1);
                    weapons.Remove(weapon2);
                }
            }
            else
            {
                throw new ArgumentException("De wapens hebben niet hetzelfde level.");
            }
        }
    }
}
