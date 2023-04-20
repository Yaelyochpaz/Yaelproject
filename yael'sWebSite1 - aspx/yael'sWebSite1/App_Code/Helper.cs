using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public static class Helper
{
    public const string DBName = "Database.mdf";   //Name of the MSSQL Database.
    public const string tblName = "userTbl";      // Name of the user Table in the Database
    public const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\" 
                                    + DBName + ";Integrated Security=True";   // The Data Base is in the App_Data = |DataDirectory|

    //public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
    //public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

    
    public static DataSet RetrieveTable(string SQLStr)
    // Gets A table from the data base acording to the SELECT Command in SQLStr;
    // Returns DataSet with the Table.
    {
        // connect to DataBase
        SqlConnection con = new SqlConnection(conString);

        // Build SQL Query
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // Build DataAdapter
        SqlDataAdapter ad = new SqlDataAdapter(cmd);

        // Build DataSet to store the data
        DataSet ds = new DataSet();

        // Get Data form DataBase into the DataSet
        ad.Fill(ds, tblName);
       
        return ds;
    }
    public static DataTable ExecuteDataTable(string query)
    {
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        DataTable dataTable = new DataTable();
        SqlDataAdapter sql = new SqlDataAdapter(query, con);
        sql.Fill(dataTable);
        return dataTable;
    }
    public static string ShowPassword(string query)
    {
        DataTable dt = ExecuteDataTable(query);
        string password = "";
        foreach (DataRow dr in dt.Rows)
        {
            foreach (object o in dr.ItemArray)
            {
                password = o.ToString();
            }
        }
        return password;
    }
    public static bool IsExist(string query)
    {
        SqlConnection con = new SqlConnection(conString);
        con.Open();
        SqlCommand cmmd = new SqlCommand(query, con);
        SqlDataReader data = cmmd.ExecuteReader();
        bool found = data.Read();
        con.Close();
        return found;
    }

    public static object GetScalar(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL

        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        object scalar = cmd.ExecuteScalar();
        con.Close();

        return scalar;
    }

    public static int ExecuteNonQuery(string SQL)
    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        int n = cmd.ExecuteNonQuery();
        con.Close();

        // return the number of rows affected
        return n;
    }

    public static void Delete(int [] usernameToDelete)
    // The Array "userIdToDelete" contain the id of the users to delete. 
    // Delets all the users in the array "userIdToDelete".
    {
        string sql = String.Format("DELETE FROM {0} WHERE username = \'", tblName);

        for (int i = 0; i < usernameToDelete.Length; i++)
        {
            ExecuteNonQuery(sql + usernameToDelete[i] + "\'");
        }
    }
    /* {
         // התחברות למסד הנתונים
         SqlConnection con = new SqlConnection(conString);

         // טעינת הנתונים
         string SQL = "SELECT * FROM " + tblName;
         SqlCommand cmd = new SqlCommand(SQL, con);
         SqlDataAdapter adapter = new SqlDataAdapter(cmd);
         DataSet ds = new DataSet();
         adapter.Fill(ds, tblName);

         // מחיקת שורות שנבחרו מתוך הדאטה סט
         for (int i = 0; i < userToDelete.Length; i++)
         {
             {
                 DataRow[] dr = ds.Tables[tblName].Select(String.Format("userId = {0}", userToDelete[i]));
                 dr[0].Delete();
             }
         }

         // עדכון הדאטה סט בבסיס הנתונים
         SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
         adapter.UpdateCommand = builder.GetDeleteCommand();
         adapter.Update(ds, tblName);
     }
    */
    public static void Update(User user)
        // The Method recieve a user objects. Find the user in the DataBase acording to his userId and update all the other properties in DB.
    {
        // HttpRequest Request
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = "SELECT * FROM " + Helper.tblName + String.Format(" Where username={0}", user.username);
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        //  טעינת הנתונים לתוך DataSet
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].Rows[0];
        dr["username"] = user.username;
        dr["password"] = user.password;
        dr["firstname"] = user.firstname;
        dr["lastname"] = user.lastname;
        dr["name"] = user.name;
        dr["mail"] = user.mail;
        dr["gender"] = user.gender;
        dr["phone"] = user.phone;
        dr["birth"] = user.birth;
        dr["admin"]=user.admin;
        dr["hintQ"] = user.hintQ;
        dr["hintAns"] = user.hintAns;
       

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetUpdateCommand();
        adapter.Update(ds, tblName);

    }

    public static void Insert (User user )
    // The Method recieve a user objects and insert it to the Database as new row. 
    // The Method does't check if the user is already taken.
    {
        //HttpRequest Request
        // התחברות למסד הנתונים
        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gilad\source\repos\DBWeb\DBWeb\App_Data\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQLStr = String.Format("SELECT * FROM " + tblName+ " WHERE 0=1");
        SqlCommand cmd = new SqlCommand(SQLStr, con);

        // בניית DataSet
        DataSet ds = new DataSet();

        // טעינת סכימת הנתונים
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds, tblName);

        // בניית השורה להוספה
        DataRow dr = ds.Tables[tblName].NewRow();
        //dr["firstname"] = user.firstname;
        //dr["lastname"] = user.lastname;
        dr["username"] = user.GetUsername();
        dr["password"] = user.GetPassword();
        dr["name"] = user.GetFirstname() + "" + user.GetLastname();
        dr["mail"] = user.GetMail();
        dr["gender"] = user.GetGender();
        dr["phone"] = user.GetPhone();
        dr["birth"] = user.GetBirth();
        dr["admin"] = user.GetAdmin();
        dr["hintQ"] = user.GetHintQ();
        dr["hintAns"] = user.GetHintQ();
        ds.Tables[tblName].Rows.Add(dr);

        // עדכון הדאטה סט בבסיס הנתונים
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
        adapter.UpdateCommand = builder.GetInsertCommand();
        adapter.Update(ds, tblName);
    }

    public static User GetRow(string username, string password)
        // The Method check if there is a user with userName and Password. 
        // If true the Method return a user with the first Name and Admin property.
        // If not the Method return a user wuth first name "Visitor" and Admin = false

    {
        // התחברות למסד הנתונים
        SqlConnection con = new SqlConnection(conString);

        // בניית פקודת SQL
        string SQL = String.Format("SELECT firstname, admin FROM " + tblName +
                " WHERE username='{0}' AND password = '{1}'", username, password);
        SqlCommand cmd = new SqlCommand(SQL, con);

        // ביצוע השאילתא
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        // שימוש בנתונים שהתקבלו
        User user = new User();
        if (reader.HasRows)
        {
            reader.Read();
            user.username = reader.GetString(0);
            user.admin= reader.GetBoolean(1);
        }
        else
        {
            user.username = "Visitor";
            user.admin = false;
        }
        reader.Close();
        con.Close();
        return user;
    }

    public static string BuildSimpleUsersTable(DataTable dt)
        // the Method Build HTML user Table using the users in the DataTable dt.
    {
        string str = "<table border='1' class='usersTable' align='center'>";
        str += "<tr>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            foreach (DataColumn column in dt.Columns)
            {
				if (column.ColumnName.Equals("birth"))
				{
					string birth = row[column].ToString().Split(' ')[0];
					str += "<td>" + birth + "</td>";
				}
				else
					str += "<td>" + row[column] + "</td>";
			}
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string BuildUsersTable(DataTable dt)
    // the Method Build HTML user Table with checkBoxes using the users in the DataTable dt.
    {

        string str = "<table border='1' class='usersTable' align='center'>";
        str += "<tr>";
        str += "<td> </td>";
        foreach (DataColumn column in dt.Columns)
        {
            str += "<td>" + column.ColumnName + "</td>";
        }

        foreach (DataRow row in dt.Rows)
        {
            str += "<tr>";
            str += "<td>" + CreateRadioBtn(row["username"].ToString()) + "</td>";
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName.Equals("birth"))
                {
                    string birth = row[column].ToString().Split(' ')[0];
                    str += "<td>" + birth + "</td>";
                }
                else
                    str += "<td>" + row[column] + "</td>";
            }
            str += "</tr>";
        }
        str += "</tr>";
        str += "</Table>";
        return str;
    }

    public static string CreateRadioBtn(string id)
    {
        return String.Format("<input type='checkbox' name='chk{0}' id='chk{0}' runat='server' />", id);
    }

    public static DataTable SortTable(DataTable dt, string column, string dir)
    {
        dt.DefaultView.Sort = column + " " + dir;
        return dt.DefaultView.ToTable();
    }

    public static DataTable FilterTable(DataTable dt, string column, string criteria)
    {
        dt.DefaultView.RowFilter = column + "=" + criteria;
        return dt.DefaultView.ToTable();
    }
}