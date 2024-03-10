using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alcoholScript : MonoBehaviour
{
    public string targetTag = "saikin";
    private List<GameObject> collidedObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            collidedObjects.Add(other.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            collidedObjects.Remove(other.gameObject);
        }
    }

    // Kボタンが押されたときに呼び出す関数
    private void DestroyCollidedObjects()
    {
        while(collidedObjects.Count > 0)
        {
            GameObject obj = collidedObjects[0];
            Destroy(obj);
            collidedObjects.Remove(obj);
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            DestroyCollidedObjects();
            Debug.Log("marimodayo");
        }   
    }
}
