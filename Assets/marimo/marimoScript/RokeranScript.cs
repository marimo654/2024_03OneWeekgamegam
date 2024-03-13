using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace marimo
{
    public class RokeranScript : MonoBehaviour
    {
        public string targetTag = "saikin";
        private List<GameObject> saikinObjects = new List<GameObject>();
        //[SerializeField] Animator boonAnime;

        // Start is called before the first frame update
        void Start()
        {
            //boonAnime = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                saikinObjects.Add(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                saikinObjects.Remove(other.gameObject);
            }
        }

        public void Saikinboon()
        {
            while (saikinObjects.Count > 0)
            {
                GameObject obj = saikinObjects[0];
                Destroy(obj);
                saikinObjects.Remove(obj);
                //boonAnime.SetBool("BoolBoon", true);
            }
        }
    }
}