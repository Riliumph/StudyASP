using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using sample_web.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Text;

namespace sample_web.Models
{
  public class UserInfoModel
  {
    private SqlConnection db;
    public UserInfoViewModel view_model
    {
      get;
      private set;
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public UserInfoModel()
    {
      var connectionString = ConfigurationManager.ConnectionStrings["RootUser"].ConnectionString;
      db = new SqlConnection(connectionString);
      FetchUserInfo();
    }

    public void FetchUserInfo()
    {
      var view_model_candidate = new UserInfoViewModel();
      try
      {
        db.Open();
        var query = "SELECT * FROM USER_INFO";
        var command = new SqlCommand(query, db);
        var sdr = command.ExecuteReader();
        while (sdr.Read())
        {
          var id = (int)sdr["id"];
          var username = (string)sdr["username"];
          var birthday = (DateTime)sdr["birthday"];
          view_model_candidate.grid.Add(new UserInfo(id, username, birthday));
        }
      }
      catch (SqlException sql_e)
      {
        using (var writer = new StreamWriter("D:\\db.log", false, Encoding.GetEncoding("UTF-8")))
        {
          writer.WriteLine(sql_e.Message);
        }
      }
      catch (Exception ex)
      {
        using (var writer = new StreamWriter("D:\\db.log", false, Encoding.GetEncoding("UTF-8")))
        {
          writer.WriteLine(ex.Message);
        }
      }
      finally
      {
        db.Dispose();
        db.Close();
      }
      view_model = view_model_candidate;
    }
  }

  public class UserInfoViewModel
  {
    public List<UserInfo> grid = new List<UserInfo>();
  }
}
