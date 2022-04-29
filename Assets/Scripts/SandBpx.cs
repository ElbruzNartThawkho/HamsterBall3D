using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBpx : MonoBehaviour
{
    [SerializeField] private GameObject Platform1;
    [SerializeField] private GameObject Platform2;
    [SerializeField] private GameObject Platform3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Control1")
        {
            Platform1.transform.position = new Vector3(Platform1.transform.position.x, Platform1.transform.position.y, Platform1.transform.position.z + 190);
        }
        else if (other.gameObject.tag == "Control2")
        {
            Platform2.transform.position = new Vector3(Platform2.transform.position.x, Platform2.transform.position.y, Platform2.transform.position.z + 190);
        }
        else if (other.gameObject.tag == "Control3")
        {
            Platform3.transform.position = new Vector3(Platform3.transform.position.x, Platform3.transform.position.y, Platform3.transform.position.z + 190);
        }
    }
}
