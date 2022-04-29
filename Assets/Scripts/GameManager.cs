using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    int x = 0;
    private void Update()
    {
        if (x % 4 == 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(30, 0, 0);
            gameObject.transform.position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y + 5, Player.GetComponent<Transform>().position.z - 5);
        }
        else if (x % 4 == 1)
        {
            gameObject.transform.rotation=Quaternion.Euler(30, -90, 0);
            gameObject.transform.position = new Vector3(Player.GetComponent<Transform>().position.x + 5, Player.GetComponent<Transform>().position.y + 5, Player.GetComponent<Transform>().position.z);
        }
        else if(x % 4 == 2)
        {
            gameObject.transform.rotation = Quaternion.Euler(30, 180, 0);
            gameObject.transform.position = new Vector3(Player.GetComponent<Transform>().position.x, Player.GetComponent<Transform>().position.y + 5, Player.GetComponent<Transform>().position.z + 5);
        }
        else if( x % 4 == 3)
        {
            gameObject.transform.rotation = Quaternion.Euler(30, 90, 0);
            gameObject.transform.position = new Vector3(Player.GetComponent<Transform>().position.x - 5, Player.GetComponent<Transform>().position.y + 5, Player.GetComponent<Transform>().position.z);
        }
    }
    public void right()
    {
        if (x == 3)
        {
            x = 0;
        }
        else
        {
            x++;
        }
    }
    public void left()
    {
        if (x == 0)
        {
            x = 3;
        }
        else
        {
            x--;
        }
    }
    public void Campos()
    {
        
    }
    /*[SerializeField] private FixedJoystick Rstick;
    public GameObject Player;
    private Transform target;
    public Vector3 globalOffset, localOffset;
    public float distance = 5f;
    public float sensitivity = 3f;
    public float smoothTime = 0.3f;
    public Vector3 velocity = Vector3.zero;
    private void LateUpdate()
    {
        float angleX = transform.localEulerAngles.x;
        if (angleX > 0)
        {
            angleX -= 360f;
            angleX *= -1;
        }
        transform.Rotate(-1 * Rstick.Vertical * sensitivity,Rstick.Horizontal * sensitivity * Mathf.Cos(angleX * Mathf.Deg2Rad), 0f);
        Vector3 localEular = transform.localEulerAngles;
        //Debug.Log(Rstick.Vertical+"V");
        //Debug.Log(Rstick.Horizontal+"H");
        localEular.y += (int)Rstick.Vertical * sensitivity;
        localEular.x += (int)Rstick.Horizontal * sensitivity;

        Vector3 newLocalEuler = localEular;
        newLocalEuler.z = 0f;
        if (newLocalEuler.x > 180f)
        {
            newLocalEuler.x -= 360f;
        }
        newLocalEuler.x = Mathf.Clamp(newLocalEuler.x, -85f, 85f);

        transform.localEulerAngles = newLocalEuler;

        //distance = Mathf.Clamp(distance, 1f, 10f);

        transform.position = Vector3.SmoothDamp(transform.position, CheckCollision(CalculatePosition()), ref velocity, smoothTime);
    }
    private Vector3 CalculatePosition()
    {
        return CalculateRawPosition() - transform.forward * distance;
    }
    private Vector3 CalculateRawPosition()
    {
        return target.position + globalOffset + target.TransformVector(localOffset);
    }
    private Vector3 CheckCollision(Vector3 restPos)
    {
        Camera cam =GetComponent<Camera>();

        Vector3 forwardL = transform.forward * cam.nearClipPlane;

        float cameraHeight = Mathf.Tan(cam.fieldOfView * Mathf.Deg2Rad * 0.5f);
        Vector3 upL = transform.up * Mathf.Tan(cameraHeight) * cam.nearClipPlane;

        float hFov = Mathf.Atan(cameraHeight * cam.aspect);
        Vector3 rightL = transform.right * Mathf.Tan(hFov) * cam.nearClipPlane;

        float sphereRadius = (forwardL + upL + rightL).magnitude * 0.5f;

        Vector3 rawPos = CalculateRawPosition();
        Vector3 direction = restPos - rawPos;
        RaycastHit hitInfo;

        if(Physics.SphereCast(rawPos,sphereRadius,direction,out hitInfo, distance))
        {
            restPos = rawPos + direction.normalized * hitInfo.distance;
        }
        return restPos;
    }
    private void Awake()
    {
        target = Player.GetComponent<Transform>();
    }*/
}
