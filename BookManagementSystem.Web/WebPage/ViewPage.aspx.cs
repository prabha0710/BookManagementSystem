using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagementSystem.Web.WebPage
{
	public partial class ViewPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				LoadBooks();
			}
		}

		private void LoadBooks()
		{
			using(SqlConnection con = new SqlConnection("data source=.;database=Book;integrated security=SSPI"))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("SELECT * FROM Book", con);
					gvBooks.DataSource = cmd.ExecuteReader();
					gvBooks.DataBind();
				}
				catch(Exception ex)
				{
					lblMessage.Text = "Error loading books: " + ex.Message;
				}
			}
		}

		protected void gvBooks_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int rowIndex = Convert.ToInt32(e.CommandArgument);
			int bookId = Convert.ToInt32(gvBooks.DataKeys[rowIndex].Value);

			if(e.CommandName == "EditBook")
			{
				Response.Redirect("FirstPage.aspx?Id=" + bookId);
			}
			else if(e.CommandName == "DeleteBook")
			{
				DeleteBook(bookId);
			}
		}

		private void DeleteBook(int bookId)
		{
			using(SqlConnection con = new SqlConnection("data source=.;database=Book;integrated security=SSPI"))
			{
				try
				{
					con.Open();
					SqlCommand cmd = new SqlCommand("DELETE FROM Book WHERE Id = @Id", con);
					cmd.Parameters.AddWithValue("@Id", bookId);
					cmd.ExecuteNonQuery();
					LoadBooks(); 
				}
				catch(Exception ex)
				{
					lblMessage.Text = "Error deleting book: " + ex.Message;
				}
			}
		}
	}
}
