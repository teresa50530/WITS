using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Macronix_WebForm
{
    public partial class index : System.Web.UI.Page
    {

        private string Moed_Flag
        {
            get { return ViewState["Moed_Flag"] as string ?? ""; }
            set { ViewState["Moed_Flag"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Person> personList = new List<Person>();
                GridView1.DataSource = personList;
                GridView1.DataBind();
                ViewState["PersonList"] = personList;

                // 確保在第一次加載頁面時，按鈕的文字為 "建立帳號"
                btnCalculate.Text = "建立帳號";
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Moed_Flag = "Edit";
             Button btnEdit = (Button)sender;
            GridViewRow row = (GridViewRow)btnEdit.NamingContainer;


            int index = row.RowIndex;
            List<Person> personList = (List<Person>)ViewState["PersonList"];


            Person selectedPerson = personList[index];

            txtName.Text = selectedPerson.Name;
            txtAge.Text = selectedPerson.Age.ToString();
            txtDate.Text = selectedPerson.Date;

            btnCalculate.Text = "修改帳號";
            hfSelectedIndex.Value = index.ToString();
        }


        protected void btnDelet_Click(object sender, EventArgs e)
        {

            Button btnDelete = (Button)sender;
            GridViewRow row = (GridViewRow)btnDelete.NamingContainer;
            int index = row.RowIndex;
            List<Person> personList = (List<Person>)ViewState["PersonList"];

            personList.RemoveAt(index);


            ViewState["PersonList"] = personList;


            GridView1.DataSource = personList;
            GridView1.DataBind();
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (CheckData() == true)
            {
               
                if (Moed_Flag == "Edit")
                {
                  
                    int index = int.Parse(hfSelectedIndex.Value);
                    List<Person> personList = (List<Person>)ViewState["PersonList"];
                    personList[index].Name = txtName.Text;
                    personList[index].Age = txtAge.Text;
                    personList[index].Date = txtDate.Text;

                   
                    GridView1.Rows[index].Cells[0].Text = txtName.Text;
                    GridView1.Rows[index].Cells[1].Text = txtAge.Text;
                    GridView1.Rows[index].Cells[2].Text = txtDate.Text;
                    btnCalculate.Text = "建立帳號";
                   
                    ClearInputs();
                 
                    Moed_Flag = "";
                }
                else
                {
                   
                    List<Person> personList = (List<Person>)ViewState["PersonList"];
                    personList.Add(new Person
                    {
                        Name = txtName.Text,
                        Age = txtAge.Text,
                        Date = DateTime.ParseExact(txtDate.Text, "yyyy/MM/dd", null).ToString("yyyy-MM-dd")
                    });
                    GridView1.DataSource = personList;
                    GridView1.DataBind();
                    ViewState["PersonList"] = personList;

                    ClearInputs();
                }
            }
      
        }


        [Serializable] 
        public class Person
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Date { get; set; }
        }

        private bool CheckData()
        {
            List<string> ErrMsg = new List<string>();

            if (txtName.Text == "")
                ErrMsg.Add("姓名");
            if (txtAge.Text == "")
                ErrMsg.Add("年齡");
            if (txtDate.Text == "")
                ErrMsg.Add("生日");

            if (ErrMsg.Count == 0)
                return true;
            else
            {
                string strErrMsg = string.Join(",", ErrMsg.ToArray());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('以下欄位為必填欄位： " + strErrMsg + "');", true);
                return false;
            }
        }

    
        private void ClearInputs()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtDate.Text = "";
        }
    }
}