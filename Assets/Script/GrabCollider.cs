﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCollider : MonoBehaviour {
    private bool isCanGrabWall = false;
    public GameObject player;
    private Rigidbody playerRigid;
    private FootCollider foot;
    public PlayerMove PlayerMove;
    void Start () {
        player = transform.root.gameObject;
        playerRigid = player.GetComponent<Rigidbody> ();
        PlayerMove = player.GetComponent<PlayerMove> ();
        foot = GameObject.Find ("FootCollider").GetComponent<FootCollider> ();
    }
    void Update () {
        //壁掴み
        if (isCanGrabWall && Input.GetKey (KeyCode.G)) {
            playerRigid.velocity = Vector3.zero;
            foot.jumpCount = 0;
        }
    }
    public void OnTriggerStay (Collider other) {
        PlayerMove.isMove = false;
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = true;
        }
    }
    public void OnTriggerExit (Collider other) {
        PlayerMove.isMove = true;
        if (other.gameObject.CompareTag ("GrabWall")) {
            isCanGrabWall = false;
        }
    }
}
