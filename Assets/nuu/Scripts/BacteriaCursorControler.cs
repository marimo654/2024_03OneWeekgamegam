using UnityEngine;

namespace nuuspace
{
    public class BacteriaCursorControler : CursorControler
    {
        new void Start()
        {
            base.Start();
        }
        void Update()
        {
            base.UpdateBase(KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S);
        }
    }
}