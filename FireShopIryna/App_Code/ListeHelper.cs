using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ListeHelper
/// </summary>
public class ListeHelper
{
	public ListeHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Opfylder DDL
    // <summary>
    // Generic method
    // Generic methods have type parameters. 
    // They provide a way to parameterize the types used in a method. 
    // This means you can provide only one implementation and call it with different types.
    // </summary>
    // <typeparam name="T"></typeparam>
    // <param name="query"></param>
    // <param name="DataTextField"></param>
    // <param name="DataValueField"></param>
    public void DDL<T>(List<T> query, string DataTextField, string DataValueField, DropDownList ddl)
    {
        //Henter data fra DB
        ddl.DataSource = query;

        // Sætte værdier på Dropdown liste
        //DataText_Field - data, der skal vises i liste   

        ddl.DataTextField = DataTextField;
        ddl.DataValueField = DataValueField;
        ddl.DataBind();
    }
    #endregion
}