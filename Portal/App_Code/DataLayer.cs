using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Web.SessionState;
using System.Web.UI;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;



public partial class DataLayer : Page, IRequiresSessionState
{
    string ConStr = "";

    public DataLayer()
    {
        ConStr = ConfigurationManager.AppSettings.Get("conn");
    }

    
    #region DataLayer Function
    private DataSet ExecuteSelectQuery(string Sql)
    {
        DataSet set1 = new DataSet();
        using (SqlConnection con = new SqlConnection(ConStr))
        {
            SqlCommand command1 = new SqlCommand(Sql, con);
            if (command1.Connection.State == ConnectionState.Closed)
            {
                command1.Connection.Open();
            }
            command1.CommandTimeout = 7000;
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);

            adapter1.Fill(set1);
        }
        return set1;
    }


    private DataSet ExecuteSelectQuerywithTransaction(SqlConnection Con, string Sql, SqlTransaction trans)
    {
        DataSet set1 = new DataSet();
        SqlCommand command1 = new SqlCommand(Sql, Con, trans);
        command1.CommandTimeout = 7000;
        SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
        adapter1.Fill(set1);
        return set1;
    }
    public bool Delete_Album(int Album_Id_Delete)//, int Album_Id)
    {
        bool flag = false;
        string sql = "";
        try
        {
            sql = "update tbl_Album_Save set Album_Status = 0, Album_ModifiedOn = getdate() where Album_Id = '" + Album_Id_Delete + "' and Album_Status = 1";
            ExecuteSelectQuery(sql);
            flag = true;
        }
        catch
        {
            flag = false;
        }
        return flag;

    }

    public DataSet Insert_Grid(string Album_Name, int Category_Id, int Studio_Id, string Genere_Id_In, string Actor_Id_In, string Supporting_Id_In, string Director_Id_In)
    {
        DataSet ds = new DataSet();
        string sql = @"select 
                            Album_Id,
	                        Album_Category,
	                        Category_Name,
	                        Album_Name,
	                        Album_Description,
	                        Album_Rating,
	                        Album_Mounting_Rating,
	                        Album_Studio_Id,
	                        Studio_Name,
	                        Album_Category,
	                        Album_AddedBy,
	                        Album_AddedOn,
	                        Album_Status, 
	                        Album_Genere.List_Genere, 
	                        Album_Actor.List_Actor, 
	                        Album_Director.List_Director, 
	                        Album_Supporting.List_Supporting
                        from tbl_Album_Save
                        left join tbl_Studio on Studio_Id = Album_Studio_Id
                        join tbl_Category on Category_Id = Album_Category
                        left join (
	                        SELECT	
		                        AlbumGenere_Album_Id,
		                        STUFF((SELECT ', ' + CAST(Genere_Name AS VARCHAR(500)) [text()]
	                        from tbl_Album_Genere  
	                        join tbl_Genere on Genere_Id = AlbumGenere_Genere_id
	                        WHERE AlbumGenere_Album_Id = t.AlbumGenere_Album_Id and tbl_Album_Genere.AlbumGenere_Status = 1
	                        FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,' ') List_Genere
	                        FROM tbl_Album_Genere t
	                        where t.AlbumGenere_Status = 1
	                        GROUP BY AlbumGenere_Album_Id
                        ) Album_Genere on AlbumGenere_Album_Id = Album_Id
                        left join (
	                        SELECT	
		                        AlbumStaff_Album_Id,
		                        STUFF((SELECT ', ' + CAST(Starring_name AS VARCHAR(500)) [text()]
	                        from tbl_Album_Staff  
	                        join tbl_Starring on Starring_id = AlbumStaff_Starring_id
	                        WHERE AlbumStaff_Album_Id = t.AlbumStaff_Album_Id and tbl_Album_Staff.AlbumStaff_Status = 1 and Starring_Type = 'A'
	                        FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,' ') List_Actor
	                        FROM tbl_Album_Staff t
	                        where t.AlbumStaff_Status = 1 
	                        GROUP BY AlbumStaff_Album_Id
                        ) Album_Actor on Album_Actor.AlbumStaff_Album_Id = Album_Id

                        left join (
	                        SELECT	
		                        AlbumStaff_Album_Id,
		                        STUFF((SELECT ', ' + CAST(Starring_name AS VARCHAR(500)) [text()]
	                        from tbl_Album_Staff  
	                        join tbl_Starring on Starring_id = AlbumStaff_Starring_id
	                        WHERE AlbumStaff_Album_Id = t.AlbumStaff_Album_Id and tbl_Album_Staff.AlbumStaff_Status = 1 and Starring_Type = 'D'
	                        FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,' ') List_Director
	                        FROM tbl_Album_Staff t
	                        where t.AlbumStaff_Status = 1 
	                        GROUP BY AlbumStaff_Album_Id
                        ) Album_Director on Album_Director.AlbumStaff_Album_Id = Album_Id

                        left join (
	                        SELECT	
		                        AlbumStaff_Album_Id,
		                        STUFF((SELECT ', ' + CAST(Starring_name AS VARCHAR(500)) [text()]
	                        from tbl_Album_Staff  
	                        join tbl_Starring on Starring_id = AlbumStaff_Starring_id
	                        WHERE AlbumStaff_Album_Id = t.AlbumStaff_Album_Id and tbl_Album_Staff.AlbumStaff_Status = 1 and Starring_Type = 'S'
	                        FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)'),1,2,' ') List_Supporting
	                        FROM tbl_Album_Staff t
	                        where t.AlbumStaff_Status = 1 
	                        GROUP BY AlbumStaff_Album_Id
                        ) Album_Supporting on Album_Supporting.AlbumStaff_Album_Id = Album_Id
                        where Album_Status = 1 ";
        if (Album_Name != "")
        {
            sql += " and Album_Name like '%" + Album_Name + "%'";
        }
        if (Category_Id != 0)
        {
            sql += " and Album_Category = " + Category_Id + "";
        }
        if (Studio_Id != 0)
        {
            sql += " and Album_Studio_Id = '" + Studio_Id + "'";
        }
        sql += " order by Album_Name";
        try
        {
            ds = ExecuteSelectQuery(sql);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }



    #endregion

    #region Login
    public DataSet getLoginDetails(string User_Name, string Password)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = "select Login_Id, Login_PersonId, Login_UserName,Login_password from tbl_UserLogin where Login_UserName = '" + User_Name + "' and Login_password = '" + Password + "' and Login_Status = 1 ;";
        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }

    public DataSet get_User_Permission(string Office_Id, string Designation_Id)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = @"set dateformat dmy; 
                    select 
                        ProcessConfigMaster_Id,
	                    ProcessConfigMaster_Creation_Allowed,
	                    ProcessConfigMaster_Updation_Allowed, 
                        ProcessConfigMaster_Deduction_Allowed,
                        ProcessConfigMaster_Document_Updation_Allowed,
                        ProcessConfigMaster_Qty_Editing_Allowed,
                        ProcessConfigMaster_Transfer_Allowed
                    from tbl_ProcessConfigMaster where ProcessConfigMaster_Status = 1 and ProcessConfigMaster_Process_Name = 'BOQ' and ProcessConfigMaster_OrgId = '" + Office_Id + "' and (ProcessConfigMaster_Designation_Id = '" + Designation_Id + "' or ProcessConfigMaster_Designation_Id1 = '" + Designation_Id + "'); ";

        strQuery += @"select 
                        ProcessConfigMaster_Id,
	                    ProcessConfigMaster_Creation_Allowed,
	                    ProcessConfigMaster_Updation_Allowed, 
                        ProcessConfigMaster_Deduction_Allowed,
                        ProcessConfigMaster_Document_Updation_Allowed,
                        ProcessConfigMaster_Qty_Editing_Allowed,
                        ProcessConfigMaster_Transfer_Allowed
                    from tbl_ProcessConfigMaster where ProcessConfigMaster_Status = 1 and ProcessConfigMaster_Process_Name = 'EMB' and ProcessConfigMaster_OrgId = '" + Office_Id + "' and (ProcessConfigMaster_Designation_Id = '" + Designation_Id + "' or ProcessConfigMaster_Designation_Id1 = '" + Designation_Id + "'); ";

        strQuery += @"select 
                        ProcessConfigMaster_Id,
	                    ProcessConfigMaster_Creation_Allowed,
	                    ProcessConfigMaster_Updation_Allowed, 
                        ProcessConfigMaster_Deduction_Allowed,
                        ProcessConfigMaster_Document_Updation_Allowed,
                        ProcessConfigMaster_Qty_Editing_Allowed,
                        ProcessConfigMaster_Transfer_Allowed
                    from tbl_ProcessConfigMaster where ProcessConfigMaster_Status = 1 and ProcessConfigMaster_Process_Name = 'Invoice' and ProcessConfigMaster_OrgId = '" + Office_Id + "' and (ProcessConfigMaster_Designation_Id = '" + Designation_Id + "' or ProcessConfigMaster_Designation_Id1 = '" + Designation_Id + "'); ";
        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch (Exception)
        {
            ds = null;
        }
        return ds;
    }

    #endregion

    #region Login History
    public int Insert_tbl_LoginHistory(string Person_Id)
    {
        DataSet ds = new DataSet();
        int iResult = 0;
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                string sql = "set dateformat dmy; insert into tbl_LoginHistory (LoginHistory_PersonId, LoginHistory_LoggedInTime, LoginHistory_LoggedOutTime, LoginHistory_IPAddress, LoginHistory_MACAddress, LoginHistory_Status) values ('" + Person_Id + "', getdate(), null, '" + AllClasses.getIPAddress() + ", " + AllClasses.getIPAddress2() + "', '" + AllClasses.getMACAddress() + "', 1); select @@IDENTITY";
                ds = ExecuteSelectQuery(sql);
                if (AllClasses.CheckDataSet(ds))
                {
                    iResult = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                }
                else
                {
                    iResult = 0;
                }
            }
            catch (Exception)
            {
                cn.Close();
                iResult = -1;
            }
        }
        return iResult;
    }

    public int Update_tbl_LoginHistory(string LoginHistory_Id)
    {
        DataSet ds = new DataSet();
        int iResult = 0;
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                string sql = "set dateformat dmy; update tbl_LoginHistory set LoginHistory_LoggedOutTime = getdate() where LoginHistory_Id = '" + LoginHistory_Id + "'";
                ds = ExecuteSelectQuery(sql);
                iResult = 1;
            }
            catch (Exception)
            {
                cn.Close();
                iResult = -1;
            }
        }
        return iResult;
    }

    public string get_tbl_LoginHistory_Last_Login(string Person_Id)
    {
        DataSet ds = new DataSet();
        string iResult = "";
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            try
            {
                string sql = @"set dateformat dmy; with cte1 as (
                                select ROW_NUMBER() over(order by LoginHistory_Id desc) rr, * from tbl_LoginHistory
                                where LoginHistory_PersonId = '" + Person_Id + "') select convert(varchar, LoginHistory_LoggedInTime, 9) LastLogin from cte1 where rr = 2";
                ds = ExecuteSelectQuery(sql);
                if (AllClasses.CheckDataSet(ds))
                {
                    iResult = " (Your Last Login : " + ds.Tables[0].Rows[0]["LastLogin"].ToString() + ") ";
                }
                else
                {
                    iResult = " (Your Last Login : Never) ";
                }
            }
            catch (Exception)
            {
                cn.Close();
                iResult = " (Your Last Login : Never) ";
            }
        }
        return iResult;
    }
    #endregion

    #region SMS Log
    public void Insert_tbl_SMS(tbl_SMS obj_tbl_SMS)
    {
        DataSet set1 = new DataSet();
        SqlCommand command1 = null;
        SqlDataAdapter adapter1 = null;
        string strQuery = "";
        strQuery = " set dateformat dmy;insert into tbl_SMS (SMS_Mobile_No, SMS_Content, SMS_Response, SMS_AddedOn) values ('" + obj_tbl_SMS.SMS_Mobile_No + "', '" + obj_tbl_SMS.SMS_Content + "','" + obj_tbl_SMS.SMS_Response + "', getdate());Select @@Identity";
        try
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                command1 = new SqlCommand(strQuery, con);
                if (command1.Connection.State == ConnectionState.Closed)
                {
                    command1.Connection.Open();
                }
                command1.CommandTimeout = 7000;
                adapter1 = new SqlDataAdapter(command1);
                adapter1.Fill(set1);
            }
        }
        catch
        {

        }
    }

    public DataSet get_tbl_SMS(string date)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = " set dateformat dmy; select * from tbl_SMS where convert(date, convert(char(10), SMS_AddedOn, 103), 103) = convert(date, '" + date + "', 103)";
        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }
    #endregion

    #region Change Password
    public bool Change_Password(string OldPassword, string NewPassword, int Person_Id)
    {
        string strQuery = "";
        bool flag = false;
        DataSet ds = new DataSet();
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                strQuery = " set dateformat dmy; select Login_Id from tbl_UserLogin where Login_PersonId='" + Person_Id + "' and Login_password='" + OldPassword + "' and Login_Status=1";
                try
                {
                    ds = ExecuteSelectQuery(strQuery);
                }
                catch
                {
                    ds = null;
                }
                if (AllClasses.CheckDataSet(ds))
                {
                    strQuery = "update tbl_UserLogin set Login_password='" + NewPassword + "', Login_IsDefault = 1 where Login_PersonId='" + Person_Id + "' and  Login_Status=1";

                    if (trans == null)
                    {
                        ExecuteSelectQuery(strQuery);
                    }
                    else
                    {
                        ExecuteSelectQuerywithTransaction(cn, strQuery, trans);
                    }

                    trans.Commit();
                    cn.Close();
                    flag = true;
                }

            }
            catch
            {
                trans.Rollback();
                cn.Close();
                flag = false;
            }
        }
        return flag;
    }
    #endregion

    #region User Login
    private void Insert_tbl_UserLogin(tbl_UserLogin obj_tbl_UserLogin, SqlTransaction trans, SqlConnection cn)
    {
        string strQuery = "";
        strQuery = " set dateformat dmy;insert into tbl_UserLogin ( [Login_AddedBy],[Login_Addeddatetime],[Login_password],[Login_PersonId],[Login_Status],[Login_UserName] ) values ('" + obj_tbl_UserLogin.Login_AddedBy + "',getdate(),'" + obj_tbl_UserLogin.Login_password + "','" + obj_tbl_UserLogin.Login_PersonId + "','" + obj_tbl_UserLogin.Login_Status + "','" + obj_tbl_UserLogin.Login_UserName + "');Select @@Identity";
        if (trans == null)
        {
            try
            {
                ExecuteSelectQuery(strQuery);
            }
            catch
            {
            }
        }
        else
        {
            ExecuteSelectQuerywithTransaction(cn, strQuery, trans);
        }
    }
    #endregion

    #region Master Category
    public DataSet get_tbl_Category()
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = @" set dateformat dmy; 
                    select 
                        Category_Id, 
                        Category_Name, 
                        Category_AddedOn, 
                        Category_AddedBy, 
                        Category_Status, 
                        isnull(tbl_PersonDetail.Person_Name, 'Backend Entry') CreatedBy, 
                        Created_Date = Category_AddedOn, 
                        tbl_PersonDetail1.Person_Name as ModifyBy, 
                        Modify_Date = Category_ModifiedOn
                      from tbl_Category
                      left join tbl_PersonDetail on Person_Id = Category_AddedBy
                      left join tbl_PersonDetail as tbl_PersonDetail1 on tbl_PersonDetail1.Person_Id = Category_ModifiedBy
                      where Category_Status = 1 order by Category_Name";

        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }
    public DataSet Edit_tbl_Category(int Category_Id)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = " select Category_Id,Category_Name from tbl_Category where Category_Status=1 and Category_Id ='" + Category_Id + "'";
        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }
    public bool Insert_tbl_Category(tbl_Category obj_tbl_Category, int Category_Id, ref string Msg)
    {
        bool flag = false;
        DataSet ds = new DataSet();
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                if (AllClasses.CheckDataSet(CheckDuplicacyCategory(obj_tbl_Category.Category_Name, Category_Id.ToString(), trans, cn)))
                {
                    Msg = "A";
                    trans.Commit();
                    cn.Close();
                    return false;
                }

                if (Category_Id == 0)
                {
                    Insert_tbl_Category(obj_tbl_Category, trans, cn);
                }
                else
                {
                    obj_tbl_Category.Category_Id = Category_Id;
                    Update_tbl_Category(obj_tbl_Category, trans, cn);
                }
                trans.Commit();
                cn.Close();
                flag = true;
            }
            catch
            {
                trans.Rollback();
                cn.Close();
                flag = false;
            }
        }
        return flag;
    }

    private DataSet CheckDuplicacyCategory(string CategoryName, string Category_Id, SqlTransaction trans, SqlConnection cn)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = " set dateformat dmy; Select  * from tbl_Category  where Category_Status = 1 and  Category_Name = '" + CategoryName + "' ";
        if (Category_Id != "0")
        {
            strQuery += " AND Category_Id  <> '" + Category_Id + "'";
        }
        if (trans == null)
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        else
        {
            ds = ExecuteSelectQuerywithTransaction(cn, strQuery, trans);
        }
        return ds;
    }

    private string Insert_tbl_Category(tbl_Category obj_tbl_Category, SqlTransaction trans, SqlConnection cn)
    {
        string strQuery = "";
        strQuery = " set dateformat dmy; insert into tbl_Category( [Category_AddedBy],[Category_AddedOn],[Category_Name],[Category_Status]) values('" + obj_tbl_Category.Category_AddedBy + "', getdate(), N'" + obj_tbl_Category.Category_Name + "','" + obj_tbl_Category.Category_Status + "'); Select @@Identity";

        if (trans == null)
        {
            return ExecuteSelectQuery(strQuery).Tables[0].Rows[0][0].ToString();
        }
        else
        {
            return ExecuteSelectQuerywithTransaction(cn, strQuery, trans).Tables[0].Rows[0][0].ToString();
        }
    }

    private void Update_tbl_Category(tbl_Category obj_tbl_Category, SqlTransaction trans, SqlConnection cn)
    {
        string strQuery = "";
        strQuery = " set dateformat dmy;Update  tbl_Category set  Category_Name = N'" + obj_tbl_Category.Category_Name + "', Category_ModifiedOn = getdate(), Category_ModifiedBy = '" + obj_tbl_Category.Category_AddedBy + "' where Category_Id = '" + obj_tbl_Category.Category_Id + "' and Category_Status = '" + obj_tbl_Category.Category_Status + "' ";
        if (trans == null)
        {
            ExecuteSelectQuery(strQuery);
        }
        else
        {
            ExecuteSelectQuerywithTransaction(cn, strQuery, trans);
        }
    }

    public bool Delete_Category(int Category_Id, int person_Id)
    {
        try
        {
            string strQuery = "";
            strQuery = " set dateformat dmy; Update  tbl_Category set   Category_Status = 0 where Category_Id = '" + Category_Id + "' ";
            ExecuteSelectQuery(strQuery);
            return true;
        }
        catch
        {
            return false;
        }
    }
    #endregion

    #region Star

    public DataSet get_Star()
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; select * from tbl_Starring order by Starring_Name";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }
    #endregion

    public bool Insert_Login(tbl_Genere obj_PersonDetail)
    {
        bool flag = false;
        DataSet dataSet = new DataSet();
        string strQuer = "insert into tbl_Genere([tbl_Genere_name]) values('" + obj_PersonDetail.Genere_Name + "'); ";
        int ret_type = 0;

        try
        {
            dataSet = ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            ret_type = 0;
            flag = false;
        }

        return flag;
    }
    public bool Insert_Review(tbl_Review obj_User_review)
    {
        bool flag = false;
        DataSet dataSet = new DataSet();
        string strQuer = "insert into tbl_Review([tbl_Review_Rating],[tbl_Review_Comment],[tbl_Review_faviourate]) values('" + obj_User_review.tbl_Review_Rating + "','" + obj_User_review.tbl_Review_Comment + "','" + obj_User_review.tbl_Review_faviourate + "'); ";
        int ret_type = 0;

        try
        {
            dataSet = ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            ret_type = 0;
            flag = false;
        }

        return flag;
    }

    #region Studio
    public bool Studio_savebtn(tbl_Studio objStudio)
    {
        bool flag = false;
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Studio([Studio_Name],[Studio_Status])values('" + objStudio.Studio_Name + "','" + objStudio.Studio_Status + "');select @@Identity";
        try
        {
            ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;
    }
    public DataSet get_Studio()
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; select * from tbl_Studio order by Studio_Name";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }


    #endregion


    #region CreateAccount
    public bool Account_savebtn(save_account objSaa)
    {
        bool flag = false;
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into save_account ([save_name],[save_Username],[save_mobile],[save_email],[save_password],[save_confirmpassword],[save_gender],[save_age])values('" + objSaa.save_name + "','" + objSaa.save_Username + "','" + objSaa.save_mobile + "','" + objSaa.save_email + "','" + objSaa.save_password + "','" + objSaa.save_confirmpassword + "','" + objSaa.save_gender + "','" + objSaa.save_age + "' where save_status=1);select @@Identity";
        try
        {
            ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;
    }
    public DataSet Account_check(save_account obj)
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; select save_email,save_mobile from save_account where save_email='" + obj.save_email + "' and save_mobile='" + obj.save_mobile + "' ";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }

    #endregion



    #region Genere
    public bool Genere_savebtn(tbl_Genere objGenere)
    {
        bool flag = false;
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Genere([Genere_Name])values('" + objGenere.Genere_Name + "');select @@Identity";
        try
        {
            ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;
    }
    public DataSet get_Genere()
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; select * from tbl_Genere order by Genere_Name";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }
    #endregion

    #region Starring
    public bool Starring_savebtn(tbl_Starring objStarring)
    {
        bool flag = false;
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Starring([Starring_name], [Starring_Type],[Starring_AddedBy],[Starring_AddedOn],[Starring_ModifiedBy],[Starring_ModifiedOn],[Starring_Status])values('" + objStarring.Starring_Name + "', '" + objStarring.Starring_Type + "','" + objStarring.Starring_AddedBy + "','" + objStarring.Starring_AddedOn + "','" + objStarring.Starring_ModifiedBy + "','" + objStarring.Starring_ModifiedOn + "','" + objStarring.Starring_Status + "');select @@Identity";
        try
        {
            ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;
    }
    public DataSet get_Starring(string Type)
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; select * from tbl_Starring where Starring_Type = '" + Type + "' order by Starring_name";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }

    #endregion

    #region Category
    public DataSet get_Category()
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "Select Category_Id,Category_Name,Category_Status,Category_AddedBy,Category_AddedOn,Category_ModifiedBy,Category_ModifiedOn from tbl_Category";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }

    #endregion

    #region Album_save
    public int Insert_Album_Save(tbl_Album_Save objAlbumSave, SqlTransaction trans, SqlConnection cn)
    {
        DataSet dataSet = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy;  insert into tbl_Album_Save([Album_Name], [Album_Description],[Album_Rating],[Album_Mounting_Rating],[Album_Studio_Id],[Album_Category],[Album_AddedBy],[Album_AddedOn],[Album_Status])values('" + objAlbumSave.Album_Name + "', '" + objAlbumSave.Album_Description + "','" + objAlbumSave.Album_Rating + "','" + objAlbumSave.Album_Mounting_Rating + "','" + objAlbumSave.Album_Studio_Id + "','" + objAlbumSave.Album_Category + "','" + objAlbumSave.Album_AddedBy + "', getdate(),'" + objAlbumSave.Album_Status + "');select @@Identity";
        int ret_type = 0;
        if (trans == null)
        {
            try
            {
                dataSet = ExecuteSelectQuery(strQuer);
            }
            catch (Exception ee)
            {
                ret_type = 0;
            }
        }
        else
        {
            dataSet = ExecuteSelectQuerywithTransaction(cn, strQuer, trans);

        }
        return Convert.ToInt32(dataSet.Tables[0].Rows[0][0].ToString());
    }



    #endregion

    #region AlbumStaff 
    public bool Insert_Staff_Album_Save(tbl_Album_Staff objAlbumSave, SqlTransaction trans, SqlConnection cn)
    {
        bool flag = false;
        DataSet dataSet = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Album_Staff([AlbumStaff_Album_Id],[AlbumStaff_Starring_id],[AlbumStaff_AddedBy],[AlbumStaff_AddedOn],[AlbumStaff_Status]) values ('" + objAlbumSave.AlbumStaff_Album_Id + "','" + objAlbumSave.AlbumStaff_Starring_id + "','" + objAlbumSave.AlbumStaff_AddedBy + "', getdate(),'" + objAlbumSave.AlbumStaff_Status + "' );select @@Identity";
        int ret_type = 0;
        if (trans == null)
        {
            try
            {
                dataSet = ExecuteSelectQuery(strQuer);
                flag = true;
            }
            catch (Exception ee)
            {
                ret_type = 0;
                flag = false;
            }
        }
        else
        {
            dataSet = ExecuteSelectQuerywithTransaction(cn, strQuer, trans);
            flag = true;
        }
        return flag;
    }

    public bool Insert_Album(tbl_Album_Save objAlbumSave, List<tbl_Album_Staff> obj_tbl_Album_Staff_Li, List<tbl_Album_Genere> obj_tbl_Album_Genere_Li, List<tbl_Upload_Banner> obj_tbl_Upload_BannerLi)

    {
        bool flag = false;
        DataSet ds = new DataSet();
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                if (objAlbumSave.Album_Id > 0)
                {
                    Update_Album_Save(objAlbumSave, trans, cn);
                }
                else
                {
                    objAlbumSave.Album_Id = Insert_Album_Save(objAlbumSave, trans, cn);
                }

                Update_Staff_Album_Save(objAlbumSave.Album_Id, objAlbumSave.Album_AddedBy, trans, cn);
                for (int i = 0; i < obj_tbl_Album_Staff_Li.Count; i++)
                {
                    obj_tbl_Album_Staff_Li[i].AlbumStaff_Album_Id = objAlbumSave.Album_Id;
                    Insert_Staff_Album_Save(obj_tbl_Album_Staff_Li[i], trans, cn);
                }

                Update_Album_Genere_save(objAlbumSave.Album_Id, objAlbumSave.Album_AddedBy, trans, cn);
                for (int i = 0; i < obj_tbl_Album_Genere_Li.Count; i++)
                {
                    obj_tbl_Album_Genere_Li[i].AlbumGenere_Album_Id = objAlbumSave.Album_Id;
                    Insert_Album_Genere_save(obj_tbl_Album_Genere_Li[i], trans, cn);
                }

                if (!Directory.Exists(Server.MapPath(".") + "\\Downloads\\" + objAlbumSave.Album_Id.ToString()))
                {
                    Directory.CreateDirectory(Server.MapPath(".") + "\\Downloads\\" + objAlbumSave.Album_Id.ToString());
                }
                for (int i = 0; i < obj_tbl_Upload_BannerLi.Count; i++)
                {
                    obj_tbl_Upload_BannerLi[i].AlbumUpload_Album_Id = objAlbumSave.Album_Id;
                    if (obj_tbl_Upload_BannerLi[i].AlbumUpload_File_Bytes != null && obj_tbl_Upload_BannerLi[i].AlbumUpload_File_Bytes.Length > 0)
                    {
                        File.WriteAllBytes(Server.MapPath(".") + "\\Downloads\\" + objAlbumSave.Album_Id.ToString() + "\\" + obj_tbl_Upload_BannerLi[i].AlbumUpload_Path, obj_tbl_Upload_BannerLi[i].AlbumUpload_File_Bytes);
                        obj_tbl_Upload_BannerLi[i].AlbumUpload_Path = "\\Downloads\\" + objAlbumSave.Album_Id.ToString() + "\\" + obj_tbl_Upload_BannerLi[i].AlbumUpload_Path;
                        Insert_Upload_Banner(obj_tbl_Upload_BannerLi[i], trans, cn);
                    }
                }

                trans.Commit();
                cn.Close();
                flag = true;
            }
            catch (Exception e)
            {
                trans.Rollback();
                cn.Close();
                flag = false;
            }
        }
        return flag;
    }

    private void Update_Staff_Album_Save(int album_Id, int album_AddedBy, SqlTransaction trans, SqlConnection cn)
    {
        string strQuer = "";
        strQuer = "set dateformat dmy; update tbl_Album_Staff set [AlbumStaff_Status] = 0 where [AlbumStaff_Status] = 1 and [AlbumStaff_Album_Id] = '" + album_Id + "' ";

        if (trans == null)
        {
            try
            {
                ExecuteSelectQuery(strQuer);
            }
            catch (Exception ee)
            {

            }
        }
        else
        {
            ExecuteSelectQuerywithTransaction(cn, strQuer, trans);

        }
    }

    private void Update_Album_Genere_save(int album_Id, int album_AddedBy, SqlTransaction trans, SqlConnection cn)
    {
        string strQuer = "";
        strQuer = "set dateformat dmy; update tbl_Album_Genere set [AlbumGenere_Status] = 0 where [AlbumGenere_Status] = 1 and [AlbumGenere_Album_Id] = '" + album_Id + "' ";

        if (trans == null)
        {
            try
            {
                ExecuteSelectQuery(strQuer);
            }
            catch (Exception ee)
            {

            }
        }
        else
        {
            ExecuteSelectQuerywithTransaction(cn, strQuer, trans);

        }
    }

    private void Update_Album_Save(tbl_Album_Save objAlbumSave , SqlTransaction trans, SqlConnection cn)
    {
        string strQuer = "";
        strQuer = "set dateformat dmy; update tbl_Album_Save set [Album_Name]='"+ objAlbumSave.Album_Name + "',[Album_Description]='"+objAlbumSave.Album_Description+ "',[Album_Rating]='"+ objAlbumSave.Album_Rating+ "',[Album_Mounting_Rating]='" + objAlbumSave.Album_Mounting_Rating + "',[Album_Studio_Id]='" + objAlbumSave.Album_Studio_Id+ "',[Album_Category]='" + objAlbumSave.Album_Category + "',[Album_AddedBy]='"+objAlbumSave.Album_AddedBy+ "',[Album_AddedOn]=getdate(), [Album_ModifiedOn]='" + objAlbumSave.Album_ModifiedOn+ "',[Album_Status]='"+objAlbumSave.Album_Status+ "' where [Album_Id]='" + objAlbumSave.Album_Id+"' " ;

        if (trans == null)
        {
            try
            {
                ExecuteSelectQuery(strQuer);
            }
            catch (Exception ee)
            {

            }
        }
        else
        {
            ExecuteSelectQuerywithTransaction(cn, strQuer, trans);

        }
    }

    #endregion

    #region AlbumGenere 
    public bool Insert_Album_Genere_save(tbl_Album_Genere objAlbumSave, SqlTransaction trans, SqlConnection cn)
    {
        bool flag = false;
        DataSet dataSet = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Album_Genere([AlbumGenere_Album_Id],[AlbumGenere_Genere_id],[AlbumGenere_AddedBy],[AlbumGenere_AddedOn],[AlbumGenere_Status]) values ('" + objAlbumSave.AlbumGenere_Album_Id + "','" + objAlbumSave.AlbumGenere_Genere_id + "','" + objAlbumSave.AlbumGenere_AddedBy + "', getdate(),'" + objAlbumSave.AlbumGenere_Status + "' );select @@Identity";
        int ret_type = 0;
        if (trans == null)
        {
            try
            {
                dataSet = ExecuteSelectQuery(strQuer);
                flag = true;
            }
            catch (Exception ee)
            {
                ret_type = 0;
                flag = false;
            }
        }
        else
        {
            dataSet = ExecuteSelectQuerywithTransaction(cn, strQuer, trans);
            flag = true;
        }
        return flag;
    }

    public bool Insert_AlbumGenere(tbl_Album_Save objAlbumSave, List<tbl_Album_Genere> obj_tbl_Album_Genere_Li)

    {
        bool flag = false;
        DataSet ds = new DataSet();
        using (SqlConnection cn = new SqlConnection(ConStr))
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            SqlTransaction trans = cn.BeginTransaction();
            try
            {
                objAlbumSave.Album_Id = Insert_Album_Save(objAlbumSave, trans, cn);
                for (int i = 0; i < obj_tbl_Album_Genere_Li.Count; i++)
                {
                    obj_tbl_Album_Genere_Li[i].AlbumGenere_Album_Id = objAlbumSave.Album_Id;
                    Insert_Album_Genere_save(obj_tbl_Album_Genere_Li[i], trans, cn);
                }

                trans.Commit();
                cn.Close();
                flag = true;
            }
            catch
            {
                trans.Rollback();
                cn.Close();
                flag = false;
            }
        }
        return flag;
    }

    #endregion

    #region UploadBanner 

    public bool Insert_Upload_Banner(tbl_Upload_Banner objAlbumSave, SqlTransaction trans, SqlConnection cn)
    {
        bool flag = false;
        DataSet dataSet = new DataSet();
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Upload_Banner([AlbumUpload_Album_Id],[AlbumUpload_Path],[AlbumUpload_Type],[AlbumUpload_AddedOn],[AlbumUpload_Status]) values ('" + objAlbumSave.AlbumUpload_Album_Id + "','" + objAlbumSave.AlbumUpload_Path + "','" + objAlbumSave.AlbumUpload_Type + "', getdate(),'" + objAlbumSave.AlbumUpload_Status + "' );select @@Identity";
        int ret_type = 0;
        if (trans == null)
        {
            try
            {
                dataSet = ExecuteSelectQuery(strQuer);
                flag = true;
            }
            catch (Exception ee)
            {
                ret_type = 0;
                flag = false;
            }
        }
        else
        {
            dataSet = ExecuteSelectQuerywithTransaction(cn, strQuer, trans);
            flag = true;
        }
        return flag;
    }

    #endregion

    public DataSet Insert_Grid2(string save_name)
    {
        DataSet ds = new DataSet();
        string sql = @"select 
                            save_id,
                            save_name,
	                        save_Username,
	                        save_mobile,
	                        save_email,
	                        save_gender,
	                        save_age,
                            save_status
                        from save_account
                        where save_status =1";
        if (save_name != "")
        {
            sql += " and save_name like '%" + save_name + "%'";
        }



        sql += " order by save_name";
        try
        {
            ds = ExecuteSelectQuery(sql);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }
    public bool Delete_save(int save_id_Delete)
    {
        bool flag = false;
        string sql = "";
        try
        {
            sql = "update save_account set save_status = 0, save_ModifiedOn = getdate() where save_id = '" + save_id_Delete + "' and save_status = 1";
            ExecuteSelectQuery(sql);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;

    }
    public DataSet Edit(int save_id)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = @"set dateformat dmy; 
                    select 
                        save_id, 
                       save_name, 
                       save_Username,
                        save_mobile,
                        save_email, 
                        save_gender,
                        save_age,
                        save_AddedOn, 
                        save_AddedBy, 
                        save_ModifiedOn, 
                        save_ModifiedBy, 
                        save_status 
						from save_account                    
                    where save_id='" + save_id + "'";
        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }
    public bool Update_save_account(save_account obj_save_account)
    {
        bool flag = false;
        string strQuery = "";
        strQuery = " set dateformat dmy;Update  save_account set  save_name = N'" + obj_save_account.save_name + "', save_ModifiedOn = getdate(), save_ModifiedBy = '" + obj_save_account.save_AddedBy + "' where save_id = '" + obj_save_account.save_id + "' and save_status = '" + obj_save_account.save_status + "' ";
        if (obj_save_account != null)
        {
            ExecuteSelectQuery(strQuery);
            flag = true;
        }
        else
        {
            //ExecuteSelectQuerywithTransaction(strQuery);
            flag = true;

        }
        return flag;
       
    }

    public DataSet Edit_Album(int Album_Id)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = " select * from tbl_Album_Save where Album_Status=1 and Album_Id ='" + Album_Id + "'; ";

        strQuery += " select * from tbl_Album_Staff join tbl_Starring on Starring_id = AlbumStaff_Starring_id where AlbumStaff_Status=1 and AlbumStaff_Album_Id ='" + Album_Id + "' and Starring_Type = 'A'; ";

        strQuery += " select * from tbl_Album_Staff join tbl_Starring on Starring_id = AlbumStaff_Starring_id where AlbumStaff_Status=1 and AlbumStaff_Album_Id ='" + Album_Id + "' and Starring_Type = 'S'; ";

        strQuery += " select * from tbl_Album_Staff join tbl_Starring on Starring_id = AlbumStaff_Starring_id where AlbumStaff_Status=1 and AlbumStaff_Album_Id ='" + Album_Id + "' and Starring_Type = 'D'; ";

        strQuery += " select * from tbl_Album_Genere join tbl_Genere on AlbumGenere_Genere_id=Genere_Id where AlbumGenere_Status = 1 and AlbumGenere_Album_Id ='" + Album_Id + "'; ";

        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }

    public DataSet get_AlbumSearch_Edit(int Album_Id)
    {
        string strQuery = "";
        DataSet ds = new DataSet();
        strQuery = @"set dateformat dmy; 
                    select 
                            Album_Id,
	                        Album_Category,
	                        Album_Name,
	                        Album_Description,
	                        Album_Rating,
	                        Album_Mounting_Rating,
	                        Album_Studio_Id,
	                        Studio_Name,
	                        Album_AddedBy,
	                        Album_AddedOn,
	                        Album_Status, 
	                        Album_Genere.List_Genere, 
	                        Album_Actor.List_Actor, 
	                        Album_Director.List_Director, 
	                        Album_Supporting.List_Supporting
                    from tbl_Album_Save
                    where Album_Status = 1 and Album_Id='" + Album_Id + "'";



        try
        {
            ds = ExecuteSelectQuery(strQuery);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }

    public DataSet get_Banner(int Album_Id)
    {
        DataSet ds = new DataSet();
        string sql="";
        sql = @"set dateformat dmy; select AlbumUpload_Path,AlbumUpload_Type from dbo.tbl_Upload_Banner where AlbumUpload_Status = 1 and AlbumUpload_Album_Id='" + Album_Id + "'";
        try
        {
            ds = ExecuteSelectQuery(sql);
        }
        catch
        {
            ds = null;
        }
        return ds;
    }
    #region Company
    public bool _savebtn(tbl_Company objSaa)
    {
        bool flag = false;
        string strQuer = "";
        strQuer = "set dateformat dmy; insert into tbl_Company ([tbl_Company_Name],[Ato_sell],[Ato_By],[Totl_sell],[Totl_Qty],[tbl_Final_Qty],[tbl_Self_result],[tbl_NSE_result],[Date])values('" + objSaa.tbl_Company_Name + "','" + objSaa.Ato_sell + "','" + objSaa.Ato_By + "','" + objSaa.Totl_sell + "','" + objSaa.Totl_Qty + "','" + objSaa.tbl_Final_Qty + "','" + objSaa.tbl_Self_result + "','" + objSaa.tbl_NSE_result + "','" + objSaa.Date + "' where tbl_Company_Status=1);select @@Identity";
        try
        {
            ExecuteSelectQuery(strQuer);
            flag = true;
        }
        catch (Exception ee)
        {
            flag = false;
        }
        return flag;
    }

    public DataSet get_Company()
    {
        DataSet ds = new DataSet();
        string strQuer = "";
        strQuer = "Select tbl_Company_Name from tbl_Company";
        try
        {
            ds = ExecuteSelectQuery(strQuer);
        }
        catch (Exception ee)
        {
            ds = null;
        }
        return ds;
    }
  

    #endregion

    public bool seve_Ammount(tbl_Company obj_data )
    {
        bool flag = false;
        string Sql = "";
        Sql = "set dateformat dmy; insert into tbl_Company([tbl_Company_Name],[Ato_sell],[Ato_By],[Totl_sell],[Totl_Qty],[tbl_Final_Qty],[tbl_Self_result],[tbl_NSE_result],[Date],[tbl_Company_Status]) values('" + obj_data.tbl_Company_Name + "', '" + obj_data.Ato_sell + "', '" + obj_data.Ato_By + "', '" + obj_data.Totl_sell + "', '" + obj_data.Totl_Qty + "', '" + obj_data.tbl_Final_Qty + "', '" + obj_data.tbl_Self_result + "', '" + obj_data.tbl_NSE_result + "', '" + obj_data.Date + "', 1)"; 
        
        //int ret_type = 0;
        DataSet dataSet = new DataSet();
        try
        {
            dataSet = ExecuteSelectQuery(Sql);
            flag = true;
        }
        catch (Exception ee)
        {
            //ret_type = 0;
            flag = false;
        }
        return flag;
    }
}