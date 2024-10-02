using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagementSystem.Web
{
	public partial class FirstPage : System.Web.UI.Page
	{
		private BookBL bookBL = new BookBL();
		string connectionString = ConnectionStringValues.ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				if(Request.QueryString["Id"] != null)
				{
					int bookId = Convert.ToInt32(Request.QueryString["Id"]);
					LoadBookDetails(bookId);
					btnSave.Visible = false;
					btnUpdate.Visible = true;
				}
			}

			CreateBookTable();
		}
		private void CreateBookTable()
		{
			bookBL.CreateBookTable();
		}
		protected void LoadBookDetails(int bookId)
		{
			try
			{
				DataTable dataTable = bookBL.LoadBookDetails(bookId);

				if(dataTable.Rows.Count > 0)
				{
					DataRow row = dataTable.Rows[0];
					txtBookName.Text = row["BookName"].ToString();
					txtAuthorName.Text = row["AuthorName"].ToString();
					txtBookCount.Text = row["BookCount"].ToString();
					txtPublicationYear.Text = row["PublicationYear"].ToString();
					txtISBN.Text = row["ISBN"].ToString();
					txtLanguage.Text = row["Language"].ToString();
				}
			}
			catch(Exception ex)
			{
				Label1.Text = "Error loading book details: " + ex.Message;
			}
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				string[] dataToInsert = {
			txtBookName.Text,
			txtAuthorName.Text,
			txtBookCount.Text,
			txtPublicationYear.Text,
			txtISBN.Text,
			txtLanguage.Text
		};

				if(Array.Exists(dataToInsert, string.IsNullOrEmpty))
				{
					Label1.Text = "Please fill in all text boxes.";
					return;
				}

				bookBL.InsertBook(dataToInsert);
				Label1.Text = "Book details saved successfully.";
				ClearFields();
			}
			catch(Exception ex)
			{
				Label1.Text = "Data insertion failed: " + ex.Message;
			}
		}
		protected void btnUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				int bookId = Convert.ToInt32(Request.QueryString["Id"]);
				string[] dataToUpdate = {
			txtBookName.Text,
			txtAuthorName.Text,
			txtBookCount.Text,
			txtPublicationYear.Text,
			txtISBN.Text,
			txtLanguage.Text
		};

				bookBL.UpdateBook(bookId, dataToUpdate);
				Label1.Text = "Data updated successfully.";
				ClearFields();
				Response.Redirect("GridViewPage.aspx");
			}
			catch(Exception ex)
			{
				Label1.Text = "Data update failed: " + ex.Message;
			}
		}
		protected void btnViewBooks_Click(object sender, EventArgs e)
		{
			Response.Redirect("GridViewPage.aspx");
		}

		private void ClearFields()
		{
			txtBookName.Text = "";
			txtAuthorName.Text = "";
			txtBookCount.Text = "";
			txtPublicationYear.Text = "";
			txtISBN.Text = "";
			txtLanguage.Text = "";
		}


	}
}