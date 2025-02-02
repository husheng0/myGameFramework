/********************************************************************************
** auth:  https://github.com/HushengStudent
** date:  2018/08/24 23:24:46
** desc:  RoleEntity;
*********************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class RoleEntity : AbsEntity
    {
        public override EntityTypeEnum EntityType
        {
            get
            {
                return EntityTypeEnum.Role;
            }
        }

        public BuffComponent BuffComp { get; private set; }

        protected override void InitializeEx()
        {
            base.InitializeEx();
            BuffComp = ComponentMgr.Instance.CreateComponent<BuffComponent>(this);
        }

        protected override void UnInitializeEx()
        {
            base.UnInitializeEx();
            ComponentMgr.Instance.ReleaseComponent<BuffComponent>(BuffComp);
        }
    }
}