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
        private const string FullContextMenuPath = ContextMenuPath + "Import Template (force)";
        private const string TemplateAssetsPath = "Assets/WebGLTemplates/EzWebGL";


        [MenuItem(FullContextMenuPath, false)]
        private static void ImportTemplate()
        {
            var path = $"Packages/{PkgId}/Dependencies~/Package/{AssetPkgId}";

            if (File.Exists(path))
                AssetDatabase.ImportPackage(path, true);
            else
                EditorUtility.DisplayDialog("Missing Package File", $"{AssetPkgId} not found in the package.", "OK");
        }

        [MenuItem(ContextMenuPath + "Remove Package (recommended)")]
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
                        AssetDatabase.DeleteAsset(TemplateAssetsPath);
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
}