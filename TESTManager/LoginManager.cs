using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTEntity;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace TESTManager
{
    public class LoginManager
    {
      





        public List<LoginModel> GetUserLogin(LoginModel loginModel)
        {
            List<LoginModel> UserDetails = new List<LoginModel>();
            try
            {
                SqlParameter sp1 = new SqlParameter("@UserName", loginModel.UserID);
                SqlParameter sp2 = new SqlParameter("@Password", loginModel.Password);
                SqlParameter sp3 = new SqlParameter("@Flag", "1");
                SqlDataReader sqlDataReader = clsDataAccess.ExecuteReader(CommandType.StoredProcedure, "Sp_LoginMaster", sp1, sp2, sp3);
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        loginModel.LoginID = 1;
                        loginModel.UserName = sqlDataReader["Email"].ToString();
                        loginModel.Password = sqlDataReader["password"].ToString();
                        //loginModel.RoleId = sqlDataReader["RoleId"].ToString();
                        UserDetails.Add(loginModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserDetails;

        }


        public int Save(SignUpModel loginModel)
        {
            int res = 0;
            try
            {
                SqlParameter sp1 = new SqlParameter("@UserName", loginModel.UserName);
                SqlParameter sp2 = new SqlParameter("@Password", loginModel.Password);

                SqlParameter sp3 = new SqlParameter("@Email", loginModel.UserID);
                SqlParameter flg = new SqlParameter("@Flag", "2");
                res = clsDataAccess.ExecuteNonQuery(CommandType.StoredProcedure, "Sp_LoginMaster", sp1, sp2, sp3, flg);
            }
            catch (Exception ex)
            {

            }
            return res;
        }
    }
}
