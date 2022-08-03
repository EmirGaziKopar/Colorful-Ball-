using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform vectorBack;
    public Transform vectorForward;
    public Transform vectorLeft;
    public Transform vectorRight;


    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        //bu pozisyonun bu vektorlerin dýþýnda bir deðer almasýný engeller.
        viewPos.x = Mathf.Clamp(viewPos.x, vectorLeft.position.x, vectorRight.position.x);
        viewPos.z = Mathf.Clamp(viewPos.z, vectorBack.position.z, vectorForward.position.z);

        transform.position = viewPos;

    }
}
