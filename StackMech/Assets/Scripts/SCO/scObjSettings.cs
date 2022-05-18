using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StackMoney
{
    [CreateAssetMenu(menuName = "StackMech/Settings")]
    public class scObjSettings : ScriptableObject
    {
        #region Player Settings
        [SerializeField]
        private float _moveSpeed;

        [SerializeField]
        private float _swipeSpeed;

        public float moveSpeed { get { return _moveSpeed; } }
        public float swipeSpeed { get { return _swipeSpeed; } }
        #endregion

        #region Stacking Settings
        [SerializeField]
        private GameObject _money;

        private int _moneyCount;

        [SerializeField]
        private float _moneyOffset;

        public GameObject objMoney { get { return _money; } }

        public float moneyOffset { get { return _moneyOffset; } }
        public int moneyCount { get { return _moneyCount; } set { _moneyCount = value; } }

        #endregion

    }

}