using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TigerForge;
using System;
using UnityEngine.SceneManagement;

public class StateSerializer : MonoBehaviour
{
    public void LoadFromFile(string fileName)
    {
        if(fileName == "" || fileName == null)
        {
            Debug.Log("No file specified to load");
            return;
        }

        EasyFileSave loadFile = new EasyFileSave(fileName);
        Debug.Log("Filename:" + loadFile.GetFileName());
        try
        {
            if(!loadFile.Load())
            {
                Debug.Log("loading issue");
                return;
            }

            object[] obj = Resources.FindObjectsOfTypeAll<SerializedObject>(); //this ensures disabled object are also considered

            foreach (object o in obj)
            {
                SerializedObject g = (SerializedObject) o;
                if(g != null && g.UUID == "")
                {
                    continue;
                }
                    
                var objData = loadFile.GetBinary(g.UUID);
                if(objData != null)
                {
                    g.setLoadData(objData);
                    Debug.Log(g.UUID + " is loaded");
                }
            }
            Debug.Log("loading done");  
   
        } catch(Exception e) {
            Debug.Log("Exception while loading file:" + e);
        } finally {
            loadFile.Dispose(); 
        }
    }

    public void SaveToFile(string fileName)
    {
        if(fileName == "" || fileName == null)
        {
            Debug.Log("No file specified to save");
            return;
        }

        EasyFileSave saveFile = new EasyFileSave(fileName);
        Debug.Log("Filename:" + saveFile.GetFileName());
        try
        {
            object[] obj = Resources.FindObjectsOfTypeAll<SerializedObject>(); //this ensures disabled object are also considered

            foreach (object o in obj)
            {
                SerializedObject g = (SerializedObject) o;
                if(g != null && g.UUID == "")
                {
                    continue;
                }
                
                saveFile.AddBinary(g.UUID, g.getSaveData());
                Debug.Log(g.UUID + " is saved");
            }
            saveFile.Save();
            Debug.Log("Saving done");

        } catch(Exception e) {
            Debug.Log("Exception while saving file:" + e);
        } finally {
            saveFile.Dispose(); 
        }
    }
}
