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
        public void Add(GameObject playerObj)
        {
            if (playerObj != null)
            {
                Player player = playerObj.GetComponent<Player>();
                if (player != null)
                {
                    player.transform.SetParent(transform);
                    if (player.isLocalPlayer)
                    {
                        player.name = "LocalPlayer";
                    }
                    m_PlayerList.Add(player);

                    StartCoroutine(player.Initialize());
                }
            }
        }

        /// <summary>
        /// Player削除
        /// </summary>
        public void Remove(GameObject playerObj)
        {
            if (playerObj != null)
            {
                Player player = playerObj.GetComponent<Player>();
                if (player != null)
                {
                    m_PlayerList.Remove(player);
                }
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


#region MonoBehaviour Message

        private void Awake()
        {
            Net.TRPGNetworkManager.I.onAddPlayer += Add;
            Net.TRPGNetworkManager.I.onRemovePlayer += Remove;
        }


        private void OnDestroy()
        {
            if (Net.TRPGNetworkManager.I != null)
            {
                Net.TRPGNetworkManager.I.onAddPlayer -= Add;
                Net.TRPGNetworkManager.I.onRemovePlayer -= Remove;
            }
        }

#endregion // MonoBehaviour Message
    }
}