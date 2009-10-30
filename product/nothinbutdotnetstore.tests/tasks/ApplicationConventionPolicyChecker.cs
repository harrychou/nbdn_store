using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.extensions;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using MbUnit.Framework;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class ApplicationConventionPolicyChecker
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (StartupCommand))]
        public class all_conventions : concern
        {
            it should_be_followed = () =>
            {
                var failures = typeof (StartupCommand).Assembly.GetTypes()
                    .Where(type => typeof (StartupCommand).IsAssignableFrom(type))
                    .Where(type => ! type.IsAbstract)
                    .Where(type => type.IsClass)
                    .Where(type1 => ! follows_constructor_convention(type1));

                dump(failures);
            };

            static void dump(IEnumerable<Type> failures)
            {
                failures.each(type => Console.Out.WriteLine(type.Name));
                if (failures.Count() > 0) Assert.Fail();
            }

            static bool follows_constructor_convention(Type arg)
            {
                var greediest_contructor = arg.GetConstructors().First();

                return greediest_contructor.GetParameters().Count() == 1
                       && greediest_contructor.GetParameters().First().ParameterType.Equals(typeof (ContainerCoreService));
            }
        }
    }
}