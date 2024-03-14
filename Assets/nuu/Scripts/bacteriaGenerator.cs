using UnityEngine;

namespace nuuspace
{
    public class BacteriaGenerator : MonoBehaviour
    {
        [SerializeField] GameObject bacteriaPrefab;
        [SerializeField] float span = 1.0f;
        [SerializeField] float delta = 0;
        public GameManager gameManagerScript;
        public BacteriaManager bacteriaManager;
        public SpriteRenderer bacteriaSpriteRenderer;
        [SerializeField] Sprite nattoSprite;

        void Start()
        {
            delta = 0f;
            if (gameManagerScript == null)
            {
                gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            if (bacteriaManager == null)
            {
                bacteriaManager = GameObject.Find("BacteriaManager").GetComponent<BacteriaManager>();
            }
            bacteriaSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            if (delta > span)  //deltaがspanより大きくなったら
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
                delta = 0; //経過時間リセット
            }
        }

        void OnDestroy()
        {
            gameManagerScript.bacteriaCounter -= 1;
        }
    }
}