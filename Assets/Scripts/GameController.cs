using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public Joystick joystick;
    //public PlayerController playerController;

    public List<Player> players;

    private void Awake()
    {
        Joystick[] joysticks = FindObjectsOfType<Joystick>();
        PlayerController playerController = FindObjectOfType<PlayerController>();

        //joystick = FindObjectOfType<Joystick>();
        //playerController = FindObjectOfType<PlayerController>();

        foreach (var joystick in joysticks)
        {
            if(joystick.name == "LeftJoystick")
            {
                playerController.LeftJoystick = joystick;
            }

            if(joystick.name.StartsWith("Right"))
            {
                playerController.RightJoystick = joystick;
            }
        }

        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.PlayerController = playerController;
    }

    private void Start()
    {
        Player player;
        player = new Player(100);

        Player.Info = "Megaman Info";

        player.PlayerName = "Megaman";
        //player1.Hp = 100;
        player.Gold = 1000;
        player.Speed = 5f;

        players.Add(player);


        player = new Player(120);

        player.PlayerName = "Zero";
        //player2.Hp = 120;
        player.Gold = 800;
        player.Speed = 6;

        players.Add(player);


        player = new Player();

        //player1.DebugInfo();
        //player2.DebugInfo();
        player.DebugInfo();

        players.Add(player);


        player = new Player("Batman 2");
        players.Add(player);

        player = new Player("Coringa", 70, 200, 3f);
        players.Add(player);

        


    }
}
