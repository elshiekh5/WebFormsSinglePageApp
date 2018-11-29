using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Posts
{
    public partial class Test : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            string c = ddlCategories.SelectedValue;
            string d = DropDownList1.SelectedValue;
            string d2 = Select1.Items[Select1.SelectedIndex].Text;
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        //------------------------------------------------------
        //
        //------------------------------------------------------
        private void LoadData()
        {
            using (var context = new SinglePageAppEntities())
            {
                var categoryList = context.Categories.ToList();
                ddlCategories.DataSource = categoryList;
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataTextField = "Title";
                ddlCategories.DataBind();
                foreach (var item in categoryList)
                {
                    DropDownList1.Items.Add(new ListItem { Text = item.Title, Value = item.CategoryID.ToString() });
                    Select1.Items.Add(new ListItem { Text = item.Title, Value = item.CategoryID.ToString() });
                }
            }

        }
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
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