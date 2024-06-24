using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace indika.programmingclass
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Vector3 targetPosition;

        [SerializeField] private float speed;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(moveCube());
        }

        IEnumerator moveCube()
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
