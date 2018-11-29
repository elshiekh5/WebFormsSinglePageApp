using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Posts
{
    public partial class Edit : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            ddlCategories.EnableViewState = true;

            if (!IsPostBack)
            {
            LoadData();
            }
        }
        //------------------------------------------------------
        //LoadData
        //------------------------------------------------------
        private void LoadData()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var context = new SinglePageAppEntities())
            {
                //------------------------------------------------------
                //LoadCategories
                //------------------------------------------------------
                var categoryList = context.Categories.ToList();
                ddlCategories.DataSource = categoryList;
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataTextField = "Title";
                ddlCategories.DataBind();
                //------------------------------------------------------
                var post = context.Posts.Where(e=>e.PostID==id).FirstOrDefault();
                txtTitle.Text = post.Title;
                txtDescription.Text = post.Description;
                //------------------------------------------------------
            }

        }

        //------------------------------------------------------
        //btnSave_Click
        //------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                using (var context = new SinglePageAppEntities())
                {
                    var post = context.Posts.Where(p => p.PostID == id).FirstOrDefault();
                    post.Title = txtTitle.Text;
                    post.Description = txtDescription.Text;
                    context.SaveChanges();
                }

                divFormContainer.Visible = false;
                ltrMessage.Text = "تم التعديل الحمد لله";
                alertBox.Visible = true;
            }
            catch
            {
                alertBox.InnerText = "Error happend ya halawa";
                alertBox.Visible = true;

                //throw new Exception("");
            }

        }
        //------------------------------------------------------

    }
}