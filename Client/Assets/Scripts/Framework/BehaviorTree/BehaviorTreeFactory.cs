/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/06/24 01:43:40
** desc:  行为树工厂;
*********************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public static class BehaviorTreeFactory
    {
        private static AbsBehavior _rootBehavior = null;
        private static Dictionary<int, AbsBehavior> _behaviorDict = new Dictionary<int, AbsBehavior>();
        private static Dictionary<int, List<int>> _connectionDict = new Dictionary<int, List<int>>();

        public static BehaviorTree CreateBehaviorTree(AbsEntity entity, string path)
        {
            InitDict(path);
            if (_rootBehavior == null)
            {
                LogHelper.PrintError("[BehaviorTreeFactory]Root Behavior is null!");
                return null;
            }
            GenerateConnect(new List<AbsBehavior>() { _rootBehavior });
            BehaviorTree tree = new BehaviorTree(_rootBehavior, entity);
            _rootBehavior = null;
            _behaviorDict.Clear();
            _connectionDict.Clear();
            return tree;
        }

        private static void InitDict(string path)
        {
            _rootBehavior = null;
            _behaviorDict.Clear();
            _connectionDict.Clear();
            TextAsset json = Resources.Load<TextAsset>(path);
            string content = json.text.Replace("\r", "").Replace("\n", "");
            Hashtable table = MiniJsonExtensions.hashtableFromJson(content);
            ArrayList nodeList = table["nodes"] as ArrayList;
            ArrayList connectionList = table["connections"] as ArrayList;
            for (int i = 0; i < nodeList.Count; i++)
            {
                Hashtable nodeTable = nodeList[i] as Hashtable;
                var id = 0;
                if (int.TryParse(nodeTable["$id"].ToString(), out id))
                {
                    AbsBehavior absBehavior = CreateBehavior(nodeTable, id);
                    _behaviorDict[id] = absBehavior;
                    if (_rootBehavior == null)
                    {
                        _rootBehavior = absBehavior;
                    }
                    else
                    {
                        if (absBehavior.Id < _rootBehavior.Id)
                        {
                            _rootBehavior = absBehavior;
                        }
                    }
                }
                else
                {
                    LogHelper.PrintError("[BehaviorTreeFactory]try get node id error!");
                }
            }
            for (int i = 0; i < connectionList.Count; i++)
            {
                Hashtable connectionTable = connectionList[i] as Hashtable;
                int source = 0;
                int target = 0;
                Hashtable scurceNode = connectionTable["_sourceNode"] as Hashtable;
                Hashtable targetNode = connectionTable["_targetNode"] as Hashtable;
                if (int.TryParse(scurceNode["$ref"].ToString(), out source)
                    && int.TryParse(targetNode["$ref"].ToString(), out target))
                {
                    List<int> list;
                    if (!_connectionDict.TryGetValue(source, out list))
                    {
                        _connectionDict[source] = new List<int>();
                        list = _connectionDict[source];
                    }
                    list.Add(target);
                }
                else
                {
                    LogHelper.PrintError("[BehaviorTreeFactory]try get source id and target id error!");
                }
            }
        }

        private static void GenerateConnect(List<AbsBehavior> list)
        {
            List<AbsBehavior> nextList = new List<AbsBehavior>();
            AbsBehavior target;
            for (int i = 0; i < list.Count; i++)
            {
                target = list[i];
                int id = target.Id;
                List<int> connectList;
                if (!_connectionDict.TryGetValue(id, out connectList))
                {
                    continue;
                }
                List<AbsBehavior> sonList = new List<AbsBehavior>();
                for (int j = 0; j < connectList.Count; j++)
                {
                    int sonId = connectList[j];
                    AbsBehavior son;
                    if (!_behaviorDict.TryGetValue(sonId, out son))
                    {
                        continue;
                    }
                    if (son != null)
                    {
                        sonList.Add(son);
                    }
                }
                if (target.IsComposite)
                {
                    AbsComposite composite = target as AbsComposite;
                    if (sonList.Count < 1)
                    {
                        composite.Serialize(null);
                    }
                    else
                    {
                        composite.Serialize(sonList);
                        nextList.AddRange(sonList);
                    }
                }
                else
                {
                    AbsDecorator decorator = target as AbsDecorator;
                    if (sonList.Count < 1)
                    {
                        decorator.Serialize(null);
                    }
                    else
                    {
                        decorator.Serialize(sonList[0]);
                        nextList.Add(sonList[0]);
                    }
                }
            }
            if (nextList.Count > 0)
            {
                GenerateConnect(nextList);
            }
        }

        private static AbsBehavior CreateBehavior(Hashtable table, int id)
        {
            AbsBehavior behavior = null;
            string type = table["$type"].ToString();
            string[] str = type.Split(".".ToCharArray());
            if (3 == str.Length)
            {
                string name = "Framework." + str[2];
                Type target = Type.GetType(name);
                behavior = Activator.CreateInstance(target, table) as AbsBehavior;
            }
            if (behavior != null)
            {
                behavior.Id = id;
            }
            return behavior;
        }
    }
}