using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace indika.programmingclass.MVC
{
    public class Shooter : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.Log("RAY GEN!" + ray.direction);
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity))
                {
                    Debug.Log("SHOOT!");
                    var shootable = hit.transform.GetComponent<IShootable>();
                    shootable?.GetDamage();
                }
            }
        }
    }
}
