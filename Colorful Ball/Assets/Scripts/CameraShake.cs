using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject Camera;
    public PlayerController playerController;
         
    public IEnumerator CameraShakes(float duration , float magnitude)
    {
        float timer = 0f;
        if (playerController.isDead == false) //eðer karakter ölmediyse girsin
        {
            playerController.isDead = true;
            while (timer < duration)
            {
                timer += Time.deltaTime;

                float x = Random.Range(-1f, 2f);
                float y = Random.Range(-1f, 2f);

                Camera.transform.localPosition = new Vector3(x * magnitude, y * magnitude, 0);

                //Bunu aþaðýya yazmayý da dene
                yield return new WaitForSecondsRealtime(0.001f);
            }
            
        }
        

        Camera.transform.localPosition = new Vector3(0, 0, 0);       
    }

    public void cameraShakeEffectCall()
    {
        StartCoroutine(CameraShakes(0.22f,0.4f));
    }

}
