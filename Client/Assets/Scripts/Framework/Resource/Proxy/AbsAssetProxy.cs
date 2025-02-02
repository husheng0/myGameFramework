/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/12/10 01:23:56
** desc:  资源加载抽象父类;
*********************************************************************************/

using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Framework
{
    public abstract class AbsAssetProxy : IPool
    {
        /// 加载完成回调;
        private Action _onLoadFinish = null;
        /// 资源路径;
        public string AssetPath { get; protected set; }
        /// 是否加载完成;
        public bool IsFinish { get; protected set; }
        /// 取消了就不用执行异步加载的回调了;
        public bool IsCancel { get; protected set; }
        /// 是否卸载;
        public bool IsUnload { get; protected set; }
        /// 是否使用对象池;
        public bool IsUsePool { get; protected set; }
        /// 加载完成对象;
        protected Object AssetObject { get; set; }

        /// 初始化;
        public void Initialize(string path, bool isUsePool)
        {
            AssetPath = path;
            IsUsePool = isUsePool;
            IsCancel = false;
            IsFinish = false;
            IsUnload = false;
        }

        /// <summary>
        /// 添加加载完成回调;
        /// </summary>
        /// <param name="action"></param>
        public void AddLoadFinishCallBack(Action action)
        {
            if (action != null)
            {
                if (IsFinish)
                {
                    action();
                    return;
                }
                _onLoadFinish += action;
            }
        }

        /// 设置完成;
        public void OnFinish(Object target)
        {
            AssetObject = target;
            IsFinish = true;
            if (!IsCancel && !IsUnload && _onLoadFinish != null)
            {
                _onLoadFinish();
                _onLoadFinish = null;
                OnFinishEx();
            }
        }

        protected virtual void OnFinishEx() { }

        /// <summary>
        /// 卸载代理;
        /// </summary>
        /// <returns></returns>
        public bool UnloadProxy()
        {
            if (IsUnload)
            {
                LogHelper.PrintError("[AbsAssetProxy]UnloadProxy error,proxy is Unload.");
                return false;
            }
            if (IsFinish)
            {
                Unload();
                IsUnload = true;
                return true;
            }
            else
            {
                if (!IsCancel)
                {
                    CancelProxy();
                }
            }
            return false;
        }

        /// 取消代理,会自动卸载;
        protected void CancelProxy()
        {
            IsCancel = true;
            if (!UnloadProxy())
            {
                ResourceMgr.Instance.AddRemoveProxy(this);
            }
        }

        public void OnGet(params object[] args)
        {
            OnGetEx(args);
        }

        public void OnRelease()
        {
            _onLoadFinish = null;
            AssetPath = string.Empty;
            IsCancel = false;
            IsFinish = false;
            IsUnload = false;
            AssetObject = null;
            OnReleaseEx();
        }

        protected virtual void OnGetEx(params object[] args) { }

        protected virtual void OnReleaseEx() { }

        protected abstract void Unload();

        public virtual T GetInstantiateObject<T>() where T : Object
        {
            if (CanGet())
            {
                return GetInstantiateObjectEx<T>();
            }
            else
            {
                return null;
            }
        }
        protected abstract T GetInstantiateObjectEx<T>() where T : Object;

        public virtual T GetUnityAsset<T>() where T : Object
        {
            if (CanGet())
            {
                return GetUnityAssetEx<T>();
            }
            else
            {
                return null;
            }
        }
        protected abstract T GetUnityAssetEx<T>() where T : Object;

        public abstract void ReleaseInstantiateObject<T>(T t) where T : Object;

        protected bool CanInstantiate()
        {
            return AssetObject != null && (AssetObject is GameObject ||
                AssetObject is Material ||
                AssetObject is Mesh);
        }

        private bool CanGet()
        {
            if (IsUnload)
            {
                LogHelper.PrintError("[AbsAssetProxy]Get error,proxy is Unload.");
                return false;
            }
            if (!IsFinish)
            {
                LogHelper.PrintError("[AbsAssetProxy]Get error,proxy is not finish.");
                return false;
            }
            return true;
        }
    }
}
