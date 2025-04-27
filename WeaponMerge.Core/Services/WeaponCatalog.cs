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
    public class WeaponCatalog
    {
        private readonly List<IWeapon> _weapons = new List<IWeapon>();

        public WeaponCatalog()
        {
            // Alle wapens toevoegen bij de start
            _weapons.Add(new MeleeWeapon("Bronze Sword", 1));
            _weapons.Add(new MeleeWeapon("Iron Sword", 2));
            _weapons.Add(new MeleeWeapon("Steel Sword", 3));
            _weapons.Add(new MeleeWeapon("Mithril Sword", 4));
            _weapons.Add(new MeleeWeapon("Dragon Scimitar", 5));

            _weapons.Add(new RangedWeapon("Shortbow", 1));
            _weapons.Add(new RangedWeapon("Oak Shortbow", 2));
            _weapons.Add(new RangedWeapon("Willow Shortbow", 3));
            _weapons.Add(new RangedWeapon("Maple Shortbow", 4));
            _weapons.Add(new RangedWeapon("Rune Crossbow", 5));

            _weapons.Add(new MagicWeapon("Air Staff", 1));
            _weapons.Add(new MagicWeapon("Water Staff", 2));
            _weapons.Add(new MagicWeapon("Earth Staff", 3));
            _weapons.Add(new MagicWeapon("Fire Staff", 4));
            _weapons.Add(new MagicWeapon("Ancient Staff", 5));
        }
        public IWeapon GetWeapon(WeaponType type, int level)
        {
            foreach (IWeapon weapon in _weapons)
            {
                if (weapon.Type == type && weapon.Level == level)
                {
                    return weapon;
                }
            }

            // Geen wapen gevonden
            return null;
        }
    }
}
