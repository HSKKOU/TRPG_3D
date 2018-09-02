using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

namespace Game
{
	/// <summary>
	/// キャラクター
	/// </summary>
	public class Character : MonoBehaviour
	{
        /// <summary>
        /// キャラクターの種類
        /// </summary>
        public enum Type
        {
            None,       // 初期値
            Player,     // プレイヤー
            Enemy,      // 敵
            Npc,        // NPC
            Num
        }


        /// <summary>
        /// キャラクター種類
        /// </summary>
        private Type m_Type = Type.None;
        public Type CharaType { get { return m_Type; } }

		private void Awake()
		{
        }
    }
}