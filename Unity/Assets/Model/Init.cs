using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ETModel
{
    public class Init : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            this.StartAsync().Coroutine();
        }

        private async ETVoid StartAsync()
        {
            try
            {
                SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);

                DontDestroyOnLoad(gameObject);
                ClientConfigHelper.SetConfigHelper();
                Game.EventSystem.Add(DLLType.Core, typeof(Core).Assembly);
                Game.EventSystem.Add(DLLType.Model, typeof(Init).Assembly);

                Game.Scene.AddComponent<GlobalConfigComponent>(); //web资源服务器设置组件
                Game.Scene.AddComponent<ResourcesComponent>(); //资源加载组件

                //测试输出正确加载了Config所带的信息
                ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundle("config.unity3d");
                Game.Scene.AddComponent<ConfigComponent>();
                ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle("config.unity3d");
                UnitConfig unitConfig = (UnitConfig)Game.Scene.GetComponent<ConfigComponent>().Get(typeof(UnitConfig), 1001);
                Log.Debug($"config {JsonHelper.ToJson(unitConfig)}");
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
        }
        // Update is called once per frame
        void Update()
        {
            OneThreadSynchronizationContext.Instance.Update();
            Game.EventSystem.Update();
        }

        private void LateUpdate()
        {
            Game.EventSystem.LateUpdate();
        }

        private void OnApplicationQuit()
        {
            Game.Close();
        }
    }
}

