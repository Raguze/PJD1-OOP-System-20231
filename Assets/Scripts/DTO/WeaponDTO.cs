using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponDTO", menuName = "DTO/WeaponDTO")]
public class WeaponDTO : ItemDTO
{
    public int Damage;
    public int AmmoMax;
    public float FireRate;
    public float ReloadSpeed;
    public float Accuracy;
    public float Distance;
    public float BulletSpeed;
    public float Weight;
}
