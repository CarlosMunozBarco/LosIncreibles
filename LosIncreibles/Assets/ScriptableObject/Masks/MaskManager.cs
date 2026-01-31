using UnityEngine;

public class MaskManager : MonoBehaviour
{
    public static MaskManager Instance;
    public Mask currentMask;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        EquipMask(currentMask);
    }

    public void ChangeMask(Mask newMask)
    {
        QuitMask();
        EquipMask(newMask);
    }

    private void QuitMask()
    {
        if (currentMask != null)
        {
            currentMask.RemoveMaskEffect();
            currentMask = null;
        }
    }

    public void EquipMask(Mask newMask)
    {
        currentMask = newMask;
        currentMask.ApplyMaskEffect();
    }

}
