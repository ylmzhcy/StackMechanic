using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCollision : MonoBehaviour
{
    Vector3 _firstPos = new Vector3(0, 1, 0.65f);
    Vector3 _offPos = new Vector3(0, 0.33f, 0);

    [SerializeField]
    Transform _parent;

    public List<GameObject> moneys = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            if (moneys.Count <= 0)
            {
                other.gameObject.transform.parent = _parent;
                other.gameObject.transform.localPosition = _firstPos;
                moneys.Add(other.gameObject);
                other.gameObject.tag = "Untagged";
            }
            else
            {
                other.gameObject.transform.parent = _parent;
                other.gameObject.transform.localPosition = moneys[moneys.Count - 1].transform.localPosition + _offPos;
                moneys.Add(other.gameObject);
                other.gameObject.tag = "Untagged";
            }
        }
    }

}
