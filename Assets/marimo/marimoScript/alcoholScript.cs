using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace marimo
{
    public class alcoholScript : MonoBehaviour
    {
        public string targetTag = "saikin";
        private List<GameObject> saikinObjects = new List<GameObject>();
        private List<GameObject> kapuseruObjects = new List<GameObject>();
        private List<GameObject> rokeranObjects = new List<GameObject>();
        CircleCollider2D alcoholCollider;
        bool isKapuseru;
        [SerializeField] float kapuseruDuration;
        private Coroutine nowKapuseruFalseCoroutine;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                saikinObjects.Add(other.gameObject);
            }
            else if (other.gameObject.CompareTag("kapuseruPrefab"))
            {
                kapuseruObjects.Add(other.gameObject);
            }
            else if (other.gameObject.CompareTag("rokeranPrefab"))
            {
                rokeranObjects.Add(other.gameObject);
            }

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                saikinObjects.Remove(other.gameObject);
            }
            else if (other.gameObject.CompareTag("kapuseruPrefab"))
            {
                kapuseruObjects.Remove(other.gameObject);
            }
            else if (other.gameObject.CompareTag("rokeranPrefab"))
            {
                rokeranObjects.Remove(other.gameObject);
            }
        }

        // Enter(Return)が押されたときに呼び出す関数
        private void DestroyCollidedObjects()
        {
            while (saikinObjects.Count > 0)
            {
                GameObject obj = saikinObjects[0];
                Destroy(obj);
                saikinObjects.Remove(obj);
            }
            while (kapuseruObjects.Count > 0)
            {
                if (kapuseruObjects.Count == 1)
                {
                    alcoholCollider.radius = 3.0f;

                    if(isKapuseru == false){
                        isKapuseru = true;
                        nowKapuseruFalseCoroutine = StartCoroutine(KapuseruFalseCoroutine());
                    }else{
                        StopCoroutine(nowKapuseruFalseCoroutine);
                        nowKapuseruFalseCoroutine = StartCoroutine(KapuseruFalseCoroutine());
                    }
                }

                GameObject obj = kapuseruObjects[0];
                Destroy(obj);
                kapuseruObjects.Remove(obj);
            }
            while (rokeranObjects.Count > 0)
            {
                GameObject obj = rokeranObjects[0];
                Destroy(obj);
                rokeranObjects.Remove(obj);
            }
        }

        IEnumerator KapuseruFalseCoroutine()
        {
            yield return new WaitForSeconds(kapuseruDuration);
            alcoholCollider.radius = 1.5f;
            isKapuseru = false;
        }

        void Start()
        {
            alcoholCollider = GetComponent<CircleCollider2D>();
            isKapuseru = false;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DestroyCollidedObjects();
            }
        }
    }
}