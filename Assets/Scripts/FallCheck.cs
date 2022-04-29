using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCheck : MonoBehaviour
{
    public GameObject Player;
    private void Awake()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            teleport();
        }
    }
    void teleport()
    {
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        Player.transform.position = PlayerMove.lastLoct;
        Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
