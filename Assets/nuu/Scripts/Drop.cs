using UnityEngine;

namespace nuuspace
{
    public class Drop : BacteriaItemGetScript
    {
        [SerializeField] GameObject bacteriaPrefab;
        GameManager gameManagerScript;
        BacteriaManager bacteriaManager;
        [SerializeField] int instantBacteriaGenerateAmount;
        [SerializeField] Sprite nattoSprite;
        AudioSource audioSource;
        [SerializeField] AudioClip dropAudio;

        void Start()
        {
            bacteriaManager = GameObject.Find("BacteriaManager").GetComponent<BacteriaManager>();
            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        }
        protected override void OnDestroy()
        {
            audioSource.PlayOneShot(dropAudio);
            if (bacteriaPrefab != null)
            {
                for (int i = 0; i < instantBacteriaGenerateAmount; i++)
                {
                    if (gameManagerScript.bacteriaCounter < gameManagerScript.bacteriaLimit)
                    {
                        float x = Random.Range(-4f, 4f);
                        float y = Random.Range(-4f, 4f);
                        while (x * x + y * y > 16)
                        {
                            x = Random.Range(-4f, 4f);
                            y = Random.Range(-4f, 4f);
                        }

                        BacteriaGenerator instantiatedBacteria = Instantiate(bacteriaPrefab, new Vector2(x, y), bacteriaPrefab.transform.rotation).GetComponent<BacteriaGenerator>();
                        instantiatedBacteria.bacteriaManager = bacteriaManager;
                        instantiatedBacteria.gameManagerScript = gameManagerScript;
                        if (gameManagerScript.isNattoTime)
                        {
                            instantiatedBacteria.GetComponent<SpriteRenderer>().sprite = nattoSprite;
                        }
                        gameManagerScript.bacteriaCounter += 1;
                        bacteriaManager.bacteriaGenerators.Add(instantiatedBacteria);
                    }
                }
            }
        }
    }
}
