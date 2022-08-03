using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Touch touch;

    public int moveSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            //fiziksel �arp��ma durumlar�nda collider mekani�inin etkin bir bi�imde �al��mas� i�in transform.position kullanmak yerine fizik i�lemleri tercih edilmelidir.
            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * moveSpeed * Time.deltaTime, transform.position.y, touch.deltaPosition.y * moveSpeed * Time.deltaTime);
            }
        }
    }

}
