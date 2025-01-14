/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2017/12/26 00:03:35
** desc:  游戏入口;
*********************************************************************************/

using UnityEngine;
using Framework;

public class Main : MonoBehaviour
{

    [SerializeField]
    public bool AssetBundleModel = false;

    void Awake()
    {
        StartGame();
    }

    /// 初始化游戏;
    private void StartGame()
    {
        GameMgr.AssetBundleModel = AssetBundleModel;

        GameMgr.Instance.Launch();
    }
}

/*

配置环境变量;
myGameFramework:
工程路径; 如C:/Users/husheng/Desktop/MyProject/4GameFramework/myGameFramework/ 

myGameFramework_protoc:
protoc.exe路径; 如c:/protobuf-3.0.0/src/

*/
