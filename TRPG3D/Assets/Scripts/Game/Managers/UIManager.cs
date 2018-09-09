using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Utils;

namespace Game
{
	/// <summary>
	/// UI管理
	/// </summary>
	public class UIManager : SingletonMono<UIManager>
	{
        /// <summary>
        /// フィルター
        /// </summary>
        [SerializeField]
        private GameObject m_Filter;

        /// <summary>
        /// フィルターをクリックしたときに発火するイベント
        /// </summary>
        public event Action onClickFilterEvent;

        /// <summary>
        /// フィルターをクリックしたときにフィルターを閉じるか？
        /// </summary>
        private bool m_IsCloseFilterByClick = false;


        /// <summary>
        /// フィルター表示
        /// </summary>
        public void ShowFilter(bool isCloseByClick = false)
        {
            m_IsCloseFilterByClick = isCloseByClick;
            m_Filter.SetActive(true);
        }

        /// フィルター非表示
        public void HideFilter()
        {
            m_IsCloseFilterByClick = false;
            m_Filter.SetActive(false);
        }

        /// <summary>
        /// フィルターをクリックしたイベント発行
        /// </summary>
        public void OnClickFilter()
        {
            onClickFilterEvent.SafeInvoke();
            if (m_IsCloseFilterByClick)
            {
                HideFilter();
            }
        }



#region MonoBehaviour Message

        private void Awake()
        {
            HideFilter();
        }

#endregion // MonoBehaviour Message
    }
}