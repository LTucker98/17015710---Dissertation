using UnityEngine;

public class LocalEnviroment : MonoBehaviour
{
    public int localGenre;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CrowdMember")
        {
            other.GetComponent<GenreAssignment>().enviroGenre = localGenre;
        }
    }
}
