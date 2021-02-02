
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class OpcodeTestComponentSystem: AwakeSystem<OpcodeTestComponent>
    {
        public override void Awake(OpcodeTestComponent self)
        {
            self.Awake();
        }
    }

    public class OpcodeTestComponentLoadSystem:LoadSystem<OpcodeTestComponent>
    {
        public override void Load(OpcodeTestComponent self)
        {
            self.Load();
        }
    }
    public class OpcodeTestComponent : Component
    {
        public void Awake()
        {
            Log.Info("执行 OpcodeTest Awake方法");
        }
        public void Load()
        {
            Log.Info("执行 OpcodeTest Load方法");
        }
        public override void Dispose()
        {
            if(this.IsDisposed)
            {
                return;
            }
            base.Dispose();
        }
    }

}
