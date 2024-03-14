using System.Collections;
using UnityEngine;

namespace nuuspace
{
    public class AlcoholAnimationScript : MonoBehaviour
    {
        Transform alocoholCursorTransform;
        Animator sprayAnimation;
        [Header("どれくらいカーソルからずらすか")]
        [SerializeField] Vector2 shift;
        [Header("消えるまでの時間の補正")]
        [SerializeField] float fixDisappearTime;
        Coroutine sprayAnimationCoroutineState;

        void Start()
        {
            alocoholCursorTransform = GameObject.Find("alcohol Cursor image").transform;
            sprayAnimation = GameObject.Find("SprayNozzle").GetComponent<Animator>();

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                // 再生中にもう一回エンターキーを入力されたときにコルーチンをキャンセルする処理
                if (sprayAnimationCoroutineState != null)
                {
                    StopCoroutine(sprayAnimationCoroutineState);
                    sprayAnimation.StopPlayback();
                }
                // アニメーションのコルーチン開始
                sprayAnimationCoroutineState = StartCoroutine(SprayAnimationCoroutine());
            }
        }

        IEnumerator SprayAnimationCoroutine()
        {
            // 画面の右側か左側かで反転させる処理
            if (alocoholCursorTransform.position.x >= 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position = alocoholCursorTransform.position + new Vector3(shift.x, shift.y, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(180f, 0f, 180f);
                transform.position = alocoholCursorTransform.position + new Vector3(-shift.x, shift.y, 0f);
            }
            sprayAnimation.Play("SprayNozzleAnimation");
            // アニメーションの長さを取得してその分だけまつ
            float animationLength = sprayAnimation.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(animationLength - fixDisappearTime);
            // 再び画面外へ
            transform.position = new Vector2(15, 0);
            sprayAnimationCoroutineState = null;

        }
    }
}