using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeaponMerge.Core.Classes.Base;
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
            _weapons = new List<IWeapon>() { };
        }

        async public Task GenerateWeapons()
        {
            HttpClient httpClient = new HttpClient();
            string jsonData = await httpClient.GetStringAsync("https://neirynckjari.github.io/WeaponMerge/weapons.json");
            List<Weapon> jsonDataList = JsonSerializer.Deserialize<List<Weapon>>(jsonData);

            if (jsonDataList == null)
            {
                throw new InvalidOperationException("De JSON-gegevens konden niet worden gedeserialiseerd.");
            }

            foreach (Weapon weapon in jsonDataList)
            {
                if (weapon != null)
                {
                    IWeapon weaponToAdd;
                    if (weapon.WeaponType == WeaponType.Melee)
                    {
                        weaponToAdd = new MeleeWeapon(weapon.Name, weapon.Level);
                        _weapons.Add(weaponToAdd);
                    }
                    else if (weapon.WeaponType == WeaponType.Magic)
                    {
                        weaponToAdd = new MagicWeapon(weapon.Name, weapon.Level);
                        _weapons.Add(weaponToAdd);
                    }
                    else if (weapon.WeaponType == WeaponType.Ranged)
                    {
                        weaponToAdd = new RangedWeapon(weapon.Name, weapon.Level);
                        _weapons.Add(weaponToAdd);
                    }
                }
            }
        }

        public IWeapon GetWeapon(WeaponType type, int level)
        {
            foreach (IWeapon weapon in _weapons)
            {
                if (weapon.WeaponType == type && weapon.Level == level)
                {
                    return weapon;
                }
            }

            // Geen wapen gevonden
            return null;
        }
    }
}
