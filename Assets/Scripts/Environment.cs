using UnityEngine;

public class Environment : MonoBehaviour
{
    // Start is called before the first frame update
    public static int enviroGenre;
    void Start()
    {
        enviroGenre = Random.Range(1, 5);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enviroGenre = Random.Range(1, 5);
        }
    }


}
