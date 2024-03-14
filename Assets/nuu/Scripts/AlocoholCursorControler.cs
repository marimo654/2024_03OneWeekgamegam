using System.Buffers.Text;
using UnityEngine;

namespace nuuspace
{
    public class AlocoholCursorControler : CursorControler
    {
        new void Start()
        {
            base.Start();
        }

        void Update()
        {
            base.UpdateBase(KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);
        }
    }
}
