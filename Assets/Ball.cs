using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Vector3 ballPos;
    public Transform hand;
    public bool free;
    private string id;
    private string target;
    private bool seperation;
    private TopDownCameraController cam;
    private void Start()
    {
        id=null;
        cam = GameObject.Find("Main Camera").GetComponent<TopDownCameraController>();
    }
    private void FixedUpdate()
    {
        if (id!=null)
        {
                gameObject.transform.position = hand.position;
        }
    }
    public void Shoot(string shooter)
    {
        ballLeave("shoot", shooter);
    }
    public void Pass(string target)
    {
        ballLeave("pass", target);
    }
    public void ballLeave(string method, string teamno)
    {
        if (id != null)
        {
            ballPos = GameObject.Find("Ball").transform.position;
            Vector3 goal = Vector3.zero;
            Vector3 arc1 = Vector3.zero;
            Vector3 arc2 = Vector3.zero;
            Player player;
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player = GameObject.Find(id).GetComponent<Player>();

            if (method == "pass")
            {
                target = teamno;
                setPossession(null);
                Vector3 velocity = GameObject.Find(target).GetComponent<Rigidbody>().velocity;
                goal = GameObject.Find(target).transform.position;
                print(target);
                Parabolic.solve_ballistic_arc(ballPos, player.power, goal, velocity, 9.81f, out arc1, out arc2);
                gameObject.GetComponent<Rigidbody>().AddForce(arc1, ForceMode.VelocityChange);

            }
            else if (method == "shoot")
            {
                player = GameObject.Find(teamno).GetComponent<Player>();
                if (float.Parse(id) < 100)
                    goal = GameObject.Find("Hole0").transform.position;
                else
                    goal = GameObject.Find("Hole1").transform.position;
                setPossession(null);
                Parabolic.solve_ballistic_arc(ballPos, player.power, goal, 9.81f, out arc1, out arc2);
                gameObject.GetComponent<Rigidbody>().AddForce(arc2, ForceMode.VelocityChange);
            }
        }
    }
    public void setPossession(string playerId)
    {
        if (playerId != null)
        {
            id = playerId;
            hand = GameObject.Find(id + "RH").transform;
            cam.changeCamera(id);
            GameObject.Find("Controller").GetComponent<MovementController>().possession = id;
        }
        else
        {
            id = null;
            cam.changeCamera("Ball");
            hand = null;
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//if what it hits is a person
        {
            setPossession(collision.gameObject.transform.name);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
    }
}
