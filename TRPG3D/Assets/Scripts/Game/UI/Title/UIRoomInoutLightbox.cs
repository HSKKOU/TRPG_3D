using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utils;

namespace Game
{
	/// <summary>
	/// ルーム名を入力するLightbox
	/// </summary>
	public class UIRoomInoutLightbox : MonoBehaviour
	{
        /// <summary>
        /// ルーム情報
        /// </summary>
        public struct RoomInfo
        {
            /// <summary>
            /// ルーム名
            /// </summary>
            public string roomName;

            /// <summary>
            /// パスワード
            /// </summary>
            public string password;
        }

        /// <summary>
        /// ルーム名入力
        /// </summary>
        [SerializeField]
        private InputField m_RoomNameInputField;

        /// <summary>
        /// パスワード入力
        /// </summary>
        [SerializeField]
        private InputField m_PasswordInputField;


        /// <summary>
        /// ルーム情報を入力してOKを押したときのイベント
        /// </summary>
        public event Action<RoomInfo> onRequestRoomInfoEvent;

        /// <summary>
        /// キャンセルボタンを押したときのイベント
        /// </summary>
        public event Action onCancelEvent;


        /// <summary>
        /// ルーム情報をリクエスト
        /// </summary>
        public void OnClickRequest()
        {
            var info = new RoomInfo();
            info.roomName = m_RoomNameInputField.text;
            info.password = m_PasswordInputField.text;
            onRequestRoomInfoEvent.SafeInvoke(info);
        }

        /// <summary>
        /// キャンセル（閉じる、ほかの画面をタッチ）
        /// </summary>
        public void Cancel()
        {
            onCancelEvent.SafeInvoke();
        }
    }
}