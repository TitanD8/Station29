using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    public int keyID;
    static bool keyCollected = false;
    public UnityEvent KeyCollected;

    private void Awake()
    {
        if(keyCollected)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyCollected.Invoke();
                keyCollected = true;
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject);
            }
        }
       
    }


}
