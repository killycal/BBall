using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public float power;
    private GameObject ball;
    public Transform dir;
    public int team;
    private Vector3 dirVector = Vector3.zero;
    private bool outOfPosition;
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.transform.name = gameObject.transform.name+"RH";
        Move();
    }
    private void FixedUpdate()
    {
        if (outOfPosition)
        {
            dirVector = dir.position - gameObject.transform.position;
            gameObject.GetComponent<Rigidbody>().MovePosition(gameObject.transform.position + dirVector * Time.deltaTime * speed/2.5f);
        }
    }
    public void Move()
    {
        outOfPosition = true;
    }
    public void ghost(bool dematerialize)
    {
        gameObject.GetComponent<Rigidbody>().detectCollisions = !dematerialize;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == team.ToString() + gameObject.transform.name)
            outOfPosition = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.name == team.ToString() + gameObject.transform.name)
            outOfPosition = true;
    }
}
