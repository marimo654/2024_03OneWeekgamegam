using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace nuuspace
{
    public class AlocoholCursorControler : MonoBehaviour
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
            if (Input.GetKey(KeyCode.LeftArrow))
                movementManager.x -= 1;
            if (Input.GetKey(KeyCode.RightArrow))
                movementManager.x += 1;
            if (Input.GetKey(KeyCode.UpArrow))
                movementManager.y += 1;
            if (Input.GetKey(KeyCode.DownArrow))
                movementManager.y -= 1;
            rb2d.velocity = movementManager * gameManager.cursorSpeed;
        }
    }
}
