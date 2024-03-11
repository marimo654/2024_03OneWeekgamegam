using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGenerator : MonoBehaviour
{
    public GameObject item; 
    public GameObject capsilePrefab;
    public GameObject rokeranPrefab;
    public GameObject eiyouPrefab;
    public GameObject sizukuPrefab;
    public float span = 10.0f;
    public float delta = 0;
    bool isKapuseru;
    bool isRokeran;
    bool isEiyou;
    bool isSizuku;
    CircleCollider2D alcoholCollider;
    [SerializeField] float kapuseruDuration;
    // Start is called before the first frame update
    void Start()
    {
        alcoholCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;   //経過時間deltaをフレーム毎に大きくしていく
        if(this.delta > this.span)  //deltaがspanより大きくなったら
        {
            float x = Random.Range(-4f, 4f);
            float y = Random.Range(-4f, 4f);
            float z = Random.Range(-4f, 4f);
            while(x*x + y*y > 16){
                x = Random.Range(-4f, 4f);
                y = Random.Range(-4f, 4f);
                z = Random.Range(-4f, 4f);
            }

            int dice = Random.Range(1,5);
            if(dice <= 1){
                item = Instantiate(capsilePrefab) as GameObject;
            }else if(dice <= 2){
                item = Instantiate(rokeranPrefab) as GameObject;
            }else if(dice <= 3){
                item = Instantiate(eiyouPrefab) as GameObject;
            }else{
                item = Instantiate(sizukuPrefab) as GameObject;
            }
            item.transform.position = new Vector3(x, y, z);

            this.delta = 0; //経過時間リセット
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("kapuseruPrefab")){
            isKapuseru = true;
            alcoholCollider.radius = 3.0f;
            StartCoroutine(KapuseruFalseCoroutine());
        }else if (other.gameObject.CompareTag("rokeranPrefab")){
            isRokeran = true;
        }else if (other.gameObject.CompareTag("eiyouPrefab")){
            isEiyou = true;
        }else if (other.gameObject.CompareTag("sizukuPrefab")){
            isSizuku = true;
        }else{
            isKapuseru = false;
            isRokeran = false;
            isEiyou = false;
            isSizuku = false;
        }
    }

    IEnumerator KapuseruFalseCoroutine()
    {
        yield return new WaitForSeconds(kapuseruDuration);
        alcoholCollider.radius = 1.5f;
        isKapuseru = false;
    }
}