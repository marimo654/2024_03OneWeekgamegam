using UnityEngine;

namespace nuuspace
{
    public class BacteriaGenerator : MonoBehaviour
    {
        [SerializeField] GameObject bacteriaPrefab;
        [SerializeField] float span = 1.0f;
        [SerializeField] float delta = 0;
        GameManager gameManagerScript;
        [SerializeField] int saikinLimit;
        // Start is called before the first frame update
        void Start()
        {
            delta = 0f;
            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
            if (delta > span)  //deltaがspanより大きくなったら
            {
                if (gameManagerScript.bacteriaCounter < saikinLimit)
                {
                    float x = Random.Range(-4f, 4f);
                    float y = Random.Range(-4f, 4f);
                    float z = Random.Range(-4f, 4f);
                    while (x * x + y * y > 16)
                    {
                        x = Random.Range(-4f, 4f);
                        y = Random.Range(-4f, 4f);
                        z = Random.Range(-4f, 4f);
                    }

                    Instantiate(bacteriaPrefab, new Vector3(x, y, z), bacteriaPrefab.transform.rotation);
                    gameManagerScript.bacteriaCounter += 1;
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