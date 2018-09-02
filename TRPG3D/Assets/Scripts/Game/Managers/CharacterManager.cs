using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utils;

namespace Game
{
	/// <summary>
	/// キャラクター管理
	/// </summary>
	public class CharacterManager : SingletonMono<CharacterManager>
	{
        /// <summary>
        /// 生成されたキャラクターのリスト
        /// </summary>
        private List<Character> m_CharacterList = new List<Character>();


        /// <summary>
        /// Characterを追加
        /// </summary>
        /// <param name="character">新規キャラクター</param>
        public void Add(Character character)
        {
            m_CharacterList.Add(character);
        }

        /// <summary>
        /// Characterを削除
        /// </summary>
        /// <param name="character">削除するキャラクター</param>
        public void Remove(Character character)
        {
            m_CharacterList.Remove(character);
        }

        /// <summary>
        /// Typeに該当するCharacterをすべて取得
        /// </summary>
        public IEnumerable<Character> FindAll(Character.Type type = Character.Type.None)
        {
            return m_CharacterList.FindAll(c => type == Character.Type.None || c.CharaType == type);
        }
    }
}