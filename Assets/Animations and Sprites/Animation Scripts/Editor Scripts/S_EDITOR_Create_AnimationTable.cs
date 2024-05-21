using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Tooltip("Creates Animation Table with selected folder's contents")]
public class S_EDITOR_Create_AnimationTable
{
    [MenuItem("Assets/Create/Animations/Batch Animation Table Creation")]
    public static void CreateAnimationTable()
    {
        //get the selected folder
        string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        if(!AssetDatabase.IsValidFolder(folderPath))        {
            Debug.LogError("Please select a folder containing animations");
            return;
        }

        //get all assets in folder
        List<SO_SpriteAnimation> selectedAnimations = new List<SO_SpriteAnimation>();
        string[] animationGUIDs = AssetDatabase.FindAssets("t:SO_SpriteAnimation", new string[] { folderPath });
        foreach (var guid in animationGUIDs)
        {
            SO_SpriteAnimation animation = AssetDatabase.LoadAssetAtPath<SO_SpriteAnimation>(AssetDatabase.GUIDToAssetPath(guid));
            if (animation != null) { selectedAnimations.Add(animation); }
        }

        // Create table
        SO_AnimationTable table = ScriptableObject.CreateInstance<SO_AnimationTable>();
        table.animations = selectedAnimations.ToArray();

        // Save table in selected folder's parent folder
        string parentFolder = Path.GetDirectoryName(folderPath);
        string parentFolderName = Path.GetFileName(parentFolder);
        string assetPath = Path.Combine(parentFolder, parentFolderName + "_AnimationTable.asset");
        AssetDatabase.CreateAsset(table, assetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
