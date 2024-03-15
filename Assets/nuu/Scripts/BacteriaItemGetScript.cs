using UnityEngine;

namespace nuuspace
{
    public class BacteriaItemGetScript : MonoBehaviour
    {
        bool isContacted;
        void GetItem()
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
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("bacteriaCursor"))
            {
                isContacted = false;
            }
        }
    }
}
