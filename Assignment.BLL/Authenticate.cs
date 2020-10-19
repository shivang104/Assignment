using Assignment.BO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;

namespace AssignmentBLL
{
    public class Authenticate
    {
        public static bool AuthenticateLogin(LoginBO loginModel)
        {
            bool result;
            try
            {
                var db = DatabaseFactory.CreateDatabase("ConnectionString");
                using (var dbcmd = db.GetStoredProcCommand("Proc_UserAuthenticateLogin"))
                {
                    db.AddInParameter(dbcmd, "@EMP_Username", DbType.String, loginModel.username);
                    db.AddInParameter(dbcmd, "@EMP_Password", DbType.String, loginModel.password);
                    db.AddOutParameter(dbcmd, "@Succes", DbType.Int32, 0);
                    db.ExecuteReader(dbcmd);
                    result = Convert.ToBoolean(db.GetParameterValue(dbcmd, "@Succes"));
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public static int RegisterEmployee(RegisterBO emp)
        {
            var result = 0;
            try
            {
                var db = DatabaseFactory.CreateDatabase("ConnectionString");
                using (var dbcmd = db.GetStoredProcCommand("Proc_InsertEmployeeDetails"))
                {
                    db.AddInParameter(dbcmd, "@EMP_FirstName", DbType.String, emp.firstname);
                    db.AddInParameter(dbcmd, "@EMP_LastName", DbType.String, emp.lastname);
                    db.AddInParameter(dbcmd, "@EMP_Password", DbType.String, emp.password);
                    db.AddInParameter(dbcmd, "@EMP_Gender", DbType.String, emp.gender);
                    db.AddInParameter(dbcmd, "@EMP_Email", DbType.String, emp.email);
                    db.AddInParameter(dbcmd, "@EMP_DOB", DbType.String, emp.dob);
                    db.AddOutParameter(dbcmd, "@Succes", DbType.Int32, 0);
                    db.ExecuteReader(dbcmd);
                    result = Convert.ToInt32(db.GetParameterValue(dbcmd, "@Succes"));
                }
            }
            catch (Exception ex)
            {
                result = 0;
            }
            return result;
        }

        public static IDataReader GetAllEmployeesList()
        {
            try
            {
                var db = DatabaseFactory.CreateDatabase("ConnectionString");
                using (var dbcmd = db.GetStoredProcCommand("Proc_GetAllEmployeesList"))
                {
                    return db.ExecuteReader(dbcmd);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
