using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public string destinationRoom;

    public int elevatorTimer;

    public bool inMotion;

    public CameraManager camera;

    public void UseElevator(string targetRoom)
    {
        //play song
        destinationRoom = targetRoom;
        elevatorTimer = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        inMotion = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (inMotion)
        {
            if (elevatorTimer <= 0)
            {
                inMotion = false;
                camera.MoveToRoom(destinationRoom);
            }
            else
            {
                elevatorTimer--;
                Debug.Log(elevatorTimer);
            }
        }
    }
}
