<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WeatherAPI.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Daily Weather Forecast</title>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
            border-collapse: collapse;
        }

            table th {
                background-color: #f7f7f7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border: 1px solid #ccc;
            }

            table, table table td {
                border: 0px solid #ccc;
            }

        .badge {
            display: inline-block;
            min-width: 10px;
            padding: 3px 7px;
            font-size: 12px;
            font-weight: 700;
            color: #fff;
            line-height: 1;
            vertical-align: baseline;
            white-space: nowrap;
            text-align: center;
            background-color: #999;
            border-radius: 10px;
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtCity" runat="server" Text="" />
        <asp:Button Text="Get Weather Information" runat="server" OnClick="GetWeatherInfo" />
        <hr />
        <table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0" visible="false">
            <tr>
                <th colspan="2">Weather Information</th>
            </tr>
            <tr>
                <td rowspan="4">
                    <asp:Image ID="imgWeatherIcon" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCity_Country" runat="server" />
                    <asp:Image ID="imgCountryFlag" runat="server" />
                    <asp:Label ID="lblDescription" runat="server" />                    
                </td>
            </tr>
            <tr>
                <td>
                    <span class="badge badge-info">
                        <asp:Label ID="lblTemperature" runat="server"/> 
                    </span>
                    temperature from
                    <asp:Label ID="lblTempMin" runat="server" />
                    to
                    <asp:Label ID="lblTempMax" runat="server" />,
                    humidity  
                    <asp:Label ID="lblHumidity" runat="server" />%,
                    wind                     
                    <asp:Label ID="lblWind" runat="server" /> m/s.
                    clouds 
                    <asp:Label ID="lblClouds" runat="server" />%,
                    <asp:Label ID="lblPressure" runat="server" /> hpa
                </td>
            </tr>
            <tr>
                <td>Geo coords [<asp:Label ID="lblLat" runat="server" />, <asp:Label ID="lblLon" runat="server" />]                    
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
