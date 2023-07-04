﻿using System.IO;
using MemoryPack;

namespace ET
{
    namespace EventType
    {
        public struct EntryEvent1
        {
        }   
        
        public struct EntryEvent2
        {
        } 
        
        public struct EntryEvent3
        {
        } 
    }
    
    public static class Entry
    {
        public static void Init()
        {
            
        }
        
        public static void Start()
        {
            StartAsync().Coroutine();
        }
        
        private static async ETTask StartAsync()
        {
            WinPeriod.Init();
            
            MongoHelper.RegisterStruct<LSInput>();
            MongoHelper.Register();
            
            World.Instance.AddSingleton<OpcodeType>();
            World.Instance.AddSingleton<IdValueGenerater>();
            World.Instance.AddSingleton<ObjectPool>();
            World.Instance.AddSingleton<ActorMessageQueue>();
            World.Instance.AddSingleton<EntitySystemSingleton>();
            World.Instance.AddSingleton<LSEntitySystemSingleton>();
            World.Instance.AddSingleton<MessageDispatcherComponent>();
            World.Instance.AddSingleton<NumericWatcherComponent>();
            World.Instance.AddSingleton<AIDispatcherComponent>();
            World.Instance.AddSingleton<ActorMessageDispatcherComponent>();
            World.Instance.AddSingleton<NetServices>();
            World.Instance.AddSingleton<NavmeshComponent>();
            
            World.Instance.AddSingleton<FiberManager>();
            
            // 注意这里创建Main Fiber 服务端没有设置同步上下文，会导致await后面的代码回调到了其它线程，一定不要在这个await后面写代码
            await FiberManager.Instance.Create(SchedulerType.Main, ConstFiberId.Main, 0, SceneType.Main, "");
            // 注意下面不能加代码!!!!!!!!
        }
    }
}