using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;

    public int moveSpeed;

    private Rigidbody rb;

    public float forwardSpeed;

    public Transform Camera;

    public Transform Bounds;

    GameObject cube;

    public GameObject[] pieceOfCube;


    private void Start()
    {
        cube = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //ekrana dokundu�unda player , bounds , camera sabit ve ileri y�nl� ayn� h�za sahip olacak
        if (StatusChecker.touched)
        {
            transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            Camera.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
            Bounds.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        }
        
        if (Input.touchCount > 0)
        {
            StatusChecker.touched = true;
            touch = Input.GetTouch(0);
            //fiziksel �arp��ma durumlar�nda collider mekani�inin etkin bir bi�imde �al��mas� i�in transform.position kullanmak yerine fizik i�lemleri tercih edilmelidir.
            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * moveSpeed * Time.deltaTime, transform.position.y, touch.deltaPosition.y * moveSpeed * Time.deltaTime);
            }

            else if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }

            else if (touch.phase == TouchPhase.Stationary) //parma��m� bast�m ama hareket ettirmiyorum bu durumda stationary true d�ner.
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            cube.SetActive(false);

            for (int i = 0; i<pieceOfCube.Length;i++)
            {
                pieceOfCube[i].GetComponent<Collider>().enabled = true;
                pieceOfCube[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

}
