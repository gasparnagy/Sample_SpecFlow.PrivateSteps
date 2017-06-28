using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Infrastructure;

namespace PrivateSteps.SpecFlowPlugin
{
    public class PrivateScopedMatchService : StepDefinitionMatchService
    {
        private readonly Assembly testAssembly;

        public PrivateScopedMatchService(IBindingRegistry bindingRegistry, IStepArgumentTypeConverter stepArgumentTypeConverter, ITestRunnerManager testRunnerManager) : base(bindingRegistry, stepArgumentTypeConverter)
        {
            testAssembly = GetTestAssembly(testRunnerManager);
        }

        private Assembly GetTestAssembly(ITestRunnerManager testRunnerManager)
        {
            //TODO: replace this with testRunnerManager.TestAssembly when upgrading to v2.2
            return (Assembly)testRunnerManager.GetType()
                .GetField("testAssembly", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(testRunnerManager);
        }

        protected override IEnumerable<BindingMatch> GetCandidatingBindingsForBestMatch(StepInstance stepInstance, CultureInfo bindingCulture)
        {
            return base.GetCandidatingBindingsForBestMatch(stepInstance, bindingCulture)
                .Where(m => IsPublic(m.StepBinding.Method));
        }

        private bool IsPublic(IBindingMethod stepBindingMethod)
        {
            var runtimeMethod = stepBindingMethod as RuntimeBindingMethod;
            if (runtimeMethod == null)
                return true; // handle special cases

            var isPublic = runtimeMethod.MethodInfo.IsPublic;
            
            return isPublic || runtimeMethod.MethodInfo.DeclaringType.Assembly == testAssembly;
        }
    }
}