using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {

    public Transform player;
    public float speed = 2f;
    public Vector3 offset = new Vector3(-0.2f, 0.0f, 0.0f);
    public static bool IsFired;

	// Use this for initialization
	void Start () {
        IsFired = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        {
            IsFired = true;
        }
		if(IsFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
            player.GetChild(0).transform.GetComponent<Animator>().SetBool("Shoot", true);
        }
        else
        {
            transform.position = player.position + offset;
            transform.localScale = new Vector3(1f, 0f, 1f);
            player.GetChild(0).transform.GetComponent<Animator>().SetBool("Shoot", false);
        }
    }
}
