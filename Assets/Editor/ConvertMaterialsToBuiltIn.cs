using UnityEngine;
using UnityEditor;

public class ConvertMaterialsToBuiltIn : EditorWindow
{
    [MenuItem("Tools/Convert URP Materials to Built-in")]
    public static void ConvertURPMaterials()
    {
        string[] materialGuids = AssetDatabase.FindAssets("t:Material", new[] { "Assets" });

        int converted = 0;

        foreach (string guid in materialGuids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null && mat.shader.name.Contains("Universal Render Pipeline"))
            {
                Undo.RecordObject(mat, "Convert URP Material");
                mat.shader = Shader.Find("Standard");
                Debug.Log($"Converted: {mat.name}");
                converted++;
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.DisplayDialog("Conversion Complete", $"Converted {converted} materials to Built-in Standard shader.", "OK");
    }
}
