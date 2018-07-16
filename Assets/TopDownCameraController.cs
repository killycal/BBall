using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    public float distancex = 30;
    public float distancey = 10;
    public float distancez = 10;
    public float dampTime = 0.5f;
    private Vector3 velocity = Vector3.zero;
    private string focus;
    private Ball ball;
    private void Start()
    {
        focus = "Ball";
    }

   private void FixedUpdate()
    {
        Vector3 PlayerPOS = GameObject.Find(focus).transform.transform.position;
        Vector3 to = new Vector3(PlayerPOS.x + distancex, PlayerPOS.y + distancey, PlayerPOS.z + distancez);
        GameObject.FindWithTag("MainCamera").transform.position = Vector3.SmoothDamp(Camera.main.transform.position, to, ref velocity, dampTime);
    }

   public void changeCamera(string id)
    {
        focus = id;
    }

}

