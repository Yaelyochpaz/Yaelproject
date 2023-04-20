using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Activities.Expressions;
using System.Security.Cryptography;

public partial class pages_admin : System.Web.UI.Page
{
    public DataSet GetUsersTable(string sql)
    {
        string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        SqlConnection con = new SqlConnection(conStr);
        SqlCommand cmd = new SqlCommand(sql, con);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        con.Open();
        adapter.Fill(ds, "userTbl");
        con.Close();
        return ds;
    }
    public string ConvertTableToHTML(DataTable table)
    {
        string result = "<table border='1' style='text-align:center'>";
        result += "<tr>";
        foreach (DataColumn col in table.Columns)
        {
            result += "<th>" + col.ColumnName + "</th>";
        }
        result += "</tr>";
        foreach (DataRow row in table.Rows)
        {
            result += "<tr>";
            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName.Equals("admin"))
                {
                    if ((bool)row["admin"])
                        result += "<td>Yes</td>";
                    else
                        result += "<td>No</td>";
                }
                else if (col.ColumnName.Equals("birth"))
                {
                    string birthday = row["birth"].ToString().Split(' ')[0];
                    result += "<td>" + birthday + "</td>";
                }
                else // column is not admin					
                    result += "<td>" + row[col.ColumnName] + "</td>";
            }
            result += "</tr>";
        }
        result += "</table>";
        return result;
    }
    public void ShowTableOfUsers()
    {
        string sql = "SELECT * FROM userTbl";
        DataSet ds = GetUsersTable(sql);
        DataTable users = ds.Tables["userTbl"];    // ds.Tables[0]
        string table = ConvertTableToHTML(users);
        showUsersTable.InnerHtml = table;
    }
    public string BuildSQL(string username)
    {
        if (username.Length == 0)
            return "SELECT * FROM userTbl";
        else
            return String.Format("SELECT * FROM userTbl WHERE username LIKE \'%{0}%\'", username);
    }
    public string BuildSQL(string column, string sort)
    {
        return String.Format("SELECT * FROM userTbl ORDER BY {0} {1}", column, sort);
    }
    public void ClickSearch(object sender, EventArgs e)
    {
        string username = Request.Form["searchName"];
        string sql = BuildSQL(username);
        DataSet ds = Helper.RetrieveTable(sql);
        DataTable users = ds.Tables["userTbl"];    // ds.Tables[0]
        string table = Helper.BuildUsersTable(users);
        showUsersTable.InnerHtml = table;
    }

    public void ClickSort(object sender, EventArgs e)
    {
        string columnName = columns.Value;
        string sort = ASC.Checked ? ASC.Value : DESC.Value;
        if (columnName.Equals("empty"))
            showUsersTable.InnerHtml = "Need to pick up a column to order by";
        else
        {
            string sql = BuildSQL(columnName, sort);
            DataSet ds = Helper.RetrieveTable(sql);
            DataTable users = ds.Tables["userTbl"];    // ds.Tables[0]
            string table = Helper.BuildUsersTable(users);
            showUsersTable.InnerHtml = table;
        }
    }
    public void DeleteUsers(object sender, EventArgs e)
    {
        int count = 0;
        for (int i = 0; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
                count++;
        }
        string[] usersToDelete = new string[count];
        int index = 0;
        for (int i = 0; i < Request.Form.Count; i++)
        {
            if (Request.Form.AllKeys[i].Contains("chk"))
            {
                usersToDelete[index] = Request.Form.AllKeys[i].Remove(0, 3);
                index++;
            }
        }

        //Helper.Delete(usersToDelete);
        //ShowUsers();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(bool)Session["admin"])
            Response.Redirect("UnAuthorized.aspx");
    }
}