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
        public event Action<Net.MatchRoomInfo> onRequestRoomInfoEvent;

        /// <summary>
        /// キャンセルボタンを押したときのイベント
        /// </summary>
        public event Action onCancelEvent;


        /// <summary>
        /// ルーム情報をリクエスト
        /// </summary>
        public void OnClickRequest()
        {
            var info = new Net.MatchRoomInfo();
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