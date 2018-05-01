using UnityEngine;

public class ChainCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        Chain.IsFired = false;

        if(col.CompareTag("Ball"))
        {
            col.GetComponent<Ball>().Split();
        }
    }
}
