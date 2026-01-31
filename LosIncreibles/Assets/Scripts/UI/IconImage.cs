using JetBrains.Annotations;
using UnityEngine;

public class IconImage : MonoBehaviour
{
    public IconType type;

    private void Update()
    {
        CheckModifier();
    }

    public void CheckModifier()
    {
        bool destroy = false;

        if(type == IconType.Poison && GetComponentInParent<Poison>() == null )
        {
            destroy = true;
        }

        if (type == IconType.Laugh && GetComponentInParent<Laugh>() == null)
        {
            destroy = true;
        }

        if (type == IconType.Thorns && GetComponentInParent<Thorns>() == null)
        {
            destroy = true;
        }

        if (type == IconType.Bandages && GetComponentInParent<Bandages>() == null)
        {
            destroy = true;
        }

        if(destroy)
        {
            Destroy(gameObject);
        }
    }
}
