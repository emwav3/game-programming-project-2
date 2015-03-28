﻿using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	Transform player;

    Transform spawn;
    public GameObject marble;

	public float distanceFromPlayer;
	public float turnSpeed = 4f;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        Instantiate(marble, spawn.position, Quaternion.identity);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        

		offset = new Vector3 (player.transform.position.x, player.transform.position.y + distanceFromPlayer, player.transform.position.z - distanceFromPlayer);

	}

	// Late update is so that the camera can be moved after the player has moved
	void LateUpdate()
	{
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}
}
