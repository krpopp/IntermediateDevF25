using UnityEngine;

public class FlyBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = NoiseyMove(Time.time);
        transform.Translate(nextPos * Time.deltaTime);
    }

    Vector3 NoiseyMove(float time)
    {
        float x = Mathf.PerlinNoise1D(time * Random.Range(-2,2));
        x = x * Random.Range(-1, 2);
        float y = Mathf.PerlinNoise1D(time * Random.Range(-1,2));
        y = y * Random.Range(-1, 2);
        Vector3 nextPos = new Vector3(x, y);
        return Vector3.Normalize(nextPos);
    }
}
