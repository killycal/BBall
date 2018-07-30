using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {
    private int nome;
	// Use this for initialization
	void Start () {
        int.TryParse(gameObject.transform.name, out nome);
        nome = nome % 10;
	}
    public void Move(float x, float y)
    {
        GameObject.Find(nome.ToString()).GetComponent<Player>().Move();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
