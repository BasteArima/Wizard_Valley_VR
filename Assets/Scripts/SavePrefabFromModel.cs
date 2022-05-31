using UnityEngine;

public class SavePrefabFromModel : MonoBehaviour
{
    [SerializeField] private GameObject[] _models;

#if UNITY_EDITOR
    [ContextMenu("Save prefab from models")]
    public void SaveCityPrefab()
    {
        foreach(var obj in _models)
        {
            Transform finalModel;

            if (obj.transform.childCount > 0)
            {
                finalModel = obj.transform.GetChild(0);

                if (finalModel.name.Contains("UCX"))
                    finalModel = obj.transform.GetChild(1);
                else if (finalModel.name.Contains("UCX"))
                    finalModel = obj.transform.GetChild(2);
            }
            else
            {
                finalModel = obj.transform;
            }

            var newObj = Instantiate(finalModel.gameObject);
            var prefabModel = UnityEditor.PrefabUtility.SaveAsPrefabAsset(newObj, "Assets/Prefabs/" + newObj.name + ".prefab");
            Debug.Log($"Success! The prefab {prefabModel} saved!");
            DestroyImmediate(newObj);
        }
    }
#endif
}
