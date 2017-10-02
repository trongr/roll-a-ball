using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start () {
        rb = GetComponent<Rigidbody> ();
        count = 0;
        setCountText ();
		winText.text = "";
    }

    // Use this for graphics updates
    void Update () {

    }

    // Use this for physics calculations
    void FixedUpdate () {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");
        rb.AddForce (new Vector3 (x, 0, z) * speed);
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Gold")) {
            other.gameObject.SetActive (false);
            count++;
            setCountText ();
        }
        if (count >= 8) {
            setWinText ();
        }
    }

    void setCountText () {
        countText.text = "Gold: " + count.ToString ();
    }

    void setWinText () {
        winText.text = "You Win!";
    }
}