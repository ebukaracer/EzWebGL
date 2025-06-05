using System.IO;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Racer.EzWebGL.Editor
{
    internal static class EzWebglEditor
    {
        private static RemoveRequest _removeRequest;

        private const string PkgId = "com.racer.ezwebgl";
        private const string AssetPkgId = "EzWebGL.unitypackage";

        private const string ContextMenuPath = "Racer/EzWebGL/";
        private const string FullContextMenuPath = ContextMenuPath + "Import Template(Force)";
        private const string TemplateAssetsPath = "Assets/WebGLTemplates/EzWebGL";


        [MenuItem(FullContextMenuPath, false)]
        private static void ImportTemplate()
        {
            var packagePath = $"Packages/{PkgId}/WebGLTemplates/{AssetPkgId}";

            if (File.Exists(packagePath))
                AssetDatabase.ImportPackage(packagePath, true);
            else
                EditorUtility.DisplayDialog("Missing Package File", $"{AssetPkgId} not found in the package.", "OK");
        }

        [MenuItem(ContextMenuPath + "Remove Package(recommended)")]
        private static void RemovePackage()
        {
            _removeRequest = Client.Remove(PkgId);
            EditorApplication.update += RemoveProgress;
        }

        private static void RemoveProgress()
        {
            if (!_removeRequest.IsCompleted) return;

            switch (_removeRequest.Status)
            {
                case StatusCode.Success:
                {
                    if (!Directory.Exists(TemplateAssetsPath)) return;

                    if (EditorUtility.DisplayDialog($"Remove {AssetPkgId}",
                            $"Also delete the template directory?\n\nPath: {TemplateAssetsPath}",
                            "Yes", "No"))
                    {
                        DirUtils.DeleteDirectory(TemplateAssetsPath);
                        AssetDatabase.Refresh();
                    }

                    break;
                }
                case >= StatusCode.Failure:
                    Debug.LogError($"Failed to remove package: '{PkgId}'");
                    break;
            }

            EditorApplication.update -= RemoveProgress;
        }
    }

    internal static class DirUtils
    {
        public static void DeleteDirectory(string path)
        {
            if (!Directory.Exists(path)) return;

            Directory.Delete(path, true);
            DeleteEmptyMetaFiles(path);
        }

        private static void DeleteEmptyMetaFiles(string directory)
        {
            if (Directory.Exists(directory)) return;

            var metaFile = directory + ".meta";

            if (File.Exists(metaFile))
                File.Delete(metaFile);
        }
    }
}