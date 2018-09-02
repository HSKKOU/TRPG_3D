using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Net
{
    /// <summary>
    /// このプロジェクト専用のNetworkManager
    /// </summary>
    public class TRPGNetworkManager : NetworkManager
    {
        /// <summary>
        /// このシングルトンのインスタンス
        /// </summary>
        private static TRPGNetworkManager m_Instance;
        public static TRPGNetworkManager I
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = singleton as TRPGNetworkManager;
                }
                return m_Instance;
            }
        }

        /// <summary>
        /// Playerが追加された時のイベント
        /// </summary>
        public event Action<GameObject> onAddPlayer;

        /// <summary>
        /// Playerが削除された時のイベント
        /// </summary>
        public event Action<GameObject> onRemovePlayer;


#region Implements of NetworkManager

        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
            GameObject playerObject = (GameObject)Instantiate(playerPrefab);
            NetworkServer.AddPlayerForConnection(conn, playerObject, playerControllerId);
            onAddPlayer.SafeInvoke(playerObject);
        }


        public override void OnServerRemovePlayer(NetworkConnection conn, PlayerController player)
        {
            onRemovePlayer.SafeInvoke(player.gameObject);
            base.OnServerRemovePlayer(conn, player);
        }

#endregion // Implements of NetworkManager


        /// <summary>
        /// Playerの入れ替え
        /// </summary>
        /// <param name="conn">Playerの接続情報</param>
        /// <param name="playerObj">PlayerのGameObject</param>
        /// <param name="playerControllerId">PlayerのNetwork用のId</param>
        public void ReplacePlayer(NetworkConnection conn, GameObject playerObj, short playerControllerId)
        {
            NetworkServer.ReplacePlayerForConnection(conn, playerObj, playerControllerId);
        }


        private void OnDestroy()
        {
            NetworkServer.DisconnectAll();
        }
    }
}