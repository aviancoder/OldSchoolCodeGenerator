﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OldSchoolCodeGenerator
{
    public partial class CSharpCodeGenerator : Form
    {
        int DATATYPE_STRING = 0;
        int DATATYPE_INT = 1;
        int DATATYPE_DOUBLE = 2;
        int DATATYPE_DATE = 3;
        int DATATYPE_BOOLEAN = 4;

        public CSharpCodeGenerator()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            List<CustomField> fields = GetFields();
            this.txtModelClass.Text = GetModelClassString(fields);
            this.txtCRUD.Text = GetModelToFields(fields);
            this.txtCRUD.Text += Environment.NewLine;
            this.txtCRUD.Text += GetFieldsToModel(fields);
            this.txtCRUD.Text += Environment.NewLine;
            this.txtCRUD.Text += GetDBToModel(fields);
            this.txtStoredProcedures.Text = GetInsertStoredProc(fields);
            this.txtStoredProcedures.Text += Environment.NewLine;
            this.txtStoredProcedures.Text += GetUpdateStoredProc(fields);
            this.txtStoredProcedures.Text += Environment.NewLine;
            this.txtStoredProcedures.Text += GetDeleteStoredProc(fields);
            this.txtStoredProcedures.Text += Environment.NewLine;
            this.txtStoredProcedures.Text += GetSelectSingleStoredProc(fields);
            this.txtStoredProcedures.Text += Environment.NewLine;
            this.txtStoredProcedures.Text += GetSelectManyStoredProc(fields);
            this.txtView.Text = "";
            this.txtView.Text += GetViewElements(fields);
            this.txtAJAXScripts.Text = GetJSFieldsToModel(fields);
        }

        private List<CustomField> GetFields()
        {
            List<CustomField> retval = new List<CustomField>();

            string fieldNames = this.txtFieldNames.Text.Trim();
            if (String.IsNullOrEmpty(fieldNames) == false)
            {
                string[] lines = fieldNames.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    string rawstr = s.Trim();
                    string[] cols = rawstr.Split(null);
                    if (cols.Length > 1)
                    {
                        string fieldname = cols[0];
                        int dataType = DATATYPE_STRING;
                        string rawDataType = cols[1].ToUpper();
                        if (rawDataType.Contains("INT") == true)
                        {
                            dataType = DATATYPE_INT;
                        }
                        if (rawDataType.Contains("FLOAT") == true)
                        {
                            dataType = DATATYPE_DOUBLE;
                        }
                        if (rawDataType.Contains("DATE") == true)
                        {
                            dataType = DATATYPE_DATE;
                        }
                        if (rawDataType.Contains("BIT") == true)
                        {
                            dataType = DATATYPE_BOOLEAN;
                        }
                        CustomField cf = new CustomField();
                        cf.FieldName = fieldname;
                        cf.DataType = dataType;

                        retval.Add(cf);
                    }
                }
            }

            return retval;
        }

        private string GetModelClassString(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomField cf in _fields)
            {

                //if (cf.DataType == DATATYPE_STRING)
                //    sb.AppendLine("data." + cf.FieldName + " = " + "GetStringValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_INT)
                    sb.AppendLine(" [DisplayFormat(DataFormatString = \"{0:#,##0}\", ApplyFormatInEditMode = true)]");
                if (cf.DataType == DATATYPE_DOUBLE)
                    sb.AppendLine(" [DisplayFormat(DataFormatString = \"{0:#,##0}\", ApplyFormatInEditMode = true)]");
                //if (cf.DataType == DATATYPE_BOOLEAN)
                //    sb.AppendLine("data." + cf.FieldName + " = " + "GetBooleanValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_DATE)
                    sb.AppendLine("   [DisplayFormat(DataFormatString = \"{ 0:dd/MM/yyyy}\", ApplyFormatInEditMode = true)]");

                string lineStr = "public " + GetVariableString(cf.DataType) + " " + cf.FieldName + "{ get; set; }";
                sb.AppendLine(lineStr);
            }

            sb.AppendLine(GetSQPParametersListString(_fields));

            return sb.ToString();
        }

        private string GetSQPParametersListString(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"public List<SqlParameter> GetSQLParameters(bool _inserting) {");
            sb.AppendLine(@"List<SqlParameter> retval = new List<SqlParameter>();");

            bool isFirst = true;
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine(@"if (_inserting) {");
                    sb.AppendLine(@"SqlParameter sqlp" + cf.FieldName + " = new SqlParameter(\"@" + cf.FieldName + "\", this." + cf.FieldName + ");");
                    sb.AppendLine(@"sqlp" + cf.FieldName + ".Direction = ParameterDirection.Output;");
                    sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.Int32;");
                    sb.AppendLine(@"retval.Add(sqlp" + cf.FieldName + ");");
                    sb.AppendLine(@"}");
                    sb.AppendLine(@"else {");
                    sb.AppendLine(@"SqlParameter sqlp" + cf.FieldName + " = New SqlParameter(\"@" + cf.FieldName + "\", this." + cf.FieldName + ");");
                    sb.AppendLine(@"sqlp" + cf.FieldName + ".Direction = ParameterDirection.Input;");
                    sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.Int32;");
                    sb.AppendLine(@"retval.Add(sqlp" + cf.FieldName + ");");
                    sb.AppendLine(@"}");
                }
                else
                {

                    sb.AppendLine(@"SqlParameter sqlp" + cf.FieldName + " = new SqlParameter(\"@" + cf.FieldName + "\", this." + cf.FieldName + ");");
                    sb.AppendLine(@"sqlp" + cf.FieldName + ".Direction = ParameterDirection.Input;");
                    if (cf.DataType == DATATYPE_STRING)
                        sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.String;");
                    if (cf.DataType == DATATYPE_INT)
                        sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.Int32;");
                    if (cf.DataType == DATATYPE_DOUBLE)
                        sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.Double;");
                    if (cf.DataType == DATATYPE_DATE)
                        sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.DateTime;");
                    if (cf.DataType == DATATYPE_BOOLEAN)
                        sb.AppendLine(@"sqlp" + cf.FieldName + ".DbType = DbType.Boolean;");
                    sb.AppendLine(@"retval.Add(sqlp" + cf.FieldName + ");");
                }

                sb.AppendLine("");
                isFirst = false;
            }
            sb.AppendLine(@"return retval");
            sb.AppendLine(@"}");
            return sb.ToString();
        }

        private string GetVariableString(int _dt)
        {
            string retval = "string";
            if (_dt == 1)
                retval = "int";
            if (_dt == 2)
                retval = "double";
            if (_dt == 3)
                retval = "DateTime";
            if (_dt == 4)
                retval = "bool";

            return retval;

        }

        private string GetModelToFields(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomField cf in _fields)
            {
                if (cf.DataType == DATATYPE_BOOLEAN)
                    sb.AppendLine("this." + cf.FieldName + ".Checked = " + " data." + cf.FieldName + ";");
                else
                    sb.AppendLine("this." + cf.FieldName + ".Text = " + " data." + cf.FieldName + GetDisplayFormatting(cf.DataType) + ";");
            }

            return sb.ToString();
        }

        private string GetFieldsToModel(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomField cf in _fields)
            {
                if (cf.DataType == DATATYPE_BOOLEAN)
                    sb.AppendLine("data." + cf.FieldName + " = " + "this." + cf.FieldName + ".Checked;");
                else
                    sb.AppendLine("data." + cf.FieldName + " = " + "this." + cf.FieldName + ".Text;");
            }

            return sb.ToString();
        }

        private string GetDisplayFormatting(int _dt)
        {
            string retval = "";
            if (_dt == 1)
                retval = ".ToString(\"#,##0\")";
            if (_dt == 2)
                retval = ".ToString(\"#,##0\")";
            if (_dt == 3)
                retval = ".ToString(\"dd/MM/yyyy\")";
            if (_dt == 4)
                retval = "";

            return retval;
        }

        private string GetDBToModel(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomField cf in _fields)
            {
                if (cf.DataType == DATATYPE_STRING)
                    sb.AppendLine("data." + cf.FieldName + " = " + "GetStringValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_INT)
                    sb.AppendLine("data." + cf.FieldName + " = " + "(int)GetNumericValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_DOUBLE)
                    sb.AppendLine("data." + cf.FieldName + " = " + "GetNumericValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_BOOLEAN)
                    sb.AppendLine("data." + cf.FieldName + " = " + "GetBooleanValueFromDB(\"" + cf.FieldName + "\",_dr);");
                if (cf.DataType == DATATYPE_DATE)
                    sb.AppendLine("data." + cf.FieldName + " = " + "GetDateValueFromDB(\"" + cf.FieldName + "\",_dr);");
            }

            return sb.ToString();
        }

        private string GetInsertStoredProc(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
            sb.AppendLine("CREATE PROCEDURE[dbo].[<SPNAME>](");

            bool isFirst = true;
            string scope_indentity_line = "";
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine("@" + cf.FieldName + " INT OUTPUT");
                    scope_indentity_line = "SET @" + cf.FieldName + " = SCOPE_IDENTITY()";
                    isFirst = false;
                }
                else
                {
                    if (cf.DataType == DATATYPE_STRING)
                        sb.AppendLine(",@" + cf.FieldName + " NVARCHAR(255)");
                    if (cf.DataType == DATATYPE_INT)
                        sb.AppendLine(",@" + cf.FieldName + " INT");
                    if (cf.DataType == DATATYPE_DOUBLE)
                        sb.AppendLine(",@" + cf.FieldName + " FLOAT");
                    if (cf.DataType == DATATYPE_BOOLEAN)
                        sb.AppendLine(",@" + cf.FieldName + " BIT");
                    if (cf.DataType == DATATYPE_DATE)
                        sb.AppendLine(",@" + cf.FieldName + " DATE");
                }

            }

            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("INSERT INTO [dbo].[<TABLENAME>](");
            int fieldCount = 0;
            foreach (CustomField cf in _fields)
            {
                if (fieldCount < 2)
                {
                    if (fieldCount > 0)
                    {
                        sb.AppendLine("[" + cf.FieldName + "]");
                    }
                    fieldCount++;
                }
                else
                {
                    sb.AppendLine(",[" + cf.FieldName + "]");
                }

            }
            sb.AppendLine(")");
            sb.AppendLine("VALUES(");
            fieldCount = 0;
            foreach (CustomField cf in _fields)
            {
                if (fieldCount < 2)
                {
                    if (fieldCount > 0)
                    {
                        sb.AppendLine("@" + cf.FieldName);
                    }
                    fieldCount++;
                }
                else
                {
                    sb.AppendLine(",@" + cf.FieldName);
                }

            }
            sb.AppendLine(")");
            sb.AppendLine(scope_indentity_line);
            sb.AppendLine("END");
            sb.AppendLine("GO");

            return sb.ToString();
        }

        private string GetUpdateStoredProc(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
            sb.AppendLine("CREATE PROCEDURE[dbo].[<SPNAME>](");

            bool isFirst = true;
            string where_clause = "";
            //parameters
            bool isFirstField = true;
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine("@" + cf.FieldName + " INT");
                    isFirst = false;
                }
                else
                {
                    if (cf.DataType == DATATYPE_STRING)
                        sb.AppendLine(",@" + cf.FieldName + " NVARCHAR(255)");
                    if (cf.DataType == DATATYPE_INT)
                        sb.AppendLine(",@" + cf.FieldName + " INT");
                    if (cf.DataType == DATATYPE_DOUBLE)
                        sb.AppendLine(",@" + cf.FieldName + " FLOAT");
                    if (cf.DataType == DATATYPE_BOOLEAN)
                        sb.AppendLine(",@" + cf.FieldName + " BIT");
                    if (cf.DataType == DATATYPE_DATE)
                        sb.AppendLine(",@" + cf.FieldName + " DATE");
                }
            }
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("UPDATE [dbo].[<TABLENAME>] ");
            sb.AppendLine(" SET");
            isFirst = true;
            isFirstField = true;
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    where_clause = "WHERE (" + cf.FieldName + " = @" + cf.FieldName + ")";
                    isFirst = false;
                }
                else
                {
                    if (isFirstField)
                    {
                        sb.AppendLine(cf.FieldName + " = @" + cf.FieldName);
                        isFirstField = false;
                    }
                    else
                    {
                        sb.AppendLine("," + cf.FieldName + " = @" + cf.FieldName);
                    }
                }
            }
            sb.AppendLine(where_clause);
            sb.AppendLine("END");
            sb.AppendLine("GO");

            return sb.ToString();
        }

        private string GetSelectSingleStoredProc(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
            sb.AppendLine("CREATE PROCEDURE[dbo].[<SPNAME>](");

            bool isFirst = true;
            string where_clause = "";
            //parameters

            sb.AppendLine("@" + _fields[0].FieldName + " INT");
            where_clause = "WHERE (" + _fields[0].FieldName + " = @" + _fields[0].FieldName + ")";
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine("@" + cf.FieldName + " INT");
                    isFirst = false;
                }
            }
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("SELECT ");
            isFirst = true;
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine(cf.FieldName);
                    isFirst = false;
                }
                else
                {
                    sb.AppendLine("," + cf.FieldName);
                }
            }
            sb.AppendLine(" FROM [dbo].[<TABLENAME>]");
            sb.AppendLine(where_clause);
            sb.AppendLine("END");
            sb.AppendLine("GO");

            return sb.ToString();
        }

        private string GetSelectManyStoredProc(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
            sb.AppendLine("CREATE PROCEDURE[dbo].[<SPNAME>](");

            bool isFirst = true;
            string where_clause = "";
            //parameters

            sb.AppendLine("@SearchKey NVARCHAR(255)");
            where_clause = " WHERE (<FieldName> LIKE '%'+ @SearchKey + '%')";
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine("SELECT ");
            isFirst = true;
            foreach (CustomField cf in _fields)
            {
                if (isFirst)
                {
                    sb.AppendLine(cf.FieldName);
                    isFirst = false;
                }
                else
                {
                    sb.AppendLine("," + cf.FieldName);
                }
            }
            sb.AppendLine(" FROM [dbo].[<TABLENAME>]");
            sb.AppendLine(where_clause);
            sb.AppendLine("END");
            sb.AppendLine("GO");

            return sb.ToString();
        }

        private string GetDeleteStoredProc(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SET ANSI_NULLS ON");
            sb.AppendLine("GO");
            sb.AppendLine("SET QUOTED_IDENTIFIER ON");
            sb.AppendLine("GO");
            sb.AppendLine("CREATE PROCEDURE[dbo].[<SPNAME>](");
            sb.AppendLine("@" + _fields[0].FieldName + " INT");
            sb.AppendLine(")");
            sb.AppendLine("AS");
            sb.AppendLine("BEGIN");
            sb.AppendLine(" DELETE FROM [dbo].[<TABLENAME>]");
            sb.AppendLine("WHERE (" + _fields[0].FieldName + " = @" + _fields[0].FieldName + ")");
            sb.AppendLine("END");
            sb.AppendLine("GO");

            return sb.ToString();
        }

        private string GetViewElements(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();

            foreach (CustomField cf in _fields)
            {
                if (cf.DataType == DATATYPE_STRING)
                {
                    sb.AppendLine("<div class=\"col -4\">");
                    sb.AppendLine("     <div class=\"form-group\">");
                    sb.AppendLine("         <label asp-for=\"" + cf.FieldName + "\">" + cf.FieldName + "</label>");
                    sb.AppendLine("         <div class=\"input-group\">");
                    sb.AppendLine("             <span class=\"input-group-addon\">");
                    sb.AppendLine("                 <i class=\"now-ui-icons text_caps-small text-primary\"></i>");
                    sb.AppendLine("             </span>");
                    sb.AppendLine("             <input asp-for=\"" + cf.FieldName + "\" type=\"text\" class=\"form-control\" id=\"" + cf.FieldName + "\" placeholder=\"" + cf.FieldName + "\">");
                    sb.AppendLine("         </div>");
                    sb.AppendLine("     </div>");
                    sb.AppendLine("</div>");
                }
                if (cf.DataType == DATATYPE_INT)
                {
                    sb.AppendLine("<div class=\"col-4\">");
                    sb.AppendLine("     <div class=\"form-group\">");
                    sb.AppendLine("         <label asp-for=\"" + cf.FieldName + "\">" + cf.FieldName + "</label>");
                    sb.AppendLine("         <div class=\"input-group\">");
                    sb.AppendLine("             <span class=\"input-group-addon\">");
                    sb.AppendLine("                 <i class=\"fa fa-hashtag text-primary\"></i>");
                    sb.AppendLine("             </span>");
                    sb.AppendLine("             <input asp-for=\"" + cf.FieldName + "\" type=\"text\" class=\"form-control text-right one50group-formattednumber\" id=\"" + cf.FieldName + "\" placeholder=\"" + cf.FieldName + "\">");
                    sb.AppendLine("         </div>");
                    sb.AppendLine("     </div>");
                    sb.AppendLine("</div>");
                }
                if (cf.DataType == DATATYPE_DOUBLE)
                {
                    sb.AppendLine("<div class=\"col-4\">");
                    sb.AppendLine("     <div class=\"form-group\">");
                    sb.AppendLine("         <label asp-for=\"" + cf.FieldName + "\">" + cf.FieldName + "</label>");
                    sb.AppendLine("         <div class=\"input-group\">");
                    sb.AppendLine("             <span class=\"input-group-addon\">");
                    sb.AppendLine("                 <i class=\"fa fa-dollar text-primary\" ></i>");
                    sb.AppendLine("             </span>");
                    sb.AppendLine("             <input asp-for=\"" + cf.FieldName + "\" type=\"text\" class=\"form-control text-right one50group-formattednumber\" id=\"" + cf.FieldName + "\" placeholder=\"" + cf.FieldName + "\">");
                    sb.AppendLine("         </div>");
                    sb.AppendLine("     </div>");
                    sb.AppendLine("</div>");
                }
                if (cf.DataType == DATATYPE_DATE)
                {
                    sb.AppendLine("<div class=\"col-4\">");
                    sb.AppendLine("     <div class=\"form-group\">");
                    sb.AppendLine("         <label asp-for=\"" + cf.FieldName + "\">" + cf.FieldName + "</label>");
                    sb.AppendLine("         <div class=\"input-group\">");
                    sb.AppendLine("             <span class=\"input-group-addon\">");
                    sb.AppendLine("                 <i class=\"fa fa-calendar text-primary\" ></i>");
                    sb.AppendLine("             </span>");
                    sb.AppendLine("             <input asp-for=\"" + cf.FieldName + "\"  id=\"" + cf.FieldName + "\" placeholder=\"" + cf.FieldName + "\" type=\"text\" class=\"form-control date-picker text-right\" data-datepicker-color=\"primary\" data-date-format=\"dd/mm/yyyy\">");
                    sb.AppendLine("         </div>");
                    sb.AppendLine("     </div>");
                    sb.AppendLine("</div>");
                }
                if (cf.DataType == DATATYPE_BOOLEAN)
                {
                    sb.AppendLine("<div class=\"col-4\">");
                    sb.AppendLine("     <div class=\"form-group\">");
                    sb.AppendLine("         <div class=\"checkbox\">");
                    sb.AppendLine("             <input asp-for=\"" + cf.FieldName + "\" type=\"checkbox\" class=\"form-check-input\" id=\"" + cf.FieldName + "\" placeholder=\"" + cf.FieldName + "\">");
                    sb.AppendLine("             <label asp-for=\"" + cf.FieldName + "\">" + cf.FieldName + "</label>");
                    sb.AppendLine("         </div>");
                    sb.AppendLine("     </div>");
                    sb.AppendLine("</div>");
                }
            }
            return sb.ToString();
        }

        private string GetJSFieldsToModel(List<CustomField> _fields)
        {
            StringBuilder sb = new StringBuilder();
            string prepend = this.txtPrepend.Text.Trim();

            sb.AppendLine("var postData = new Object();");

            foreach (CustomField cf in _fields)
            {
                if (cf.DataType == DATATYPE_STRING)
                {
                    sb.AppendLine("postData." + cf.FieldName + " = $(\"#" + prepend + cf.FieldName + "\").val();");
                }
                if (cf.DataType == DATATYPE_INT)
                {
                    sb.AppendLine("postData." + cf.FieldName + " = prepareNumber($(\"#" + prepend + cf.FieldName + "\").val());");
                }
                if (cf.DataType == DATATYPE_DOUBLE)
                {
                    sb.AppendLine("postData." + cf.FieldName + " = prepareNumber($(\"#" + prepend + cf.FieldName + "\").val());");
                }
                if (cf.DataType == DATATYPE_DATE)
                {
                    sb.AppendLine("postData." + cf.FieldName + " = prepareDate($(\"#" + prepend + cf.FieldName + "\").val());");
                }
                if (cf.DataType == DATATYPE_BOOLEAN)
                {
                    sb.AppendLine("postData." + cf.FieldName + " = prepareBoolean($(\"#" + prepend + cf.FieldName + "\").val());");
                }
            }
            return sb.ToString();
        }

    }
}
