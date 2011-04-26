using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Web.Configuration;
using System.Configuration.Provider;
using System.Data.SqlClient;
using System.Data;



/// <summary>
/// Summary description for MyRoleProvider
/// </summary>

namespace RestaurantApp
{
    public class MyRoleProvider : System.Web.Security.RoleProvider
    {
        public MyRoleProvider()
        {

        }

        //
        // A helper function to retrieve config values from the configuration file.
        //
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }



        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
            pApplicationName = GetConfigValue(config["applicationName"],
                                          System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);

            ConnectionStringSettings ConnectionStringSettings =
            ConfigurationManager.ConnectionStrings[config["connectionStringName"]];

            if (ConnectionStringSettings == null || ConnectionStringSettings.ConnectionString.Trim() == "")
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            connectionString = ConnectionStringSettings.ConnectionString;


        }

        private string pApplicationName;

        private string connectionString;

        public override string ApplicationName
        {
            get
            {
                return pApplicationName;
            }
            set
            {
                pApplicationName = value;
            }
        }

        public override void CreateRole(string roleName)
        {
            PersistData.MyRoleProcedures.CreateRole(roleName, connectionString,  ApplicationName);

        }
        
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return PersistData.MyRoleProcedures.DeleteRole(roleName, throwOnPopulatedRole,connectionString,  ApplicationName);
        }

        
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return PersistData.MyRoleProcedures.FindUsersInRole(roleName, usernameToMatch, connectionString,  ApplicationName);
        }


        

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            PersistData.MyRoleProcedures.AddUsersToRoles(usernames, roleNames, connectionString,  ApplicationName);
        }


        
        public override string[] GetAllRoles()
        {
            return PersistData.MyRoleProcedures.GetAllRoles(connectionString,  ApplicationName);
        }

        
        public override string[] GetRolesForUser(string username)
        {
            return PersistData.MyRoleProcedures.GetRolesForUser(username, connectionString,  ApplicationName);
        }

        
        public override string[] GetUsersInRole(string roleName)
        {
            return PersistData.MyRoleProcedures.GetUsersInRole(roleName, connectionString,  ApplicationName);

        }


        
        public override bool IsUserInRole(string username, string roleName)
        {
            return PersistData.MyRoleProcedures.IsUserInRole(username, roleName, connectionString,  ApplicationName);
        }


        
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            PersistData.MyRoleProcedures.RemoveUsersFromRoles(usernames, roleNames, connectionString,  ApplicationName);
        }


        
        public override bool RoleExists(string roleName)
        {
            return PersistData.MyRoleProcedures.RoleExists(roleName,connectionString,  ApplicationName);
        }
    }
}