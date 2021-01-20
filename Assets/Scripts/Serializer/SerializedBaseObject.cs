using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializedBaseObject : SerializedObject
{
    private BaseObjectData baseObjectData = new BaseObjectData();

    public override object getSaveData()
    {
        baseObjectData.x  = gameObject.transform.localPosition.x;
        baseObjectData.y  = gameObject.transform.localPosition.y;
        baseObjectData.z  = gameObject.transform.localPosition.z;

        baseObjectData.rx = gameObject.transform.localRotation.x;
        baseObjectData.ry = gameObject.transform.localRotation.y;
        baseObjectData.rz = gameObject.transform.localRotation.z;
        baseObjectData.rw = gameObject.transform.localRotation.w; 

        baseObjectData.sx  = gameObject.transform.localScale.x;
        baseObjectData.sy  = gameObject.transform.localScale.y;
        baseObjectData.sz  = gameObject.transform.localScale.z;

        baseObjectData.enabled = gameObject.activeSelf;

        return baseObjectData;
    }

    public override void setLoadData(object obj)
    {
        BaseObjectData data = (BaseObjectData) obj;
        if(data != null)
        {
            gameObject.transform.localPosition = new Vector3(data.x,data.y,data.z);
            gameObject.transform.localRotation = new Quaternion(data.rx,data.ry,data.rz,data.rw);
            gameObject.transform.localScale = new Vector3(data.sx,data.sy,data.sz);
            gameObject.SetActive(data.enabled);
        }
    }

    [System.Serializable]
    private class BaseObjectData
    {
        public float x;
        public float y;
        public float z;
        public float rx;
        public float ry;
        public float rz;
        public float rw;
        public float sx;
        public float sy;
        public float sz;
        public bool enabled;
    }
}
