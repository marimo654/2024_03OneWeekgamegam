using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

namespace nuuspace
{
    public class CursorLimit : InputSystemUIInputModule
    {
        public Vector2 minCursorPosition = new Vector2(0f, 0f);
        public Vector2 maxCursorPosition = new Vector2(Screen.width, Screen.height);

        protected override void ProcessMove(PointerEventData pointerEvent)
        {
            // カーソル座標を取得
            Vector2 currentPosition = pointerEvent.position;

            // 上限と下限を適用
            currentPosition.x = Mathf.Clamp(currentPosition.x, minCursorPosition.x, maxCursorPosition.x);
            currentPosition.y = Mathf.Clamp(currentPosition.y, minCursorPosition.y, maxCursorPosition.y);

            // バーチャルマウスの座標を更新
            pointerEvent.position = currentPosition;

            // 基本の処理を継続
            base.ProcessMove(pointerEvent);
        }
    }
}
