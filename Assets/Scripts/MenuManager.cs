using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Material[] Default = new Material[3];
    public Material[] PlayerType0=new Material[3];
    public Material[] PlayerType1 = new Material[3];
    public Material[] PlayerType2 = new Material[3];
    public GameObject Sphere;
    static GameObject music;
    static GameObject MusicOn, MusicOff;
    IEnumerator wave()
    {
        while (true)
        {
            int x = Random.Range(0, 4);
            switch (x)
            {
                case 0:
                    Sphere.GetComponent<MeshRenderer>().materials = Default;
                    break;
                case 1:
                    Sphere.GetComponent<MeshRenderer>().materials = PlayerType0;
                    break;
                case 2:
                    Sphere.GetComponent<MeshRenderer>().materials = PlayerType1;
                    break;
                case 3:
                    Sphere.GetComponent<MeshRenderer>().materials = PlayerType2;
                    break;
            }
            yield return new WaitForSeconds(5);
        }
    }
    private void Awake()
    {
        music = GameObject.Find("Music GameObject");
        MusicOn = GameObject.Find("On");
        MusicOff = GameObject.Find("Off");
        if (music.GetComponent<AudioSource>().isPlaying)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
        }
    }
    private void Start()
    {
        StartCoroutine(wave());
    }
    public void musicBtn()
    {
        if (music.GetComponent<AudioSource>().isPlaying)
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            music.GetComponent<AudioSource>().Pause();
        }
        else
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            music.GetComponent<AudioSource>().Play();
        }
    }
    public void exitBtn()
    {
        Application.Quit();
    }
    public void logoBtn()
    {
        Application.OpenURL("https://elbruznart.blogspot.com//");
    }
    public void level0(string level)
    {
        SceneManager.LoadScene(level);
    }
}
