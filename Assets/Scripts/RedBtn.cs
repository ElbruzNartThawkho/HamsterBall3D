using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedBtn : MonoBehaviour
{
    private GameObject WinScreen;
    private void Awake()
    {
        WinScreen = GameObject.FindWithTag("WinScreen");
        WinScreen.SetActive(false);
    }
    IEnumerator Win()
    {
        WinScreen.SetActive(true);
        gameObject.GetComponent<Animator>().SetTrigger("basýldý");
        WinScreen.GetComponent<Animator>().SetTrigger("winsd");
        yield return new WaitForSeconds(3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
#if UNITY_ANDROID
                Handheld.Vibrate();
#endif
            Interstital interstital = new Interstital();
            interstital.Gameover();
            StartCoroutine(Win());
        }
    }
    public void level(string level)
    {
        SceneManager.LoadScene(level);
    }
    public void menuback()
    {
        SceneManager.LoadScene("Menu");
    }
}
