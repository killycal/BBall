using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    public float power;
    private GameObject ball;
    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.transform.name = gameObject.transform.name+"RH";
    }
    public void ghost(bool dematerialize)
    {
        gameObject.GetComponent<Rigidbody>().detectCollisions = !dematerialize;
    }
}
