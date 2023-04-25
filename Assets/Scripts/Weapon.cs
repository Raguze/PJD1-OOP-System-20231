using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType { None, Pistol, Shotgun, Machinegun, Sniper, RocketLauncher }

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

    [SerializeField]
    public virtual WeaponType Type { get; set; }

    [SerializeField]
    protected WeaponDTO weaponDTO;

    [SerializeField]
    protected Transform BulletRespawn;

    protected Transform tf;

    public void SetDTO(WeaponDTO dto)
    {
        weaponDTO = dto;

        Accuracy = weaponDTO.Accuracy;
        AmmoMax = weaponDTO.AmmoMax;
        BulletSpeed = weaponDTO.BulletSpeed;
        Damage = weaponDTO.Damage;
        Distance = weaponDTO.Distance;
        FireRate = weaponDTO.FireRate;
        Name = weaponDTO.Name;
        ReloadSpeed = weaponDTO.ReloadSpeed;
        Weight = weaponDTO.Weight;
        Type = weaponDTO.Type;
    }

    private void Awake()
    {
        tf = GetComponent<Transform>();

        BulletRespawn = transform.Find("BulletRespawn");


        if(weaponDTO != null)
        {
            SetDTO(weaponDTO);
        }


    }

    public void Fire()
    {
        BulletController bullet = Factory.CreateBullet();
        bullet.SetTransform(BulletRespawn.position,tf.rotation.eulerAngles.z);
        bullet.SetDTO(weaponDTO);
    }
}
