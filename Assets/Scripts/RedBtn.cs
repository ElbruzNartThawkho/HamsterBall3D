using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedBtn : MonoBehaviour
{
    public GameObject WinScreen;
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
