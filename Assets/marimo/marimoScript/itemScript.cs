using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
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
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("kapuseruPrefab")){
            isKapuseru = true;
            alcoholCollider.radius = 3.0f;
            StartCoroutine(KapuseruFalseCoroutine());
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("rokeranPrefab")){
            isRokeran = true;
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("eiyouPrefab")){
            isEiyou = true;
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("sizukuPrefab")){
            isSizuku = true;
            Destroy(other.gameObject);
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
