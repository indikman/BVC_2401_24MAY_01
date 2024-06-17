using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace indika.programmingclass.MVC
{
    [RequireComponent(typeof(Health))]
    public class HealthController : MonoBehaviour, IShootable
    {
        [SerializeField] private int basicDamage;

        private Health _health;
        void Start()
        {
            _health = GetComponent<Health>();
        }

        public void GetDamage()
        {
            _health.Decrement(basicDamage);
        }
    }
}
