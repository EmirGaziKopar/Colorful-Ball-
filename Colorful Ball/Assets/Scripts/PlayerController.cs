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
            //fiziksel çarpýþma durumlarýnda collider mekaniðinin etkin bir biçimde çalýþmasý için transform.position kullanmak yerine fizik iþlemleri tercih edilmelidir.
            if(touch.phase == TouchPhase.Moved)
            {
                rb.velocity = new Vector3(touch.deltaPosition.x * moveSpeed * Time.deltaTime, transform.position.y, touch.deltaPosition.y * moveSpeed * Time.deltaTime);
            }
        }
    }

}
