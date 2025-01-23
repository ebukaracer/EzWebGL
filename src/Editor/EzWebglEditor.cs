using System;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Racer.EzWebGL.Editor
{
    internal class EzWebglEditor : EditorWindow
    {
        private static bool _isTemplateImported;
        private const string PkgId = "com.racer.ezwebgl";
        private const string ContextMenuPath = "Racer/EzWebGL/";
        private const string SubRootPath = "Assets/WebGLTemplates/EzWebGL";
        private const string RootPath = "Assets/WebGLTemplates";
        private static readonly string SourcePath = $"Packages/{PkgId}/EzWebGL";

        private static RemoveRequest _removeRequest;


        [MenuItem(ContextMenuPath + "Import Template", false)]
        private static void ImportCore()
        {
            if (Directory.Exists(SubRootPath))
            {
                Debug.Log(
                    $"Root directory already exists: '{SubRootPath}'" +
                    "\nIf you would like to re-import, remove and reinstall this package.");
                return;
            }

            if (!Directory.Exists(SourcePath))
            {
                Debug.LogError(
                    "Source path is missing. Please ensure this package is installed correctly," +
                    $" otherwise reinstall it.\nNonexistent Path: {SourcePath}");
                return;
            }

            try
            {
                DirUtils.CreateDirectory(RootPath);
                Directory.Move(SourcePath, SubRootPath);
                DirUtils.MoveMetaFile(SourcePath, SubRootPath);
                AssetDatabase.Refresh();
                _isTemplateImported = AssetDatabase.IsValidFolder(SubRootPath);
                Debug.Log($"Imported successfully at '{SubRootPath}'");
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"An error occurred while importing the template: {e.Message}\n{e.StackTrace}");
            }
        }


        [MenuItem(ContextMenuPath + "Import Template", true)]
        private static bool ValidateImportTemplate()
        {
            _isTemplateImported = AssetDatabase.IsValidFolder(SubRootPath);
            return !_isTemplateImported;
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
                    DirUtils.DeleteDirectory(SubRootPath);
                    AssetDatabase.Refresh();

                    break;
                }
                case >= StatusCode.Failure:
                    Debug.LogWarning($"Failed to remove package: '{PkgId}'");
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

        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void MoveMetaFile(string source, string destination)
        {
            if (!File.Exists(source + ".meta")) return;

            File.Move(source + ".meta", destination + ".meta");
        }

        public static void DeleteEmptyMetaFiles(string directory)
        {
            if (Directory.Exists(directory)) return;

            var metaFile = directory + ".meta";

            if (File.Exists(metaFile))
                File.Delete(metaFile);
        }
    }
}