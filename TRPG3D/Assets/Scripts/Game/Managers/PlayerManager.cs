using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

namespace Game
{
	/// <summary>
	/// プレイヤー管理
	/// </summary>
	public class PlayerManager : SingletonMono<PlayerManager>
	{
        /// <summary>
        /// 生成されたキャラクターのリスト
        /// </summary>
        private List<Player> m_PlayerList = new List<Player>();


        /// <summary>
        /// Player追加
        /// </summary>
        public void Add(Player player)
        {
            if (player != null)
            {
                m_PlayerList.Add(player);
                player.transform.SetParent(transform);
            }
        }

        /// <summary>
        /// Player削除
        /// </summary>
        public void Remove(Player player)
        {
            if (player != null)
            {
                m_PlayerList.Remove(player);
            }
        }

        /// <summary>
        /// LocalのPlayerを取得
        /// </summary>
        /// <returns></returns>
        public Player GetLocalPlayer()
        {
            foreach (var p in m_PlayerList)
            {
                if (p != null && p.isLocalPlayer)
                {
                    return p;
                }
            }

            return null;
        }
    }
}