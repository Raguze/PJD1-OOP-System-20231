using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    public override WeaponType Type { get { return WeaponType.Machinegun; } }

    protected override void FireWeapon()
    {
        BulletController bullet = Factory.CreateBullet();
        bullet.SetTransform(BulletRespawn.position, tf.rotation.eulerAngles.z);
        bullet.SetDTO(weaponDTO);
    }
}
