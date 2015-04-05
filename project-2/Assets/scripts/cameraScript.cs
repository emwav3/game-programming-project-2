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
        Instantiate(marble, spawn.position, spawn.rotation);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        

		offset = spawn.right * -1 * distanceFromPlayer;
        offset = new Vector3(offset.x, distanceFromPlayer /2, offset.z);

	}

	// Late update is so that the camera can be moved after the player has moved
	void LateUpdate()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;

		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, -Vector3.right) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
	}
}
