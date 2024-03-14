using System.Collections.Generic;
using UnityEngine;

namespace nuuspace
{
    public class BacteriaItemGetScript : MonoBehaviour
    {
        bool isContacted;
        // List<GameObject> collidedObjects = new List<GameObject>();
        protected void GetItem()
        {
            isContacted = false;
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isContacted == true)
            {
                GetItem();
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("bacteriaCursor"))
            {
                isContacted = true;
                // collidedObjects.Add(gameObject);
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("bacteriaCursor"))
            {
                isContacted = false;
                // collidedObjects.Remove(gameObject);
            }
        }
    }
}
