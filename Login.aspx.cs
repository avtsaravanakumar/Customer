using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSTSWebPortal;
using System.Drawing;
using SAPbobsCOM;
using System.Configuration;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    public void Page_Load(object sender, EventArgs e)
    {
        ConnectionData temp = new ConnectionData();

        try
        {
            if (temp.IsSAPConneced)
            {
                Session["oCompany"] = temp._oCompany;
                Session["CompanyDetail"] = "";
                Session["OwnerTickets"] = "";
                Session["AssignedTickets"] = "";
                lblInfo.Text = "SAP B1 Client is connected";
                lblInfo.ForeColor = Color.White;

            }
            else
            {
                lblInfo.Text = "SAP B1 Client is not connected";
                lblInfo.ForeColor = Color.Red;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }

    }

    public void btnLogin_Click(object sender, EventArgs e)
    {
        Company oCompany = Session["oCompany"] as Company;

        try
        {
            AuthenticateUsers Auth = new AuthenticateUsers();
            Auth.IsCheckAuthenticateUsers(txtusername.Text, txtpassword.Text, oCompany);

            DataTable DT1 = new DataTable();

            string Query = "SELECT T0.\"CardCode\",T0.\"CardName\",T1.\"Name\",T2.\"Descriptio\",CAST(T2.\"StartDate\" AS VARCHAR(10)) AS \"StartDate\",CAST(T2.\"EndDate\" AS VARCHAR(10)) AS \"EndDate\",T2.\"ContractID\" " +
                        " FROM OCRD T0 INNER JOIN OCPR T1 ON T0.\"CardCode\"=T1.\"CardCode\" and T0.\"CntctPrsn\"=T1.\"Name\" " +
                        " INNER JOIN OCTR T2 ON T2.\"CstmrCode\"=T0.\"CardCode\" where T2.\"Status\"='A' and T0.\"U_SUserID\"='" + txtusername.Text + "' and T0.\"U_Password\"='" + txtpassword.Text + "' " +
                        " ORDER BY T2.\"ContractID\" DESC";

            DataTable DT = new DataTable();
            BoRecordset Br = new BoRecordset();
            DT = Br.oRS(oCompany, Query);

            if (DT.Rows.Count > 0)
            {
                Session["LoggedIn"] = true;
                Session["UserRole"] = "Customer";

                Session["CompanyDetail"] = DT;

                FormsAuthentication.SetAuthCookie("Welcome " + DT.Rows[0]["CardName"].ToString(), false);

                Response.Redirect("~/customer/Home.aspx", true);
            }
            else if (Auth.IsAuthenticate1)
            {
                Session["LoggedIn"] = true;
                Session["UserRole"] = "Employee";

                Session["OwnerName"] = txtusername.Text;

                EmployeeConnectionData temp2 = new EmployeeConnectionData(txtusername.Text, txtpassword.Text);

                if (temp2.IsSAPConneced)
                {
                    Session["oCompany_Emp"] = temp2._oCompany_Emp;
                    Session["CompanyDetail"] = "";
                    Session["OwnerTickets"] = "";
                    Session["AssignedTickets"] = "";

                    //OwnerShip Owner = new OwnerShip();
                    //DataSet DSet = new DataSet();
                    //DSet = Owner.GetData(temp2.U_Name.ToString(), oCompany);

                    //Session["LoginUser"] = DSet.Tables["DT9"] as DataTable;

                    //DataTable DTUser = Session["LoginUser"] as DataTable;

                    string UsernameQry = "SELECT \"U_NAME\" FROM OUSR where \"USER_CODE\"='" + temp2.U_Name.ToString() + "'";

                    DataTable DT10 = new DataTable();
                    BoRecordset Br10 = new BoRecordset();
                    DT10 = Br10.oRS(oCompany, UsernameQry);


                    //FormsAuthentication.Authenticate(DTUser.Rows[0]["EmpName"].ToString(), txtpassword.Text);
                    FormsAuthentication.SetAuthCookie("Welcome " + DT10.Rows[0]["U_NAME"].ToString(), false);

                    DT10.Clear();
                    DT10.Dispose();
                }

                Response.Redirect("~/inecomsupport/ownership.aspx", false);
            }
            else
            {
                lblInfo.Text = "Incorrect UserName or Password";
            }
            DT.Clear();
            DT.Dispose();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "')</script>");
        }

    }
}