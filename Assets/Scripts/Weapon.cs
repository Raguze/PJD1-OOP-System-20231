using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public int Damage { get; set; }
    public int AmmoMax { get; set; }
    public float FireRate { get; set; }
    public float ReloadSpeed { get; set; }
    public float Accuracy { get; set; }
    public float Distance { get; set; }
    public float BulletSpeed { get; set; }
    public float Weight { get; set; }

    public void SetDTO(WeaponDTO dto)
    {

    }
}
