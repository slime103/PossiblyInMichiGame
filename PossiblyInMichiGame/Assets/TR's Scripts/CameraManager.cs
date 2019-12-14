using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Dialogue_Manager dm;
    public void MoveToRoom(string roomName)
    {
        Camera.main.transform.position = new Vector3(GameObject.Find(roomName).transform.position.x,
            GameObject.Find(roomName).transform.position.y, Camera.main.transform.position.z);
        if (GameObject.Find(roomName).GetComponent<Room>().doIBark)
        {
            dm.Bark((GameObject.Find(roomName).GetComponent<Room>().myCharacter));
        }
    }
}
