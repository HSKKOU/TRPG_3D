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
            yield return CharacterLoader.Load("Character001", c => m_Character = c);
            m_Character.transform.SetParent(transform);
        }
    }
}