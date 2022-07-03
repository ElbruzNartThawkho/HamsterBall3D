using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SandboxMove : MonoBehaviour
{
    public GameObject lvl;
    private GameObject checkPoint, score;
    public static Vector3 lastLoct;
    int deadcount = 0, Sco = 0, spawny = 48;
    private void Awake()
    {
        checkPoint = GameObject.FindWithTag("Control2");
        score = GameObject.FindWithTag("Score");
        checkPoint.SetActive(false);
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            if (finger.phase == TouchPhase.Began)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 10f,ForceMode.VelocityChange);
                //Debug.Log("Dokundu");
            }
            //if (finger.phase == TouchPhase.Stationary)
            //{
            //    Debug.Log("Dokunyor");
            //}
            //if (finger.phase == TouchPhase.Moved)
            //{
            //    Debug.Log("Sürüklüyor");
            //}
            //if (finger.phase == TouchPhase.Ended)
            //{
            //    Debug.Log("Dokunma Bitti");
            //}
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.gameObject.tag == "Enemy")
        {
            if (deadcount % 5 == 4)
            {
#if UNITY_ANDROID
                Handheld.Vibrate();
#endif
                Interstital interstital = new Interstital();
                interstital.Gameover();
            }
            deadcount++;
            Sco = 0;
            score.GetComponent<TextMeshProUGUI>().text = "Score:" + Sco;
            SceneManager.LoadScene("Sandbox");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "inspoint")
        {
            other.gameObject.SetActive(false);
            spawny += 76;
            Vector3 posit=new Vector3(-5, spawny, -5);
            Instantiate(lvl, posit, Quaternion.identity);
            Debug.Log("dedi");
        }
        if (other.gameObject.tag == "Checkpoint")
        {
            lastLoct = other.gameObject.transform.position;
            lastLoct.y += 1f;
            StartCoroutine(Check());
        }
        if (other.gameObject.tag == "Control3")
        {
            other.gameObject.SetActive(false);
            Sco++;
            score.GetComponent<TextMeshProUGUI>().text = "Score:" + Sco;
        }
    }
    IEnumerator Check()
    {
        checkPoint.SetActive(true);
        checkPoint.GetComponent<TextMeshProUGUI>().text += ".";
        yield return new WaitForSeconds(0.3f);
        checkPoint.GetComponent<TextMeshProUGUI>().text += ".";
        yield return new WaitForSeconds(0.3f);
        checkPoint.GetComponent<TextMeshProUGUI>().text += ".";
        yield return new WaitForSeconds(0.3f);
        checkPoint.GetComponent<TextMeshProUGUI>().text = "Checkpoint";
        yield return new WaitForSeconds(0.1f);
        checkPoint.SetActive(false);
    }
}
