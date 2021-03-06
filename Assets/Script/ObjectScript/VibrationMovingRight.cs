using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationMovingRight : MonoBehaviour {
    private bool flag = true;
    private float para = 0.05f;
    private float interval = 0.05f;
    private float tmpTime1 = 0f;
    private float tmpTime2 = 0f;
    private int stackFlag = 0;
    private bool smallFlag = true;
    [SerializeField] private float movingSpeed = 250f;
    [SerializeField] private float scale = 20;
    private float x, y, z;
    private GameObject Player;
    void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        Player = GameObject.Find ("chr_robot");
    }
    // Update is called once per frame
    void Update () {
        if (smallFlag) {
            tmpTime2 += Time.deltaTime;
            if (tmpTime2 >= interval) {
                if (transform.position.x > x + 0.1) {
                    transform.position += new Vector3 (-1 * Time.deltaTime * 10, 0f, 0f);
                }
            }
            if (transform.position.x < x) {
                transform.position = new Vector3 (x, y, z);
                tmpTime2 = 0;
            }
        }
    }
    private void OnTriggerStay (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = false;
            tmpTime1 += Time.deltaTime;
            if (tmpTime1 >= interval) {
                if (stackFlag > 20) {
                    if (transform.localScale.x < scale) {
                        transform.position += new Vector3 (Time.deltaTime * 20, 0f, 0f);
                        Player.transform.position += new Vector3 (Time.deltaTime * 20, 0f, 0f);
                    }
                } else {
                    transform.localScale += new Vector3 (para, para, para);
                    para *= -1f;
                }
                stackFlag += 1;
                tmpTime1 = 0;
            }
        }
    }
    private void OnTriggerExit (Collider other) {
        if (other.gameObject.name == "FootCollider") {
            smallFlag = true;
            stackFlag = 0;
        }
    }
}