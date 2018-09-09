using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Game
{
    /// <summary>
    /// プレイヤー
    /// </summary>
    public class Player : NetworkBehaviour
    {
        /// <summary>
        /// キャラクター
        /// </summary>
        private Character m_Character;


        /// <summary>
        /// プレイヤーの初期化
        /// </summary>
        public IEnumerator Initialize()
        {
            yield return CharacterLoader.Load("TestBlue", c => m_Character = c);
            m_Character.transform.SetParent(transform);
        }


#region Implements of NetworkBehaviour

        public override void OnStartClient()
        {
            StartCoroutine(Initialize());
            PlayerManager.I.Add(this);
        }

        public override void OnStartLocalPlayer()
        {
            gameObject.name = "LocalPlayer";
        }

#endregion // Implements of NetworkBehaviour


#region MonoBehaviour Message

        private void OnDestroy()
        {
            if (PlayerManager.I != null)
            {
                PlayerManager.I.Remove(this);
            }
        }

#endregion // MonoBehaviour Message
    }
}