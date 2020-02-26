using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] [Range(0, 30000000)]private float waitTime;
    public GameObject loader;

    private void FixedUpdate()
    {
        while (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
            Debug.Log(waitTime);
            if (waitTime <= 0)
            {
                End();
            }
        }
    }

    private void End()
    {
        loader.SetActive(false);
    }
}
