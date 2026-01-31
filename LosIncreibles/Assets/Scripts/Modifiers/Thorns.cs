using UnityEngine;

public class Thorns : MonoBehaviour
{
    public Player player;
    public int thornsStack;

    void Awake()
    {
        player = GetComponent<Player>();
    }
   
}
