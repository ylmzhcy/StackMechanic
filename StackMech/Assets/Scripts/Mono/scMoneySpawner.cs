using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace StackMoney
{
    public class scMoneySpawner : MonoBehaviour
    {
        [SerializeField]
        scObjSettings _set;

        [SerializeField]
        Transform _parent;

        bool isCheck = true;

        public int _moneyCount = 0;

        System.Random rnd = new System.Random();
        void Start()
        {
            StartCoroutine(RandomSpawner(_set.objMoney));
        }

        void LateUpdate()
        {
            if (!isCheck)
            {
                StartCoroutine(RandomSpawner(_set.objMoney));
                isCheck = true;
            }
        }
        IEnumerator RandomSpawner(GameObject obj)
        {
            yield return new WaitForSeconds(2);
            while (_moneyCount < 20 && isCheck)
            {
                GameObject tmpObj = Instantiate(obj);
                _moneyCount++;
                tmpObj.transform.parent = _parent.transform;
                tmpObj.GetComponent<BoxCollider>().isTrigger = true;
                tmpObj.gameObject.tag = "Money";
                tmpObj.transform.localPosition = new Vector3(rnd.Next(-4, 4), transform.localPosition.y, rnd.Next(-4, 4));
                yield return new WaitForSeconds(2);
            }
            StopCoroutine(RandomSpawner(_set.objMoney));
            isCheck = false;
        }
    }
}

