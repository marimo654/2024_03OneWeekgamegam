using UnityEngine;

namespace nuuspace
{
    public class BacteriaCursorControler : MonoBehaviour
    {
        Rigidbody2D rb2d;
        GameManager gameManager;

        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Vector2 movementManager = Vector2.zero;
            if (gameManager.isGameRunning)
            {
                if (Input.GetKey(KeyCode.A))
                    movementManager.x -= 1;
                if (Input.GetKey(KeyCode.D))
                    movementManager.x += 1;
                if (Input.GetKey(KeyCode.W))
                    movementManager.y += 1;
                if (Input.GetKey(KeyCode.S))
                    movementManager.y -= 1;
            }
            rb2d.velocity = movementManager * gameManager.cursorSpeed;
        }
    }
}