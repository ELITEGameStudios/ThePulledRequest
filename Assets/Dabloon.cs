using UnityEngine;

public class Dabloon : MonoBehaviour
{
    public int time = 10;
    public float liveTime = 0;
    public bool dabloonActive => liveTime <= 0;
    public SpriteRenderer renderer;

    void Update()
    {
        renderer.enabled = dabloonActive;   
        if(!dabloonActive) liveTime -= Time.deltaTime;
    }

    public void TakeDabloon()
    {
        liveTime = time;
    }
}
