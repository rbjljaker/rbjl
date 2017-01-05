<%@ Page Title="" Language="C#" MasterPageFile="~/MasterLF.master" AutoEventWireup="true"
    CodeFile="testingjq.aspx.cs" Inherits="testingjq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMainContent" runat="Server">
    <div class="timer">
        <span class="hour">00</span>:<span class="minute">00</span>:<span class="second">00</span>
    </div>
    <div class="control">
        <button onclick="timer.start(1000)">
            Start</button>
        <button onclick="timer.stop()">
            Stop</button>
        <button onclick="timer.reset(60)">
            Reset</button>
        <button onclick="timer.mode(1)">
            Count up</button>
        <button onclick="timer.mode(0)">
            Count down</button>

            <a id="fontSizeM" title="預設字體大小" href="javascript:timer.start(1000)"><span class="access">預設字體大小</span>A</a>
    </div>
</asp:Content>
