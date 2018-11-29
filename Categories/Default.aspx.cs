using SinglePageAppWebForms.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SinglePageAppWebForms.Categories
{
    public partial class _Default : System.Web.UI.Page
    {
        //------------------------------------------------------
        //
        //------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {
            this.EnableViewState = false;
            string operation = Request.QueryString["operation"];
            if(!IsPostBack)
            {
                switch (operation)
                {
                    case "delete":
                        Delete();
                        break;
                    default:
                        break;
                }
               LoadData();
            }

        }

        private void LoadData()
        {
            using (var context = new SinglePageAppEntities())
            {
                drCategories.DataSource = context.Categories.ToList();
                drCategories.DataBind();
            }

        }

        private void Delete()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var context = new SinglePageAppEntities())
            {
                var  category = context.Categories.Where(c => c.CategoryID == id).FirstOrDefault();
                context.Categories.Remove(category);
                context.SaveChanges();
            }

        }
    }
}