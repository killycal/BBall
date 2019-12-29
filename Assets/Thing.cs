using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour {

    public int team;
    public string position;
    // Use this for initialization
    void Start()
    {
        //int.TryParse(gameObject.transform.name, out nome);
        //nome = nome % 10;
        GameObject.Find(position+team).GetComponent<Player>().Move();
    }
    public void Adjust(float x, float y)
    {
        print("run");
        this.transform.position = new Vector3(x, -.4f, y);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
