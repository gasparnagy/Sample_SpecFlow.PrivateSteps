using System;
using PrivateSteps.SpecFlowPlugin;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Plugins;

[assembly:RuntimePlugin(typeof(PrivateStepsPlugin))]

namespace PrivateSteps.SpecFlowPlugin
{
    public class PrivateStepsPlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters)
        {
            runtimePluginEvents.CustomizeTestThreadDependencies += (sender, args) =>
            {
                args.ObjectContainer.RegisterTypeAs<PrivateScopedMatchService, IStepDefinitionMatchService>();
            };
        }
    }
}
