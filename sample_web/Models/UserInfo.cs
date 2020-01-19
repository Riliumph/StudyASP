using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sample_web.Models
{
  public class UserInfo
  {
    public const string user_info_key = "UserInfoKey";
    int id { get; set; }
    string username { get; set; }
    DateTime birthday { get; set; }

    /// <summary>
    /// デフォルト・コンストラクタ
    /// </summary>
    public UserInfo()
    {
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="username"></param>
    /// <param name="birthday"></param>
    public UserInfo(int id, string username, DateTime birthday)
    {
      this.id = id;
      this.username = username;
      this.birthday = birthday;
    }
  }
}