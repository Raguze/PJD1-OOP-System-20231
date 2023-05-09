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

    public int Ammo { get; protected set; }
    public float ReloadDuration { get; protected set; }

    [SerializeField]
    public virtual WeaponType Type { get; set; }

    [SerializeField]
    protected WeaponDTO weaponDTO;

    [SerializeField]
    protected Transform BulletRespawn;

    protected Transform tf;

    public bool CanFire
    { 
        get
        {
            return (
                Ammo > 0
                && ReloadDuration <= 0
            );
        } 
    }

    public virtual void SetDTO(WeaponDTO dto)
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

        // Other params
        Ammo = AmmoMax;
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

    private void Update()
    {
        if(ReloadDuration > 0)
        {
            ReloadDuration -= Time.deltaTime;
            if(ReloadDuration <= 0)
            {
                Ammo = AmmoMax;
            }
        }
    }

    public virtual void Fire()
    {
        if(CanFire)
        {
            FireWeapon();
            Ammo--;
        }
    }

    protected virtual void FireWeapon()
    {
        BulletController bullet = Factory.CreateBullet();
        bullet.SetTransform(BulletRespawn.position, tf.rotation.eulerAngles.z);
        bullet.SetDTO(weaponDTO);

    }

    public virtual void Reload()
    {
        ReloadDuration = ReloadSpeed;
    }
}
