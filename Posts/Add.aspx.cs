using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Posts
{
    public partial class Add : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = true;
            ddlCategories.EnableViewState = true;
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }
        //------------------------------------------------------
        //LoadCategories
        //------------------------------------------------------
        private void LoadCategories()
        {
            using (var context = new SinglePageAppEntities())
            {
                var categoryList = context.Categories.ToList();
                ddlCategories.DataSource = categoryList;
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataTextField = "Title";
                ddlCategories.DataBind();
                ddlCategories.Items.Insert(0, new ListItem("choose category", "-1"));
            }

        }
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string filesPath = Path.GetExtension(fuImage.FileName);
                // ItemsFiles.FileExtension = Path.GetExtension(fuPhoto.FileName);
                if (fuImage.HasFile)
                {
                    string serverPath = Server.MapPath("/App_Files/");

                    fuImage.SaveAs(serverPath + fuImage.FileName);
                }
                using (var context = new SinglePageAppEntities())
                {
                    var newPost = new Post
                    {
                        Title = txtTitle.Text,
                        Description = txtDescription.Text,
                        CategoryID = Convert.ToInt32(ddlCategories.SelectedValue),
                        CreationDate = DateTime.Now
                    };
                    context.Posts.Add(newPost);
                    context.SaveChanges();
                }

                divFormContainer.Visible = false;
                ltrMessage.Text = "تم الاضافة الحمد لله";
                alertBox.Visible = true;
            }
            catch (Exception ex){
                alertBox.InnerText = "Error happend ya halawa";
                alertBox.Visible = true;

                //throw new Exception("");
            }

        }
        //------------------------------------------------------

    }
}