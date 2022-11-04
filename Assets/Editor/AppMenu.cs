using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AppMenu : MonoBehaviour
{
    static string packageFile = "Unity 2-03.unitypackage";

    [MenuItem("JUNSU/Export Backup", false, 0)]
    static void action01()
    {
        string[] exportpaths = new string[]
        {
            "Assets/Animations",
            "Assets/Editor",
            "Assets/Fonts",
            "Assets/Resources",
            "Assets/Materials",
            "Assets/Scenes",
            "Assets/Plugins",
            "Assets/Scripts",
            "Assets/Sprites",
            "ProjectSettings/TagManager.asset",
            "ProjectSettings/EditorBuildSettings.asset"
        };
        AssetDatabase.ExportPackage(exportpaths, packageFile,
            ExportPackageOptions.Interactive |
            ExportPackageOptions.Recurse |
            ExportPackageOptions.IncludeDependencies
        );

        print("Backup Export Complete!");
    }

    [MenuItem("JUNSU/Import Backup", false, 1)]
    static void action02()
    {
        AssetDatabase.ImportPackage(packageFile, true);
    }

    [MenuItem("JUNSU/PlayerPrefs Remove", false, 2)]
    static void action03()
    {
        PlayerPrefs.DeleteAll();
    }
}
