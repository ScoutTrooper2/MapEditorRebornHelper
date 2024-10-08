using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DoorScript))]
public class RenameToDoorEditor : Editor
{
    private GameObject previewPrefab;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Preview Door"))
        {
            GameObject targetObject = ((DoorScript)target).gameObject;
            DoorScript doorScript = targetObject.GetComponent<DoorScript>();

            if (doorScript.PreviewPrefab != null)
            {
                if (previewPrefab != null)
                {
                    DestroyImmediate(previewPrefab);
                    previewPrefab = null;
                }
                else
                {
                    previewPrefab = (GameObject)PrefabUtility.InstantiatePrefab(doorScript.PreviewPrefab);
                    previewPrefab.transform.SetParent(targetObject.transform);
                    previewPrefab.transform.position = targetObject.transform.position;
                    previewPrefab.transform.rotation = targetObject.transform.rotation;
                    previewPrefab.transform.localScale = targetObject.transform.localScale;
                }
            }
            else
            {
                Debug.LogError("Prefab not set in DoorScript!");
            }
        }

        if (GUILayout.Button("Compile Door Name"))
        {
            GameObject targetObject = ((DoorScript)target).gameObject;
            DoorScript doorScript = targetObject.GetComponent<DoorScript>();

            if (targetObject != null)
            {
                Undo.RecordObject(targetObject, "Rename to Door");
                targetObject.name = $"Door_{doorScript.DoorType}_{doorScript.Name}_{doorScript.AllowToInteract}_{doorScript.IsLocked}_{doorScript.DoorHealth}_{doorScript.DoorIgnoredDamages}_{doorScript.DoorRequiredPermissions}";
                EditorUtility.SetDirty(targetObject);
            }
        }
    }
}