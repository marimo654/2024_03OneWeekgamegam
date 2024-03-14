using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


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
        bool isRokeran;
        [SerializeField] float kapuseruDuration;
        private Coroutine nowKapuseruFalseCoroutine;
        [SerializeField] GameObject rokeran_hontai;
        [SerializeField] GameObject rokeran_sentan;
        private Transform startPoint; // スタート地点
        private Transform endPoint;   // エンド地点
        [SerializeField] float moveDuration = 2f; // 移動にかかる時間
        private Ease easeType = Ease.Linear; // 移動のイージング
        Vector3 startPointPosition;
        [SerializeField] RokeranScript rokeranScript;
        [SerializeField] Animator boonanime;
        

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
            else if (other.gameObject.CompareTag("hosiPrefab"))
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
            else if (other.gameObject.CompareTag("hosiPrefab"))
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
                    alcoholCollider.radius = 1.5f;

                    if (isKapuseru == false)
                    {
                        isKapuseru = true;
                        nowKapuseruFalseCoroutine = StartCoroutine(KapuseruFalseCoroutine());
                    }
                    else
                    {
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
                if (rokeranObjects.Count == 1)
                {
                    isRokeran = true;
                    rokeran_hontai.SetActive(true);
                    rokeran_sentan.SetActive(true);
                }
                GameObject obj = rokeranObjects[0];
                Destroy(obj);
                rokeranObjects.Remove(obj);
            }
        }

        IEnumerator KapuseruFalseCoroutine()
        {
            yield return new WaitForSeconds(kapuseruDuration);
            alcoholCollider.radius = 0.75f;
            isKapuseru = false;
        }

        void Start()
        {
            alcoholCollider = GetComponent<CircleCollider2D>();
            isKapuseru = false;
            startPoint = rokeran_sentan.transform;
            startPointPosition = startPoint.position;
            rokeran_hontai.SetActive(false);
            rokeran_sentan.SetActive(false);
            
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isRokeran == true)
                {
                    endPoint = transform;
                    MoveAlongRandomPath();
                }
                else
                {
                    DestroyCollidedObjects();
                }
            }

        }

        void MoveAlongRandomPath()
        {
            int currentWaypoint = 0;
            // スタート地点からエンド地点までのランダムなパスを生成
            Vector3[] path = GenerateRandomPath();

            // DoTweenを使ってオブジェクトをランダムなパスに沿って移動させる
            rokeran_sentan.transform.DOPath(path, moveDuration, PathType.CatmullRom, PathMode.TopDown2D)
                .SetEase(easeType)
                .SetSpeedBased()
                //.SetLookAt(0.05f, new Vector3(1, 0, 1)/*, Vector3.up*/)
                .OnWaypointChange(index =>
        {
            currentWaypoint = index;
        })
                .OnUpdate(() =>
        {
            // 現在の移動方向を取得
            Vector3 currentDirection = (path[currentWaypoint] - rokeran_sentan.transform.position).normalized;

            // 進行方向に90度回転させる
            Vector3 rotatedDirection = new Vector3(-currentDirection.y, currentDirection.x, 0f); // 90度回転

            // 回転角度を計算して設定
            float angle = Mathf.Atan2(rotatedDirection.y, rotatedDirection.x) * Mathf.Rad2Deg;
            rokeran_sentan.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        })
                .OnComplete(() =>
            {
                isRokeran = false;
                rokeran_sentan.transform.position = startPointPosition;
                rokeran_sentan.transform.rotation = Quaternion.Euler(0, 0, 45);
                
                rokeranScript.Saikinboon();
                rokeran_hontai.SetActive(false);
                rokeran_sentan.SetActive(false);

                boonanime.gameObject.transform.position = path[3];
                boonanime.Play("BoonAnime");
            });
        }

        Vector3[] GenerateRandomPath()
        {
            // スタート地点とエンド地点をベースにランダムなパスを生成
            Vector3[] path = new Vector3[4];
            path[0] = startPoint.position;
            path[3] = new Vector3(endPoint.position.x, endPoint.position.y, 0);
            // ランダムな中間地点を生成
            path[1] = GenerateRandomWaypoint();
            path[2] = GenerateRandomWaypoint();
            return path;
        }

        Vector3 GenerateRandomWaypoint()
        {
            return new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
        }
    }
}