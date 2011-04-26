using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;



namespace PersistData
{
    public class MyRoleProcedures
    {
        public static void CreateRole(string roleName, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_Roles_CreateRole]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            if ((int)cmd.Parameters[2].Value != 0)
                throw new Exception("aspnet_Roles_CreateRole not executed correctedly");
        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_Roles_DeleteRole] 
        // @ApplicationName
        //,@RoleName
        //,@DeleteOnlyIfRoleIsEmpty
        public static bool DeleteRole(string roleName, bool throwOnPopulatedRole, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_Roles_DeleteRole]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));

            cmd.Parameters.Add(new SqlParameter("@DeleteOnlyIfRoleIsEmpty", SqlDbType.Bit, 1,
                ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, throwOnPopulatedRole));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            if ((int)cmd.Parameters[3].Value != 0)
                return false;
            else
                return true;
        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_FindUsersInRole] 
        // @ApplicationName
        //,@RoleName
        //,@UserNameToMatch
        public static string[] FindUsersInRole(string roleName, string usernameToMatch, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_FindUsersInRole]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));

            cmd.Parameters.Add(new SqlParameter("@UserNameToMatch", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 1, 0, "", DataRowVersion.Current, usernameToMatch));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();



            SqlDataReader sr = cmd.ExecuteReader();



            if ((int)cmd.Parameters[3].Value != 0)
                throw new Exception("aspnet_UsersInRoles_FindUsersInRole not executed correctedly");


            List<string> userList = new List<string>();

            while (!sr.Read())
            {
                userList.Add(sr.GetString(0));
            }


            conn.Close();

            string[] sA = new string[userList.Count];

            for (int i = 0; i < userList.Count; i++)
                sA[0] = userList[0];

            return sA;
        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_AddUsersToRoles] 
        // @ApplicationName
        //,@UserNames
        //,@RoleNames
        //,@CurrentTimeUtc
        public static void AddUsersToRoles(string[] usernames, string[] roleNames, string connectionString, string ApplicationName)
        {
            string UserNames = "";
            string RoleNames = "";
            foreach (string s in usernames)
            {
                UserNames += s + ",";
            }
            int len = UserNames.Length;
            if ((len > 0) && (UserNames[len - 1] == ','))
                UserNames = UserNames.Substring(0, len - 1);
            foreach (string s in roleNames)
            {
                RoleNames += s + ",";
            }

            len = RoleNames.Length;
            if ((len > 0) && (RoleNames[len - 1] == ','))
                RoleNames = RoleNames.Substring(0, len - 1);

            //
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_AddUsersToRoles]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@UserNames", SqlDbType.NVarChar, 4000,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, UserNames));

            cmd.Parameters.Add(new SqlParameter("@RoleNames", SqlDbType.NVarChar, 4000,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, RoleNames));


            cmd.Parameters.Add(new SqlParameter("@CurrentTimeUtc", SqlDbType.DateTime, 8,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, DateTime.UtcNow));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();


            conn.Close();

            if ((int)cmd.Parameters[4].Value != 0)
                throw new Exception("aspnet_Roles_GetAllRoles not executed correctly");
        }

        // EXECUTE @RC = [n7682905].[dbo].[aspnet_Roles_GetAllRoles] 
        //@ApplicationName
        public static string[] GetAllRoles(string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_Roles_GetAllRoles]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));



            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            SqlDataReader sr = cmd.ExecuteReader();

            List<string> userList = new List<string>();

            while (sr.Read())
            {
                userList.Add(sr.GetString(0));

            }


            conn.Close();

            string[] sA = new string[userList.Count];

            for (int i = 0; i < userList.Count; i++)
                sA[i] = userList[i];

            return sA;
        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_GetRolesForUser] 
        // @ApplicationName
        //,@UserName
        public static string[] GetRolesForUser(string username, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_GetRolesForUser]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));


            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256,
               ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, username));


            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            SqlDataReader sr = cmd.ExecuteReader();

            List<string> userList = new List<string>();

            while (sr.Read())
            {
                userList.Add(sr.GetString(0));

            }

            conn.Close();

            string[] sA = new string[userList.Count];

            for (int i = 0; i < userList.Count; i++)
                sA[i] = userList[i];

            return sA;

        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_GetUsersInRoles] 
        // @ApplicationName
        //,@RoleName
        public static string[] GetUsersInRole(string roleName, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_GetUsersInRoles]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));


            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
               ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));



            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            SqlDataReader sr = cmd.ExecuteReader();

            List<string> userList = new List<string>();

            while (sr.Read())
            {
                userList.Add(sr.GetString(0));

            }


            conn.Close();

            string[] sA = new string[userList.Count];

            for (int i = 0; i < userList.Count; i++)
                sA[i] = userList[i];

            return sA;
        }

        //EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_IsUserInRole] 
        //   @ApplicationName
        //  ,@UserName
        //  ,@RoleName
        public static bool IsUserInRole(string username, string roleName, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_IsUserInRole]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));


            cmd.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, username));

            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();

            bool rlt = ((int)cmd.Parameters[3].Value == 1);


            return rlt;
        }

        //  EXECUTE @RC = [n7682905].[dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles] 
        // @ApplicationName
        //,@UserNames
        //,@RoleNames
        public static void RemoveUsersFromRoles(string[] usernames, string[] roleNames, string connectionString, string ApplicationName)
        {
            string UserNames = "";
            string RoleNames = "";
            foreach (string s in usernames)
            {
                UserNames += s + ",";
            }
            int len = UserNames.Length;
            if ((len > 0) && (UserNames[len - 1] == ','))
                UserNames = UserNames.Substring(0, len - 1);
            foreach (string s in roleNames)
            {
                RoleNames += s + ",";
            }

            len = RoleNames.Length;
            if ((len > 0) && (RoleNames[len - 1] == ','))
                RoleNames = RoleNames.Substring(0, len - 1);

            //
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@UserNames", SqlDbType.NVarChar, 4000,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, UserNames));

            cmd.Parameters.Add(new SqlParameter("@RoleNames", SqlDbType.NVarChar, 4000,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, RoleNames));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();


            conn.Close();

            if ((int)cmd.Parameters[3].Value != 0)
                throw new Exception("aspnet_UsersInRoles_RemoveUsersFromRoles not executed correctly");


        }

        //EXECUTE @RC = [n7682905].[dbo].[aspnet_Roles_RoleExists] 
        //   @ApplicationName='Homework8'
        //  ,@RoleName='wuyq1'
        public static bool RoleExists(string roleName, string connectionString, string ApplicationName)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.CommandText = "[dbo].[aspnet_Roles_RoleExists]";

            cmd.Parameters.Add(new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, ApplicationName));

            cmd.Parameters.Add(new SqlParameter("@RoleName", SqlDbType.NVarChar, 256,
                ParameterDirection.Input, false, 30, 0, "", DataRowVersion.Current, roleName));

            cmd.Parameters.Add(new SqlParameter("@return_value", SqlDbType.Int, 4,
                ParameterDirection.ReturnValue, false, 4, 0, "", DataRowVersion.Current, -1));

            conn.Open();

            cmd.ExecuteNonQuery();

            bool rlt = ((int)cmd.Parameters[2].Value == 1);


            return rlt;
        }

    }
}
