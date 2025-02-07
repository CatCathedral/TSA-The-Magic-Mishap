using UnityEngine;

public class finishpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Go to next level
            SceneController.instance.NextLevel();
        }

    }





}