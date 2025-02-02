/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/10/21 23:40:35
** desc:  打包编辑器;
* 打包流程:
* 1.打AssetBundle;
* 2.压缩AssetBundle;
* 3.拷贝AssetBundle压缩包;
* 4.打包;
* 
* 
*********************************************************************************/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Framework
{
    public class PackEditor : EditorWindow
    {
        [MenuItem("myGameFramework/Window/PackEditor &#b", false, 4)]
        static void ShowWindow()
        {
            var window = GetWindowWithRect(typeof(PackEditor), new Rect(0, 0, 1280, 720), true, "打包编辑器");
            window.Show();
        }

        private enum BuildPlatform
        {
            Android = BuildTarget.Android,
            IOS = BuildTarget.iOS,
            Windows64 = BuildTarget.StandaloneWindows64,
        }

        private BuildPlatform _platform = BuildPlatform.Windows64;
        private BuildOptions _buildOptions = BuildOptions.AllowDebugging | BuildOptions.Development;
        private string _locationPathName = string.Empty;
        private bool _isCompletePack = true;
        private bool _isBuildAssetBundle = true;
        private bool _isRelease = false;

        private void OnEnable()
        {
            _locationPathName = Application.dataPath + "/../BuildResult";
            _isCompletePack = true;
            _isBuildAssetBundle = true;
            _isRelease = false;
        }

        void OnGUI()
        {
            GUIStyle style = new GUIStyle
            {
                fontSize = 18
            };
            var color = GUI.backgroundColor;

            //搜索框;
            GUILayout.BeginHorizontal(GUI.skin.FindStyle("Toolbar"));
            string searchString = "";
            searchString = GUILayout.TextField(searchString, GUI.skin.FindStyle("ToolbarSeachTextField"));
            if (GUILayout.Button("", GUI.skin.FindStyle("ToolbarSeachCancelButton")))
            {
                searchString = "";
                GUI.FocusControl(null);
            }
            GUILayout.EndHorizontal();

            if (GUILayout.Button("File", EditorStyles.toolbarDropDown, GUILayout.Width(50)))
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("设置"), false, () =>
                {
                    LogHelper.PrintError("File->设置");
                });
                menu.ShowAsContext();
            }

            using (var v = new EditorGUILayout.VerticalScope(GUI.skin.box))
            {
                GUILayout.Space(5);
                using (var vv = new EditorGUILayout.VerticalScope(GUI.skin.box))
                {
                    EditorGUILayout.LabelField("打包", style);
                    GUILayout.Space(5);
                    using (var h = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("选择目标平台:", style);
                        GUILayout.Space(15);
                        _platform = (BuildPlatform)EditorGUILayout.EnumPopup(_platform);
                    }
                    GUILayout.Space(5);
                    using (var h = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("打包选项:", style);
                        GUILayout.Space(15);
                        _buildOptions = (BuildOptions)EditorGUILayout.EnumFlagsField(_buildOptions);
                    }
                    GUILayout.Space(5);
                    using (var h = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("是否打Release包:", style);
                        GUILayout.Space(15);
                        bool curValue = _isRelease;
                        _isRelease = EditorGUILayout.Toggle(_isRelease);
                        if (_isRelease)
                        {
                            _buildOptions = BuildOptions.None;
                        }
                        else
                        {
                            if (curValue)
                            {
                                _buildOptions = BuildOptions.AllowDebugging | BuildOptions.Development;
                            }
                        }
                    }
                    GUILayout.Space(5);
                    using (var h = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("打包资源完整完整包体:", style);
                        GUILayout.Space(15);
                        _isCompletePack = EditorGUILayout.Toggle(_isCompletePack);
                    }
                    GUILayout.Space(5);
                    using (var h = new EditorGUILayout.HorizontalScope())
                    {
                        EditorGUILayout.LabelField("重新打包AssetBundle:", style);
                        GUILayout.Space(15);
                        _isBuildAssetBundle = EditorGUILayout.Toggle(_isBuildAssetBundle);
                        if (_isRelease)
                        {
                            _isBuildAssetBundle = true;
                        }
                    }
                    GUILayout.Space(20);
                    GUI.backgroundColor = Color.green;
                    if (GUILayout.Button("开始打包", GUILayout.Height(30)))
                    {
                        if (EditorUtility.DisplayDialog("提示", "确认开始打包?", "确认"))
                        {
                            _locationPathName = EditorUtility.OpenFolderPanel("选择输出文件夹", _locationPathName, "");
                            EditorApplication.delayCall += () =>
                            {
                                if (string.IsNullOrEmpty(_locationPathName))
                                {
                                    return;
                                }
                                if (Directory.Exists(_locationPathName))
                                {
                                    Directory.Delete(_locationPathName, true);
                                }
                                Directory.CreateDirectory(_locationPathName);

                                if (_isBuildAssetBundle)
                                {
                                    AssetBundleGenerate.GenerateAll();
                                }
                                if (_isCompletePack)
                                {
                                    ExportABPackage.ExportAssetBundlePackage();
                                }
                                else
                                {
                                    if (File.Exists(ExportABPackage.ZipStreamingAssetsPath))
                                    {
                                        File.Delete(ExportABPackage.ZipStreamingAssetsPath);
                                    }
                                }
                                string report = string.Empty;
                                try
                                {
                                    string extensionName = string.Empty;
                                    switch (_platform)
                                    {
                                        case BuildPlatform.Android:
                                            extensionName = ".apk";
                                            break;
                                        case BuildPlatform.Windows64:
                                            extensionName = ".exe";
                                            break;
                                        default:
                                            break;
                                    }
                                    BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
                                    buildPlayerOptions.scenes = EditorBuildSettingsScene.GetActiveSceneList(EditorBuildSettings.scenes);
                                    buildPlayerOptions.locationPathName = _locationPathName + "/" + PlayerSettings.productName + extensionName;
                                    buildPlayerOptions.target = (BuildTarget)_platform;
                                    buildPlayerOptions.options = _buildOptions;
                                    report = BuildPipeline.BuildPlayer(buildPlayerOptions);
                                }
                                catch (Exception e)
                                {
                                    LogHelper.PrintError(string.Format("打包失败:{0},{1}.", report, e.ToString()));
                                    return;
                                }
                                LogHelper.PrintError(string.Format("打包成功:{0}.", report));
                            };
                            Close();
                        }
                    }
                    GUI.backgroundColor = color;
                }
                GUILayout.Space(10);
                using (var vv = new EditorGUILayout.VerticalScope(GUI.skin.box))
                {
                    EditorGUILayout.LabelField("打热更包", style);
                    GUILayout.Space(5);
                }
            }
        }
    }
}