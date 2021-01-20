using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedObject : MonoBehaviour
{
    // Start is called before the first frame update
    public string UUID;
    public virtual object getSaveData()
    {
        return new ObjectData { isActive = gameObject.activeSelf };
    }

    public virtual void setLoadData(object obj)
    {
        ObjectData data = (ObjectData) obj;
        if(data != null)
        {
            gameObject.SetActive(data.isActive);
        }
    }

    [System.Serializable]
    private class ObjectData
    {
        public bool isActive;
    }
}

