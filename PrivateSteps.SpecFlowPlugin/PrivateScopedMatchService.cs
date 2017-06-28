using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow.Bindings;
using TechTalk.SpecFlow.Bindings.Reflection;
using TechTalk.SpecFlow.Infrastructure;

namespace PrivateSteps.SpecFlowPlugin
{
    public class PrivateScopedMatchService : StepDefinitionMatchService
    {
        public PrivateScopedMatchService(IBindingRegistry bindingRegistry, IStepArgumentTypeConverter stepArgumentTypeConverter) : base(bindingRegistry, stepArgumentTypeConverter)
        {
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

            var hasPrivateAttr = Attribute.GetCustomAttribute(runtimeMethod.MethodInfo, typeof(PrivateStepAttribute)) != null;

            return !hasPrivateAttr;
        }
    }
}