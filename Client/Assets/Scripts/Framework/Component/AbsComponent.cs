/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/01/10 23:22:57
** desc:  ECS组件抽象基类;
*********************************************************************************/

namespace Framework
{
    /// <summary>
    /// 组件抽象基类;
    /// </summary>
    public abstract class AbsComponent
    {
        protected AbsComponent() { }

        public ObjectEx Owner { get; private set; }
        public AbsEntity Entity { get; private set; }
        public bool Enable { get; private set; }

        public virtual void FixedUpdateEx(float interval) { }
        public virtual void UpdateEx(float interval) { }
        public virtual void LateUpdateEx(float interval) { }

        /// <summary>
        /// 初始化Component;
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="go">gameObject</param>
        public void Initialize(ObjectEx owner)
        {
            Enable = true;
            OnAttachObjectEx(owner);
            if (Entity.gameObjectEx.IsLoadFinish)
            {
                OnAttachGoEx(Entity.gameObjectEx);
            }
            else
            {
                Entity.gameObjectEx.AddLoadFinishHandler(OnAttachGoEx);
            }
            EventSubscribe();
            InitializeEx();
        }

        /// <summary>
        /// 重置Component;
        /// </summary>
        public void UnInitialize()
        {
            DeAttachObjectEx();
            DeAttachGoEx();
            EventUnsubscribe();
            UnInitializeEx();
            Enable = false;
        }

        /// <summary>
        /// 初始化;
        /// </summary>
        protected virtual void InitializeEx() { }

        /// <summary>
        /// 重置;
        /// </summary>
        protected virtual void UnInitializeEx() { }

        /// <summary>
        /// Component附加Entity;
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void OnAttachObjectEx(ObjectEx owner)
        {
            Owner = owner;
            Entity = owner as AbsEntity;
        }

        /// <summary>
        /// Component附加GameObject;
        /// </summary>
        /// <param name="go"></param>
        protected virtual void OnAttachGoEx(GameObjectEx goEx) { }

        /// <summary>
        /// 重置Entity的附加;
        /// </summary>
        protected virtual void DeAttachObjectEx()
        {
            Owner = null;
            Entity = null;
        }

        /// <summary>
        /// 重置GameObject的附加;
        /// </summary>
        protected virtual void DeAttachGoEx()
        {
            if (!Entity.gameObjectEx.IsLoadFinish)
            {
                Entity.gameObjectEx.RemoveLoadFinishHandler(OnAttachGoEx);
            }
        }

        /// <summary>
        /// 注册事件;
        /// </summary>
        protected virtual void EventSubscribe() { }

        /// <summary>
        /// 注销事件;
        /// </summary>
        protected virtual void EventUnsubscribe() { }

        /// <summary>
        /// 进入场景;
        /// </summary>
        /// <param name="sceneId"></param>
        protected virtual void OnEnterScene(int sceneId) { }

        /// <summary>
        /// 离开场景;
        /// </summary>
        /// <param name="sceneId"></param>
        protected virtual void OnExitScene(int sceneId) { }

        protected void AddEvent(EventType type, EventHandler handler)
        {
            EventMgr.Instance.AddEvent(Owner, type, handler);
        }

        protected void RemoveEvent(EventType type)
        {
            EventMgr.Instance.RemoveEvent(Owner, type);
        }

        protected void FireEvent(EventType type, IEventArgs eventArgs)
        {
            EventMgr.Instance.FireEvent(Owner, type, eventArgs);
        }
    }
}
