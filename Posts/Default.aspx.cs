using SinglePageAppWebForms.App_Code;
using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Posts
{
    public partial class _Default : OurCustomPage
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
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
                ddlCategories.Items.Insert(0, new ListItem("choose category", "-1"));
                //------------------------------------------------------
                drPosts.DataSource = context.Posts.ToList();
                drPosts.DataBind();
                //------------------------------------------------------
            }

        }

        //------------------------------------------------------
       

        protected override void Delete()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var context = new SinglePageAppEntities())
            {
                var post = context.Posts.Where(c => c.PostID == id).FirstOrDefault();
                context.Posts.Remove(post);
                context.SaveChanges();
            }

        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            using (var context = new SinglePageAppEntities())
            {
                //------------------------------------------------------
                drPosts.DataSource = context.Posts.Where(p => p.CategoryID == selectedCategoryID || selectedCategoryID <= 0).ToList();
                drPosts.DataBind();
                //------------------------------------------------------
            }
        }
    }
}