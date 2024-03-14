using UnityEngine;

namespace nuuspace
{
    public class CursorControler : MonoBehaviour
    {
        Rigidbody2D rb2d;
        GameManager gameManager;
        Vector2 leftBottom;
        Vector2 rightTop;

        protected void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rb2d = GetComponent<Rigidbody2D>();
            leftBottom = Camera.main.ScreenToWorldPoint(Vector2.zero);
            rightTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        }

        protected void UpdateBase(KeyCode leftKeyCode, KeyCode rightKeyCode, KeyCode upKeyCode, KeyCode downKeyCode)
        {
            Vector2 movementManager = Vector2.zero;
            // リザルト画面でカーソル操作を受け付けないようにする
            if (gameManager.isGameRunning)
            {
                if (transform.position.x > leftBottom.x)
                {
                    if (Input.GetKey(leftKeyCode))
                        movementManager.x -= 1;
                }
                if (transform.position.x < rightTop.x)
                {
                    if (Input.GetKey(rightKeyCode))
                        movementManager.x += 1;
                }
                if (transform.position.y < rightTop.y)
                {
                    if (Input.GetKey(upKeyCode))
                        movementManager.y += 1;
                }
                if (transform.position.y > leftBottom.y)
                {
                    if (Input.GetKey(downKeyCode))
                        movementManager.y -= 1;
                }
            }
            rb2d.velocity = movementManager * gameManager.cursorSpeed;
        }
    }
}
