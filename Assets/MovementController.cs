using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public string possession;
    private GameObject player;
    private void FixedUpdate()
    {
        player = GameObject.Find(possession);
        Vector3 dirVector = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal")).normalized * player.GetComponent<Player>().speed;
        player.GetComponent<Rigidbody>().MovePosition(player.transform.position + dirVector * Time.deltaTime);

        if (Input.GetKeyUp("x"))
        {
            GameObject.Find("Ball").GetComponent<Ball>().Shoot(possession);
        }
        if (Input.GetKeyUp("z"))
        {
            GameObject [] players=GameObject.FindGameObjectsWithTag("Player");
            float distance;
            float smallest=100000f;
            int target = -1;
            for (int i=0; i< players.Length; i++)
            {
                if (players[i].transform.name!=possession)
                {
                    distance=Mathf.Abs(players[i].transform.position.x-player.transform.position.x)+ Mathf.Abs(players[i].transform.position.z - player.transform.position.z);
                    if (distance < smallest)
                    {
                        target = i;
                        smallest = distance;
                    }
                }
            }
            possession = players[target].transform.name;
            
            GameObject.Find("Ball").GetComponent<Ball>().Pass(possession);
        }
    }
}
