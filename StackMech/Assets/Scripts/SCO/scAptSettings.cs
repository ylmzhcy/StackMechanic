using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StackMoney
{
    [CreateAssetMenu(menuName = "StackMech/BuildInfo")]
    public class scAptSettings : ScriptableObject
    {
        [SerializeField]
        string _buildName;
        [SerializeField]
        private int _buildPrice;
        [SerializeField]
        private int _buildEarnMoneyCount;
        [SerializeField]
        private int _buildEarnMoneySecond;
        [SerializeField]
        private bool _isBought;
        [SerializeField]
        private int _givedMoney;

        [SerializeField]
        private Material _buildMaterial;

        public string buildName { get { return _buildName; } }
        public int buildPrice { get { return _buildPrice; } }
        public int buildEarnMoneyCount { get { return _buildEarnMoneyCount; } }
        public int buildEarnMoneySec { get { return _buildEarnMoneySecond; } }

        public bool buildIsBought { get { return _isBought; } set { _isBought = value; } }
        public int buildGivedMoney { get { return _givedMoney; } set { _givedMoney = value; } }

        public Material buildMaterial { get { return _buildMaterial; } set { _buildMaterial = value; } }

    }
}

