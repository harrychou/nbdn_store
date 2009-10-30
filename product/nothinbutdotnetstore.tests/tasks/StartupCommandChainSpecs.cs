 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks.startup;
 using developwithpassion.bdd.mocking.rhino;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class StartupCommandChainSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<StartupCommandChain>
         {
        
         }

         public class SomeOtherCommand : StartupCommand {
             public void run()
             {
                 throw new NotImplementedException();
             }
         }
         public class SomeCommand : StartupCommand {
             public void run()
             {
                 throw new NotImplementedException();
             }
         }
         [Concern(typeof(StartupCommandChain))]
         public class when_running_all_of_the_commands_in_a_set_of_command_types : concern
         {
             context c = () =>
             {
                 first_command = an<StartupCommand>();
                 second_command = an<StartupCommand>();
                 command_types = new List<Type>(); 
                 command_types.Add(typeof(SomeCommand));
                 command_types.Add(typeof(SomeOtherCommand));
                 command_factory = the_dependency<StartupCommandFactory>();

                 command_factory.Stub(factory => factory.create_command_from(typeof (SomeCommand))).Return(first_command);
                 command_factory.Stub(factory => factory.create_command_from(typeof (SomeOtherCommand))).Return(second_command);
                 provide_a_basic_sut_constructor_argument(typeof(SomeCommand));
             };

             because b = () =>
             {
                 sut.run_all_commands_in(command_types); 
             };

        
             it should_run_all_of_the_commands_for_the_command_types = () =>
             {
                 first_command.received(command => command.run());
                 second_command.received(command => command.run()); 
             };

             static StartupCommand first_command;
             static StartupCommand second_command;
             static IList<Type> command_types;
             static StartupCommandFactory command_factory;
         }
     }
 }
