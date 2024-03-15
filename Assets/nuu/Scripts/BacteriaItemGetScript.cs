using UnityEngine;

namespace nuuspace
{
    public class BacteriaItemGetScript : MonoBehaviour
    {
        protected bool isContacted;
        protected bool isClicked;
        void GetItem()
        {
            Destroy(gameObject);
        }

        protected virtual void OnDestroy()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && isContacted == true)
            {
                isClicked = true;
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
