using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{

    [SerializeField]
    private Joystick leftJoystick;

    public Joystick LeftJoystick
    {
        set {
            leftJoystick = value;
        }
    }

    [SerializeField]
    private Joystick rightJoystick;

    public Joystick RightJoystick
    {
        set
        {
            rightJoystick = value;
        }
    }

    protected List<Weapon> Weapons = new List<Weapon>();

    public float Horizontal;
    public float Vertical;
    public Vector2 Direction;

    public float Speed = 5f;
    public Vector2 Velocity = new Vector2();

    public float Rotation = 0;

    public Vector2 Position
    { 
        get {
            return tf.position;
        } 
    }

    public Weapon CurrentWeapon
    {
        get
        {
            return Weapons[0];
        }
    }

    protected override void Awake()
    {
        base.Awake();

        Weapon[] weapons = GetComponentsInChildren<Weapon>();
        Weapons.AddRange(weapons);
    }

    private void Update()
    {
        Horizontal = leftJoystick.Horizontal;
        Vertical = leftJoystick.Vertical;

        Velocity = new Vector2(Horizontal, Vertical) * Speed;

        Direction = rightJoystick.Direction;

        if(Direction.magnitude > 0.1f)
        {
            Rotation = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90f;
        }


        tf.rotation = Quaternion.Euler(0, 0, Rotation);

        rb.velocity = Velocity;

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            CurrentWeapon.Fire();
        }
    }
}
