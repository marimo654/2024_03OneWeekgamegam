using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace marimo
{
    public class MuddyScript : MonoBehaviour
    {
        private float doronkoPositionX;
        private float doronkoPositionY;
        private float doronkoDelta;
        [SerializeField] float doronkoGenerateSpan;
        [SerializeField] float doronkoLifeSpan;
        [SerializeField] GameObject doronko;
        private GameObject cachedDoronko;
        // Start is called before the first frame update
        void Start()
        {
            doronkoPositionX = transform.position.x;
            doronkoPositionY = transform.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            doronkoDelta += Time.deltaTime;
            if (doronkoDelta > doronkoGenerateSpan)
            {
                float x = Random.Range(-1.5f, 1.5f);
                float y = Random.Range(-1.5f, 1.5f);

                while (x * x + y * y > 1.5f * 1.5f)
                {
                    x = Random.Range(-1.5f, 1.5f);
                    y = Random.Range(-1.5f, 1.5f);
                }

                cachedDoronko = Instantiate(doronko, new Vector2(doronkoPositionX + x, doronkoPositionY + y), doronko.transform.rotation);
                Destroy(cachedDoronko, doronkoLifeSpan);
                doronkoDelta = 0f;
            }
        }
    }
}