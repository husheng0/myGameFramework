/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/12/23 21:07:40
** desc:  AssetBundle资源加载代理;
*********************************************************************************/

namespace Framework
{
    public class AssetBundleAssetProxy : AbsAssetProxy
    {
        private bool storage;

        public new void Initialize(string path, bool isUsePool)
        {
            base.Initialize(path, isUsePool);
            storage = false;
        }

        protected override void Unload()
        {
            /// 如果使用对象池了,说明需要贮存,依赖AssetBundleMgr自动卸载;
            if (!storage)
            {
                AssetBundleMgr.Instance.UnloadAsset(AssetPath, AssetObject);
            }
            PoolMgr.Instance.ReleaseCsharpObject(this);
        }

        protected override T GetInstantiateObjectEx<T>()
        {
            if (AssetObject != null && CanInstantiate())
            {
                return PoolMgr.Instance.GetUnityObject(AssetObject) as T;
            }
            return null;
        }

        public override void ReleaseInstantiateObject<T>(T t)
        {
            if (t != null)
            {
                if (IsUsePool)
                {
                    PoolMgr.Instance.ReleaseUnityObject(t);
                    storage = true;
                }
                else
                {
                    ResourceMgr.Instance.DestroyInstantiateObject(t);
                }
            }
        }

        protected override T GetUnityAssetEx<T>()
        {
            if (AssetObject != null && !CanInstantiate())
            {
                return AssetObject as T;
            }
            return null;
        }

        protected override void OnReleaseEx()
        {
            base.OnReleaseEx();
            storage = false;
        }
    }
}
