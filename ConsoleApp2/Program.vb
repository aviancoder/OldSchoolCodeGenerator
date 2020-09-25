Imports System
Imports System.Text

Module Program
    Sub Main(args As String())

        Dim sb As New StringBuilder

        'Amortization Computation

        'Dim mp = GetmonthlyPayment(600000, 0.04, 25)
        ''sb.AppendLine((mp / 12).ToString())
        'sb.AppendLine(mp.ToString())
        ''Investment Properties Control Generation

        Dim appendStr As String = ""


        sb.AppendLine("<div class=""row"">")
        sb.AppendLine("<div class=""col-md-12 mb-4 pr-md-1"">")
        sb.AppendLine("<div class=""card"">")
        sb.AppendLine("<div class=""card-body"">")
        sb.AppendLine("<h4 class=""card-title text-info"">Proposed Investment Properties</h4>")
        sb.AppendLine("<div class=""row"" id=""div" & appendStr & "InvestmentProperty"">")
        For i As Integer = 1 To 20
            sb.AppendLine(GenerateNode(i, appendStr))
        Next
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")

        Console.WriteLine(sb.ToString())
    End Sub

    Public Function GenerateNode(ByVal _idx As Integer, ByVal _appendStr As String)
        Dim sb As New StringBuilder

        sb.AppendLine("<div class=""col-md-6 mb-4""  id=""divCard" & _appendStr & "IP" & _idx & """ style=""display: none;"">")
        sb.AppendLine("<div class=""card"">")
        sb.AppendLine("<div class=""card-body"">")
        sb.AppendLine("<div id = ""divNew" & _appendStr & "IP" & _idx & """ style=""display: none;"">")
        sb.AppendLine("<div class=""d-flex"">")
        sb.AppendLine("<div class=""mr-auto p-2"">")
        sb.AppendLine("<label for=""" & _appendStr & "InvestmentProperty" & _idx & """>Property Name</label><asp:TextBox ID = """ & _appendStr & "InvestmentProperty" & _idx & """ runat=""server"" class=""form-control form-control-sm"" Style=""width: 240px !important;""></asp:TextBox>")
        sb.AppendLine("</div>")
        sb.AppendLine("<div class=""p-2"">")
        sb.AppendLine("<button onclick=""addsave" & _appendStr & "Property(" & _idx & ")"" type=""button"" class=""btn btn-success p-2"" id=""btnAdd" & _appendStr & "IP" & _idx & """ style=""display: none;""><span class=""fa fa-plus-circle"" style="""" title=""add property""></span></button>")
        sb.AppendLine("<button onclick=""addsave" & _appendStr & "Property(" & _idx & ")"" type=""button"" class=""btn btn-success p-2"" id=""btnSave" & _appendStr & "IP" & _idx & """ style=""display: none;""><span class=""fa fa-check-circle"" style="""" title=""save property name""></span></button>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("<div id = ""divUpdate" & _appendStr & "IP" & _idx & """ style=""display: none;"">")
        sb.AppendLine("<div class=""d-flex"">")
        sb.AppendLine("<div class=""mr-auto p-2"">")
        sb.AppendLine("<asp:HiddenField ID = """ & _appendStr & "InvestmentPropertyName" & _idx & """ runat=""server"" />")
        sb.AppendLine("<asp:Label ID = ""lblInvestmentPropertyName" & _idx & """ runat=""server"" class=""border-0 h5 text-info text-left""></asp:Label>")
        sb.AppendLine("</div>")
        sb.AppendLine("<div class=""p-2"">")
        sb.AppendLine("<button onclick=""edit" & _appendStr & "Property(" & _idx & ")""  type=""button"" class=""btn btn-success p-2"" id=""btnEdit" & _appendStr & "IP" & _idx & """ style=""display: none;""><span class=""fa fa-pencil"" style="""" title=""edit property name""></span></button>")
        sb.AppendLine("<button onclick=""remove" & _appendStr & "Property(" & _idx & ")""  type=""button"" class=""btn btn-danger p-2"" id=""btnRemove" & _appendStr & "IP" & _idx & """ style=""display: none;""><span class=""fa fa-trash"" style="""" title=""remove property""></span></button>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("<div id = ""divTableIP" & _idx & """ style=""display: none;"">")
        sb.AppendLine("<table class=""table table-borderless"">")
        sb.AppendLine("<tbody>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Purchase Year</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox ID = """ & _appendStr & "InvestmentPropertyPurchaseYear" & _idx & """ runat=""server"" class=""form-control form-control-sm text-right one50group-formattednumber""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Value ($)</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox ID = """ & _appendStr & "InvestmentPropertyValue" & _idx & """ runat=""server"" class=""form-control form-control-sm text-right one50group-formattednumber""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Debt ($)</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox ID = """ & _appendStr & "InvestmentPropertyDebt" & _idx & """ runat=""server"" class=""form-control form-control-sm text-right one50group-formattednumber""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>P&I Repayments Begin Year ($)</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox ID = """ & _appendStr & "InvestmentPropertyRepaymentsBeginYear" & _idx & """ runat=""server"" class=""form-control form-control-sm text-right one50group-formattednumber""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Years To Repay Debt</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox ID = """ & _appendStr & "InvestmentPropertyYearsToRepayDebt" & _idx & """ runat=""server"" class=""form-control form-control-sm text-right one50group-formattednumber""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Annual Appreciation Rate</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox runat = ""server"" ID=""" & _appendStr & "InvestmentPropertyAnnualAppreciationRate" & _idx & """  class=""form-control form-control-sm text-right one50group-formattednumber"" step="".01""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Mortgage Rate</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:TextBox runat = ""server"" ID=""" & _appendStr & "InvestmentPropertyMortgageRate" & _idx & """  class=""form-control form-control-sm text-right one50group-formattednumber"" step="".01""></asp:TextBox></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Monthly Interest Payments</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:Label runat = ""server"" ID=""" & _appendStr & "InvestmentPropertyMonthlyInterestRepayments" & _idx & """ class=""text-right""></asp:Label></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td><span>Monthly P&I Payments</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:Label runat = ""server"" ID=""" & _appendStr & "InvestmentPropertyMonthlyRepayments" & _idx & """ class=""text-right""></asp:Label></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td> <span class=""text-success"">Net  Value at Retirement ($)</span></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:Label runat = ""server"" ID=""" & _appendStr & "InvestmentPropertyNetValueAtRetirement" & _idx & """ class=""text-right h4""></asp:Label></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("<tr>")
        sb.AppendLine("<td></td>")
        sb.AppendLine("<td class=""text-right"">")
        sb.AppendLine("<asp:Button runat = ""server"" ID=""" & _appendStr & "InvestmentPropertySave" & _idx & """ class=""btn btn-success"" Text=""Save""></asp:Button></td>")
        sb.AppendLine("</tr>")
        sb.AppendLine("</tbody>")
        sb.AppendLine("</table>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")
        sb.AppendLine("</div>")

        Return sb.ToString()
    End Function

    Public Function GetmonthlyPayment(ByVal _presentValue As Double, ByVal _interestRate As Double, ByVal _numberOfYears As Integer) As Double
        Dim retval As Double = _presentValue

        _interestRate = _interestRate / 12
        _numberOfYears = _numberOfYears * 12

        retval = _presentValue / (((Math.Pow((1 + _interestRate), _numberOfYears)) - 1) / (_interestRate * (Math.Pow((1 + _interestRate), _numberOfYears))))

        Return retval
    End Function


End Module
