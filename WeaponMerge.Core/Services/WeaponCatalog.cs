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

        async public Task FetchWeapons()
        {

        }

        public WeaponCatalog()
        {
            _weapons = new List<IWeapon>() { };
        }

        async public Task GenerateWeapons()
        {
            HttpClient httpClient = new HttpClient();
            string jsonData = await httpClient.GetStringAsync("https://neirynckjari.github.io/WeaponMerge/weapons.json");
            List<JSONWeapons> jsonDataList = JsonSerializer.Deserialize<List<JSONWeapons>>(jsonData);
            foreach (JSONWeapons weapon in jsonDataList)
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
