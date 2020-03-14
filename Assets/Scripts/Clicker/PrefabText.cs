using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Clicker
{
    public class PrefabText : MonoBehaviour
    {

        private bool _move;
    
        private Vector2 _vector;


        public void Update()
        {
            if (!_move) return;
            transform.Translate(_vector * Time.deltaTime);
        }

        public void Motion(ulong bonus)
        {
            transform.localPosition = Vector2.zero;
            GetComponent<Text>().text = $"+{bonus}";
            _vector = new Vector2(Random.Range(-5,5), Random.Range(-5, 5));
            _move = true;
        }
    }
}
