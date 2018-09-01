using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    /// <summary>
    /// Playerの操作処理
    /// </summary>
    public class PlayerController : NetworkBehaviour
    {
        void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }

            var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150f;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * 3f;

            transform.Rotate(0f, x, 0f);
            transform.Translate(0f, 0f, z);
        }
    }
}