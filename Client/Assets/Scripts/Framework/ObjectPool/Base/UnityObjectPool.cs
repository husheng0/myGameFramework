/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/03/01 23:14:44
** desc:  Unity Object对象池;
*********************************************************************************/

using MEC;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Framework.ObjectPool
{
    internal class UnityObjectPool
    {
        private Stopwatch _stopwatch;
        private Dictionary<int, Stack<Object>> _unityObjectDict;
        private Dictionary<int, int> _unityObjectRefDict;

        public int UnityObjectPoolMaxCount { get; set; }

        public UnityObjectPool()
        {
            UnityObjectPoolMaxCount = 50;
            _stopwatch = new Stopwatch();
            _unityObjectDict = new Dictionary<int, Stack<Object>>();
            _unityObjectRefDict = new Dictionary<int, int>();
        }

        public Object GetUnityObject(Object asset)
        {
            if (null == asset)
            {
                return null;
            }
            int instanceID = asset.GetInstanceID();
            Stack<Object> stack;
            if (!_unityObjectDict.TryGetValue(instanceID, out stack))
            {
                stack = new Stack<Object>();
                _unityObjectDict[instanceID] = stack;
            }
            Object element;
            if (stack.Count == 0)
            {
                element = Object.Instantiate(asset);
            }
            else
            {
                element = stack.Pop();
            }
            _unityObjectRefDict[element.GetInstanceID()] = instanceID;
            GameObject go = element as GameObject;
            if (go)
            {
                go.transform.SetParent(null);
            }
            return element;
        }

        public void ReleaseUnityObject(Object asset)
        {
            Object element = asset;
            if (null == element)
            {
                return;
            }
            int instanceID = element.GetInstanceID();
            Stack<Object> stack;
            int parentInstanceID;
            if (_unityObjectDict.ContainsKey(instanceID))
            {
                parentInstanceID = instanceID;
            }
            else
            {
                if (!_unityObjectRefDict.TryGetValue(instanceID, out parentInstanceID))
                {
                    /*
                    stack = new Stack<Object>();
                    _unityObjectPoolPool[instanceId] = stack;
                    parentInstanceId = instanceId;
                    */

                    /// not create form pool or parents destroyed;
                    LogHelper.PrintWarning(string.Format("[UnityObjectPool]Release unity object error:{0}.", element.name));

                    Object.Destroy(element);

                    return;
                }
            }
            if (!_unityObjectDict.TryGetValue(parentInstanceID, out stack))
            {
                stack = new Stack<Object>();
                _unityObjectDict[parentInstanceID] = stack;
            }
            if (stack.Count > UnityObjectPoolMaxCount)
            {
                Object.Destroy(element);
                return;
            }
            stack.Push(element);
            GameObject go = element as GameObject;
            if (go)
            {
                go.transform.SetParent(PoolMgr.Instance.Root.transform);
                go.transform.position = Vector3.zero;
                go.transform.rotation = Quaternion.Euler(Vector3.zero);
                go.transform.localScale = Vector3.one;
            }
        }

        public IEnumerator<float> ClearUnityObjectPool()
        {
            Dictionary<int, Stack<Object>> objectPool = new Dictionary<int, Stack<Object>>(_unityObjectDict);
            _unityObjectRefDict = new Dictionary<int, int>();
            _unityObjectDict = new Dictionary<int, Stack<Object>>();
            _stopwatch.Reset();
            _stopwatch.Start();
            foreach (var temp in objectPool)
            {
                Stack<Object> target = temp.Value;
                if (target == null || target.Count < 1)
                {
                    continue;
                }
                while (target.Count > 0)
                {
                    Object go = target.Pop();
                    if (go == null)
                    {
                        continue;
                    }
                    Object.Destroy(go);
                    if (_stopwatch.Elapsed.Milliseconds >= ResourceMgr.Instance.MAX_LOAD_TIME)
                    {
                        _stopwatch.Stop();
                        yield return Timing.WaitForOneFrame;
                    }
                }
            }
        }
    }
}
