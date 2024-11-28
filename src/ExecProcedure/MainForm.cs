using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace ExecProcedure
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(ParamValue.Text))
				MessageBox.Show("Param cannot be null or empty");
			else
			{
				int _paramValue = 0;
				Int32.TryParse(ParamValue.Text,out _paramValue);
				string commandText = $"select createrefnum({_paramValue})";
				try 
				{
					using(NpgsqlConnection conn = PgConnection.GetConnection())
					{
						using(NpgsqlCommand cmd = new NpgsqlCommand(commandText,conn))
						{
							NpgsqlParameter npgsqlParameter = new NpgsqlParameter();
							npgsqlParameter.NpgsqlDbType = NpgsqlDbType.Integer;
							npgsqlParameter.Value = _paramValue;
							cmd.Parameters.Add(npgsqlParameter);
							Object? res = cmd.ExecuteScalar();
							if(res == DBNull.Value)
							Output.Text = "Result > DBNull";
							else{
								if(res != null)
									Output.Text = "Result > " + res.ToString();
									else
									Output.Text = "Result > Null";
							}	
						}
					}
				} 
				catch (Exception ex) 
				{
					MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}				
			} //end else		
		}
	}
}
