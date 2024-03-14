using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace nuuspace
{
    public class BacteriaManager : MonoBehaviour
    {
        [SerializeField] Sprite nattoSprite;
        [SerializeField] Sprite bacteriaSprite;
        [SerializeField] float nattoDuration;
        // SpriteRenderer bacteriaSpriteRenderer;
        public List<BacteriaGenerator> bacteriaGenerators;
        Coroutine nattoCoroutineState;
        GameManager gameManager;
        void Start()
        {
            // bacteriaSpriteRenderer = GameObject.FindWithTag("saikin").GetComponent<SpriteRenderer>();
            bacteriaGenerators = new List<BacteriaGenerator>() { GameObject.FindWithTag("saikin").GetComponent<BacteriaGenerator>() };
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
        public void GetStar()
        {
            gameManager.isNattoTime = true;
            // if (bacteriaSpriteRenderer != null)
            {
                if (nattoCoroutineState == null)
                {
                    nattoCoroutineState = StartCoroutine(nattoCoroutine());
                }
                else
                {
                    StopCoroutine(nattoCoroutineState);
                    nattoCoroutineState = StartCoroutine(nattoCoroutine());
                }
            }
        }

        IEnumerator nattoCoroutine()
        {
            foreach (BacteriaGenerator bacteriaGenerator in bacteriaGenerators)
            {
                if (bacteriaGenerator != null)
                {
                    bacteriaGenerator.bacteriaSpriteRenderer.sprite = nattoSprite;
                }
            }
            yield return new WaitForSeconds(nattoDuration);
            bacteriaGenerators.RemoveAll(b => b == null);
            foreach (BacteriaGenerator bacteriaGenerator in bacteriaGenerators)
            {
                if (bacteriaGenerator != null)
                {
                    bacteriaGenerator.bacteriaSpriteRenderer.sprite = bacteriaSprite;
                }
            }
            gameManager.isNattoTime = false;
        }
    }
}
