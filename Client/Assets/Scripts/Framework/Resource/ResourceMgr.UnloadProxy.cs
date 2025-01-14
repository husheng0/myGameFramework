/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/12/09 22:54:09
** desc:  资源加载代理;
*********************************************************************************/

using System;
using System.Collections.Generic;
using MEC;

namespace Framework
{
    public partial class ResourceMgr
    {
        #region Proxy

        public static Action onResourceInitAction = null;

        private List<AbsAssetProxy> _removeList = new List<AbsAssetProxy>();

        /// <summary>
        /// 排队删除还没加载完就删除的Proxy;
        /// </summary>
        private void UpdateProxy()
        {
            var count = _removeList.Count;
            for (int i = count - 1; i >= 0; i--)//倒序遍历删除;
            {
                var target = _removeList[i];
                if (target.UnloadProxy())
                {
                    _removeList.Remove(target);
                }
            }
        }

        public void AddRemoveProxy(AbsAssetProxy proxy)
        {
            _removeList.Add(proxy);
        }

        /// <summary>
        /// 等待加载完删除;
        /// </summary>
        /// <returns></returns>
        public IEnumerator<float> CancleAllProxy()
        {
            yield return Timing.WaitForOneFrame;
            while (true)
            {
                if (_removeList.Count > 0)
                {
                    yield return Timing.WaitForOneFrame;
                }
                else
                {
                    if (onResourceInitAction != null)
                    {
                        onResourceInitAction();
                    }
                    break;
                }
            }
        }

        #endregion
    }
}
