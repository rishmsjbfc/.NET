using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//Package requied for plugin
using Microsoft.Xrm.Sdk;
namespace ClassRoomSample
{
    public class ContactPlugin:IPlugin
    {
        /// A plug-in that creates a follow-up task activity when a new account is created.
        /// Register this plug-in on the Create message, account entity,
        /// and asynchronous mode
        public void Execute(IServiceProvider serviceProvider)
        {
            // Obtain the execution context from the service provider
            IPluginExecutionContext context = (IPluginExecutionContext)
                serviceProvider.GetService(typeof(IPluginExecutionContext));
            // The InputParameters collection contains all the data
            //passed in the message request.
            ITracingService tracingService = (ITracingService)
                serviceProvider.GetService(typeof(ITracingService));
            
            if(context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.
                Entity entity = (Entity)context.InputParameters["Target"];
                // Obtain the organization service reference.
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)
                    serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);
                try
                {

                    // Create a task activity to follow up with the account customer in 7 days
                    Entity followup = new Entity("task");
                    followup["subject"] = "Send e-mail to the new customer.";
                    followup["description"] = "Follow up with the customer. Check if there are any new issues" +
                                              "that need resolution.";
                    followup["scheduledstart"] = DateTime.Now;
                    followup["scheduledend"] = DateTime.Now.AddDays(2);
                    followup["category"] = context.PrimaryEntityName;

                    // Refer to the contact in the task activity.
                    if (context.OutputParameters.Contains("id"))
                    {
                        Guid regardingobjectid = new Guid(context.OutputParameters["id"].ToString());
                        string regardingobjectidType = "contact";
                        followup["regardingobjectid"] =
                           new EntityReference(regardingobjectidType, regardingobjectid);
                    }
                    // Create the followup activity
                    service.Create(followup);
                }
                catch(FaultException<OrganizationServiceFault>ex)
                {
                    throw new InvalidPluginExecutionException("An error occured in the plugin");
                }
                catch (Exception ex)
                {
                    throw new InvalidPluginExecutionException(ex.Message);
                }
                
            }
            
        }
    }
}

//catch (FaultException<OrganizationServiceFault> ex)
//{
//    throw new InvalidPluginExecutionException(ex.Message);
//}
